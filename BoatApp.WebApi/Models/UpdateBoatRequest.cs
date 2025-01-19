using BoatApp.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BoatApp.WebApi.Models
{
    public class UpdateBoatRequest
    {
  
        public string Name { get; set; }
        public BoatType BoatType { get; set; }
        public string Location { get; set; }
        public double Length { get; set; }
        public int Capacity { get; set; }
        public int ManufactureYear { get; set; }
        public List<int> FeatureIds { get; set; }
    }
}
