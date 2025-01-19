using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatApp.Data.Enums;

namespace BoatApp.Business.Operations.Boats.Dtos
{
    public class AddBoatDto
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
