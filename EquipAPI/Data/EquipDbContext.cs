using EquipsLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipAPI.Data
{
    public class EquipDbContext : DbContext
    {
        public DbSet<Equips> Equips { get; set; }

        public EquipDbContext(DbContextOptions<EquipDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Equips>().HasData(
              new
              {
                  EquipsId = Guid.NewGuid().ToString(),
                  EquipName = "Voidbow",
                  EquipCount = "1",
                  EquipType = "bow"
              },
              new
              {
                  EquipsId = Guid.NewGuid().ToString(),
                  EquipName = "Leafbow",
                  EquipCount = "15",
                  EquipType = "bow"
              },
              new
              {
                  EquipsId = Guid.NewGuid().ToString(),
                  EquipName = "Doombow",
                  EquipCount = "10",
                  EquipType = "bow"
              },
              new
              {
                  EquipsId = Guid.NewGuid().ToString(),
                  EquipName = "Coralbow",
                  EquipCount = "25",
                  EquipType = "bow"
              }
            );
        }
    }
}
