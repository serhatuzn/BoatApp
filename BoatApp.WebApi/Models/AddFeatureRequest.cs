using System.ComponentModel.DataAnnotations;

namespace BoatApp.WebApi.Models
{
    public class AddFeatureRequest
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
