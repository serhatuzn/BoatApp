using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoatApp.Data.Entites
{
    public class ReservationEntity : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GuessCount { get; set; }
        public int BoatId { get; set; }
        public int UserId { get; set; }

        public UserEntity User { get; set; }
        public BoatEntity Boat { get; set; }
    }

    public class ReservationConfiguration : BaseConfiguration<ReservationEntity>
    {
        public override void Configure(EntityTypeBuilder<ReservationEntity> builder)
        {
            builder.Property(x => x.StartDate)
            .IsRequired();  // Başlangıç tarihinin zorunlu olduğunu belirtiyoruz

            builder.Property(x => x.EndDate)
                .IsRequired();  // Bitiş tarihinin zorunlu olduğunu belirtiyoruz

            builder.Property(x => x.GuessCount)
                .IsRequired();  // Misafir sayısının zorunlu olduğunu belirtiyoruz

            base.Configure(builder);
        }
    }
}