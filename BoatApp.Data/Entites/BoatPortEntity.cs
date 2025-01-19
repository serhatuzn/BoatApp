using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoatApp.Data.Entites
{
    public class BoatPortEntity : BaseEntity
    {
        public int BoatId { get; set; }
        public int PortId { get; set; }

        public BoatEntity Boat { get; set; }
        public PortEntity Port { get; set; }
    }

    public class BoatPortConfiguration : BaseConfiguration<BoatPortEntity>
    {
        public override void Configure(EntityTypeBuilder<BoatPortEntity> builder)
        {

            builder.Ignore(x => x.Id);

            builder.HasKey("BoatId", "PortId");

            base.Configure(builder);
        }
    }
}
