using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatApp.Business.Operations.User.Dtos;
using BoatApp.Business.Types;

namespace BoatApp.Business.Operations.User
{
    public interface IUserService
    {
        Task<ServiceMessage> AddUser(AddUserDto user); // Async çünkü unitofwork kullanılacak

        ServiceMessage<UserInfoDto> LoginUser(LoginUserDto loginDto);
    }
}
