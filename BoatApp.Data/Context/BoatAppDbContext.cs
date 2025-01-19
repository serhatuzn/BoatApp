using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatApp.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace BoatApp.Data.Context
{
    public class BoatAppDbContext : DbContext
    {
        public BoatAppDbContext(DbContextOptions<BoatAppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoatFeatureConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FeatureConfiguration());
            modelBuilder.ApplyConfiguration(new BoatPortConfiguration());
            modelBuilder.ApplyConfiguration(new BoatConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());


            modelBuilder.Entity<SettingsEntity>().HasData(
                new SettingsEntity
                {
                    Id = 1,
                    MaintenenceMode = false
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<FeatureEntity> Features => Set<FeatureEntity>();
        public DbSet<BoatEntity> Boats => Set<BoatEntity>();
        public DbSet<BoatFeatureEntity> BoatFeatures => Set<BoatFeatureEntity>();
        public DbSet<PortEntity> Ports => Set<PortEntity>();
        public DbSet<BoatPortEntity> BoatPorts => Set<BoatPortEntity>();
        public DbSet<ReservationEntity> Reservations => Set<ReservationEntity>();
        public DbSet<SettingsEntity> Settings => Set<SettingsEntity>();



    }
}
