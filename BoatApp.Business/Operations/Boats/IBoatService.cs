using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatApp.Business.Operations.Boats.Dtos;
using BoatApp.Business.Types;

namespace BoatApp.Business.Operations.NewFolder
{
    public interface IBoatService
    {
        Task<ServiceMessage> AddBoatDto(AddBoatDto BoatDto);
        Task<BoatDto> GetBoat(int id);
        Task<List<BoatDto>> GetAllBoats();
        Task<ServiceMessage> UpdateBoatCapacity(int id, int changeBy);
        Task<ServiceMessage> DeleteBoat(int id);
        Task<ServiceMessage> UpdateBoat(UpdateBoatDto boat);
    }
}
