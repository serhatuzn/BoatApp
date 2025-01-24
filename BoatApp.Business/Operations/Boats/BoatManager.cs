using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatApp.Business.Operations.Boats.Dtos;
using BoatApp.Business.Types;
using BoatApp.Data.Entites;
using BoatApp.Data.Repositories;
using BoatApp.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BoatApp.Business.Operations.NewFolder
{
    public class BoatManager : IBoatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<BoatEntity> _Boatrepository;
        private readonly IRepository<BoatFeatureEntity> _BoatFeaturerepository;

        public BoatManager(IUnitOfWork unitOfWork, IRepository<BoatEntity> Boatrepository, IRepository<BoatFeatureEntity> BoatFeaturerepository)
        {
            _unitOfWork = unitOfWork;
            _Boatrepository = Boatrepository;
            _BoatFeaturerepository = BoatFeaturerepository;
        }

        public async Task<ServiceMessage> AddBoatDto(AddBoatDto BoatDto)
        {
            var hasBoat = _Boatrepository.GetAll(x => x.Name.ToLower() == BoatDto.Name.ToLower()).Any();
            if (hasBoat)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu tekne zaten mevcut."
                };
            }

            await _unitOfWork.BeginTranscation();

            var BoatEntity = new BoatEntity
            {
                Name = BoatDto.Name,
                BoatType = BoatDto.BoatType,
                Location = BoatDto.Location,
                Length = BoatDto.Length,
                Capacity = BoatDto.Capacity,
                ManufactureYear = BoatDto.ManufactureYear
            };
            _Boatrepository.Add(BoatEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Tekne eklenirken bir hata oluştu.");
            }

            if (BoatDto.FeatureIds != null && BoatDto.FeatureIds.Any())
                foreach (var featureId in BoatDto.FeatureIds)
                {
                    var BoatFeatureEntity = new BoatFeatureEntity
                    {
                        BoatId = BoatEntity.Id,
                        FeatureId = featureId
                    };
                    _BoatFeaturerepository.Add(BoatFeatureEntity);
                }

            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTranscation();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTranscation();
                throw new Exception("Tekne özellikleri eklenirken bir hata oluştu.");
            }
            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Tekne başarıyla eklendi."
            };
        }

        public async Task<BoatDto> GetBoat(int id)
        {
            var boat = await _Boatrepository.GetAll(x => x.Id == id)
                .Select(x => new BoatDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    Length = x.Length,
                    Capacity = x.Capacity,
                    ManufactureYear = x.ManufactureYear,
                    BoatType = x.BoatType,
                    Features = x.BoatFeatures.Select(f => new BoatFeatureDto
                    {
                        Id = f.Id,
                        Title = f.Feature.Title,
                    }).ToList()
                }).FirstOrDefaultAsync();
            return boat;
        }


        public async Task<List<BoatDto>> GetAllBoats()
        {
            var boats = _Boatrepository.GetAll();

            if (boats == null || !boats.Any())
            {
                return null;
            }

            var boatDtos = boats.Select(boat => new BoatDto
            {
                Id = boat.Id,
                Name = boat.Name,
                Location = boat.Location,
                Length = boat.Length,
                Capacity = boat.Capacity,
                ManufactureYear = boat.ManufactureYear,
                BoatType = boat.BoatType,
                Features = boat.BoatFeatures.Select(f => new BoatFeatureDto
                {
                    Id = f.FeatureId,
                    Title = f.Feature.Title
                }).ToList()
            }).ToList();

            return boatDtos;
        }

        public async Task<ServiceMessage> UpdateBoatCapacity(int id, int changeBy)
        {
            var boat = _Boatrepository.Find(id);

            if (boat is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Tekne bulunamadı."
                };
            }

            boat.Capacity += changeBy;

            _Boatrepository.Update(boat);

            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage
                {
                    IsSucceed = true,
                    Message = "Tekne kapasitesi başarıyla güncellendi."
                };
            }
            catch (Exception)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Tekne kapasitesi güncellenirken bir hata oluştu."
                };
            }
        }


        public async Task<ServiceMessage> DeleteBoat(int id)
        {
            var boat = _Boatrepository.Find(id);
            if (boat == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Tekne bulunamadı."
                };
            }
            _Boatrepository.Delete(boat);
            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage
                {
                    IsSucceed = true,
                    Message = "Tekne başarıyla silindi."
                };
            }
            catch (Exception)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Tekne silinirken bir hata oluştu."
                };
            }
        }
        public async Task<ServiceMessage> UpdateBoat(UpdateBoatDto boat)
        {
            var boatEntity = _Boatrepository.Find(boat.Id);

            if (boatEntity == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Tekne bulunamadı."
                };
            }

            await _unitOfWork.BeginTranscation();

            boatEntity.Name = boat.Name;
            boatEntity.BoatType = boat.BoatType;
            boatEntity.Location = boat.Location;
            boatEntity.Length = boat.Length;
            boatEntity.ManufactureYear = boat.ManufactureYear;

            _Boatrepository.Update(boatEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                await _unitOfWork.RollBackTranscation();
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Tekne güncellenirken bir hata oluştu."
                };
            }

            var boatFeatures = _BoatFeaturerepository.GetAll()
                                              .AsEnumerable() // Bellekte sorgulama yapar
                                              .Where(x => x.BoatId == boatEntity.Id && x.IsDeleted == false)
                                              .ToList();

            foreach (var boatFeature in boatFeatures)
            {
                _BoatFeaturerepository.Delete(boatFeature, false);
            }

            if (boat.FeatureIds != null)
            {
                foreach (var featureId in boat.FeatureIds)
                {
                    var boatFeature = new BoatFeatureEntity
                    {
                        BoatId = boatEntity.Id,
                        FeatureId = featureId
                    };

                    _BoatFeaturerepository.Add(boatFeature);
                }
            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTranscation();
                return new ServiceMessage
                {
                    IsSucceed = true,
                    Message = "Tekne başarıyla güncellendi."
                };
            }
            catch
            {
                await _unitOfWork.RollBackTranscation();
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Tekne özellikleri güncellenirken bir hata oluştu."
                };
            }
        }
    }
}