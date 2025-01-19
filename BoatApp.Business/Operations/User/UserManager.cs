using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatApp.Business.DataProtection;
using BoatApp.Business.Operations.User.Dtos;
using BoatApp.Business.Types;
using BoatApp.Data.Entites;
using BoatApp.Data.Repositories;
using BoatApp.Data.UnitOfWork;

namespace BoatApp.Business.Operations.User
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IDataProtection _dataProtection;

        public UserManager(IUnitOfWork unitOfWork, IRepository<UserEntity> userRepository, IDataProtection dataProtection)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _dataProtection = dataProtection;
        }
        public async Task<ServiceMessage> AddUser(AddUserDto user)
        {
            var hasMail = _userRepository.GetAll(x => x.Email == user.Email);

            if (hasMail.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu mail adresi zaten kullanılmaktadır."
                };

            }
            var userEntity = new UserEntity
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = _dataProtection.Protect(user.Password),
                PhoneNumber = user.PhoneNumber
            };
            _userRepository.Add(userEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage
                {
                    IsSucceed = true,
                    Message = "Kullanıcı başarıyla eklendi."
                };
            }
            catch (Exception ex)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = ex.Message
                };
            }
        }

        public ServiceMessage<UserInfoDto> LoginUser(LoginUserDto loginDto)
        {
            var user = _userRepository.Get(x => x.Email == loginDto.Email);
            if (user == null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı adı veya şifre hatalı."
                };
            }
            
            var unProtectedPassword = _dataProtection.Unprotect(user.Password);

            if (unProtectedPassword == loginDto.Password)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = true,
                    Data = new UserInfoDto
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserType = user.UserType
                    }
                };
            }
            else
            return new ServiceMessage<UserInfoDto>
            {
                IsSucceed = false,
                Message = "Kullanıcı adı veya şifre hatalı."
            };
        }
    }
}
