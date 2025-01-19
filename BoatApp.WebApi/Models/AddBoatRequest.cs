using System.ComponentModel.DataAnnotations;
using BoatApp.Data.Enums;

namespace BoatApp.WebApi.Models
{
    public class AddBoatRequest
    {
        [Required]
        public string Name { get; set; }
        public BoatType BoatType { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public double Length { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int ManufactureYear { get; set; }

        public List<int> FeatureIds { get; set; }
    }
}
