using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        // To do: Agregar DbSet de todas las entidades
        public DbSet<Cancha> Cancha { get; set; }

        // ...public DbSet<TipoCancha> TipoCancha { get; set; }




        // To do: Crear modelBuilder de todas las entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cancha>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Numero).IsRequired();
                entity.Property(c => c.Estado).HasDefaultValue(EstadoCancha.Disponible).IsRequired();

            });

            // To do: Crear modelBuilder de todas las entidades
        }


    }
}
