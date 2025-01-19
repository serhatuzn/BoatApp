using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatApp.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoatApp.Data.Entites
{
    public class BoatEntity : BaseEntity
    {
        public string Name { get; set; }
        public BoatType BoatType { get; set; }
        public string Location { get; set; }
        public double Length { get; set; } 
        public int Capacity { get; set; }
        public int ManufactureYear { get; set; } 

        public ICollection<BoatFeatureEntity> BoatFeatures { get; set; }
        public ICollection<ReservationEntity> Reservations { get; set; }
        public ICollection<BoatPortEntity> BoatPorts { get; set; } 
    }

    public class BoatConfiguration : BaseConfiguration<BoatEntity>
    {
        public override void Configure(EntityTypeBuilder<BoatEntity> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.BoatType)
                .IsRequired();

            builder.Property(x => x.ManufactureYear)
                .IsRequired()
                .HasDefaultValue(DateTime.Now.Year);

            builder.Property(x => x.Length)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.Capacity)
                .IsRequired()
                .HasDefaultValue(0);

            base.Configure(builder);
        }
    }
}
