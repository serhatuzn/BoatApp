using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BoatApp.Business.Operations.Feature.Dtos;
using BoatApp.Business.Types;
using BoatApp.Data.Entites;
using BoatApp.Data.Repositories;
using BoatApp.Data.UnitOfWork;

namespace BoatApp.Business.Operations.Feature
{
    public class FeatureManager : IFeatureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<FeatureEntity> _repository;

        public FeatureManager(IUnitOfWork unitOfWork, IRepository<FeatureEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<ServiceMessage> AddFeature(AddFeatureDto featureDto)
        {
            var hasFeature = _repository.GetAll(x => x.Title == featureDto.Title).Any();
            if (hasFeature) 
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu özellik zaten mevcut."
                };
            }

            var featureEntity = new FeatureEntity
            {
                Title = featureDto.Title,
                Description = featureDto.Description
            };

            _repository.Add(featureEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception) 
            {
                throw new Exception("Özellik eklenirken bir hata oluştu.");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Özellik başarıyla eklendi."
            };
        }
    }
}













