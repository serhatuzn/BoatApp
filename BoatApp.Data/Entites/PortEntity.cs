using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatApp.Data.Entites
{
    public class PortEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<BoatPortEntity> BoatPorts { get; set; } // Köprü tablo ilişkisi
    }
}
