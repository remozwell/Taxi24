using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24RestAPI.Models;

namespace Taxi24RestAPI.Data
{
    public class TaxiContext : DbContext
    {
        public TaxiContext(DbContextOptions<TaxiContext> options) : base(options)
        {

        }


        public DbSet<ConductorModel> Tbl_Conductores { get; set; }
        public DbSet<PasajeroModel> Tbl_Pasajeros { get; set; }
        public DbSet<ViajeModel> Tbl_Viajes { get; set; }
        public DbSet<FacturaModel> Tbl_Facturas { get; set; }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConductorModel>().ToTable("Tbl_Conductores");
            modelBuilder.Entity<PasajeroModel>().ToTable("Tbl_Pasajeros");
            modelBuilder.Entity<ViajeModel>().ToTable("Tbl_Viajes");
            modelBuilder.Entity<FacturaModel>().ToTable("Tbl_Facturas");
        }
    }
}
