using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets
        // Van Representar tablas en la base de datos.
        public DbSet<Cancha> Cancha { get; set; }
        public DbSet<TipoCancha> TipoCancha { get; set; }
        public DbSet<Actividad> Actividad { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Usuario> Usuario { get; set; } 
        public DbSet<Asistencia> Asistencia { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Mantenimiento> Mantenimiento { get; set; }
        public DbSet<Cobro> Cobro { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Reembolso> Reembolso { get; set; }
        public DbSet<Descuento> Descuento { get; set; }
        public DbSet<Partido> Partido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- Configuración de Cancha ---
            modelBuilder.Entity<Cancha>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Numero).IsRequired();
                entity.Property(c => c.Estado).HasDefaultValue(EstadoCancha.Disponible).IsRequired();

                entity.HasOne(c => c.TipoCancha)
                      .WithMany(tc => tc.Canchas)
                      .HasForeignKey(c => c.TipoCanchaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- Configuración de TipoCancha ---
            modelBuilder.Entity<TipoCancha>(entity =>
            {
                entity.HasKey(tc => tc.Id);
                entity.Property(tc => tc.Id).ValueGeneratedOnAdd();
                entity.Property(tc => tc.Nombre).HasMaxLength(100).IsRequired();
            });

            // --- Configuración de Actividad ---
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).ValueGeneratedOnAdd();

                entity.Property(a => a.Nombre).HasMaxLength(100).IsRequired();
                entity.Property(a => a.Fecha).IsRequired();
                entity.Property(a => a.CupoMaximo).IsRequired();

                entity.HasOne(a => a.Cancha)
                      .WithMany(c => c.Actividades)
                      .HasForeignKey(a => a.CanchaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- Configuración de Persona (y Herencia TPH) ---
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();

                entity.Property(p => p.Nombre).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Edad).IsRequired();
                entity.Property(p => p.Direccion).HasMaxLength(200).IsRequired();
                entity.Property(p => p.Email).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Telefono).HasMaxLength(20).IsRequired();

                // Fundamental para que Persona y Usuario compartan tabla sin romper la BD.
                entity.HasDiscriminator<string>("TipoPersona")
                      .HasValue<Persona>("PersonaBase")
                      .HasValue<Usuario>("Usuario")
                      .HasValue<Profesor>("Profesor")
                      .HasValue<Entrenador>("Entrenador");
            });

            // --- Configuración de Asistencia ---
            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.HasKey(asist => asist.Id);
                entity.Property(asist => asist.Id).ValueGeneratedOnAdd();
                entity.Property(asist => asist.FechaHorario).IsRequired();

                // Relación con Persona
                entity.HasOne(asist => asist.Persona)
                      .WithMany()
                      .HasForeignKey(asist => asist.PersonaId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relación con Actividad
                entity.HasOne(asist => asist.Actividad)
                      .WithMany()
                      .HasForeignKey(asist => asist.ActividadId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- Configuración de Reserva ---
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(r => r.Id); 
                entity.Property(r => r.Id).ValueGeneratedOnAdd();

                entity.Property(r => r.Fecha).IsRequired();
                entity.Property(r => r.HoraInicio).IsRequired();
                entity.Property(r => r.HoraFin).IsRequired();
                entity.Property(r => r.Estado).IsRequired();

                // Relación con Cancha
                entity.HasOne(r => r.Cancha)
                      .WithMany(c => c.Reservas)
                      .HasForeignKey(r => r.CanchaId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relación con Usuario
                entity.HasOne(r => r.Usuario)
                      .WithMany(u => u.Reservas)
                      .HasForeignKey(r => r.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- Configuración de Mantenimiento ---
            modelBuilder.Entity<Mantenimiento>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Id).ValueGeneratedOnAdd();

                entity.Property(m => m.Fecha).IsRequired();
                entity.Property(m => m.HoraInicio).IsRequired();
                entity.Property(m => m.HoraFin).IsRequired();
                entity.Property(m => m.Motivo).HasMaxLength(250).IsRequired();
                entity.Property(m => m.Estado).IsRequired();

                // Relación con Cancha
                entity.HasOne(m => m.Cancha)
                      .WithMany(c => c.Mantenimientos)
                      .HasForeignKey(m => m.CanchaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- Configuración de Cobro ---
            modelBuilder.Entity<Cobro>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();

                entity.Property(c => c.MedioPago).IsRequired();
                entity.Property(c => c.MontoOriginal).IsRequired();
                entity.Property(c => c.MontoFinal).IsRequired();
                entity.Property(c => c.Estado).IsRequired();
            });

            // --- Configuración de Factura ---
            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(f => f.id);
                entity.Property(f => f.id).ValueGeneratedOnAdd();

                entity.Property(f => f.NumeroComprobante).IsRequired();
                entity.Property(f => f.FechaEmision).IsRequired();

                entity.HasOne(f => f.Cobro)
                      .WithOne(c => c.Factura)
                      .HasForeignKey<Factura>(f => f.CobroId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- Configuración de Reembolso ---
            modelBuilder.Entity<Reembolso>(entity =>
            {
                entity.HasKey(r => r.Id); 
                entity.Property(r => r.Id).ValueGeneratedOnAdd();

                entity.Property(r => r.Motivo).IsRequired();
                entity.Property(r => r.Monto).IsRequired();
                entity.Property(r => r.Fecha).IsRequired();

                // Relación explícita con Cobro
                entity.HasOne<Cobro>()
                      .WithMany()
                      .HasForeignKey(r => r.CobroId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- Configuración de Descuento ---
            modelBuilder.Entity<Descuento>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Id).ValueGeneratedOnAdd();

                entity.Property(d => d.Nombre).IsRequired();
                entity.Property(d => d.Porcentaje).IsRequired();
                entity.Property(d => d.EstadoActivo).IsRequired();
            });

            // --- Configuración de Partido ---
            modelBuilder.Entity<Partido>(entity =>
            {
                entity.HasKey(p => p.Id); 
                entity.Property(p => p.Id).ValueGeneratedOnAdd();

                entity.Property(p => p.Fecha).IsRequired();
                entity.Property(p => p.EquipoLocal).IsRequired();
                entity.Property(p => p.EquipoVisitante).IsRequired();
                entity.Property(p => p.GolesLocal).IsRequired();
                entity.Property(p => p.GolesVisitante).IsRequired();
                entity.Property(p => p.Resultado).IsRequired();
            });



            // --- Carga de datos iniciales (Seed Data) --- //

            // 1. IDs para TipoCancha
            var idFutbol5 = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var idFutbol11 = Guid.Parse("22222222-2222-2222-2222-222222222222");

            // 2. IDs para Canchas
            var idCancha1 = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var idCancha2 = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var idCancha3 = Guid.Parse("55555555-5555-5555-5555-555555555555");

            // 3. IDs para Actividades
            var idActividad1 = Guid.Parse("66666666-6666-6666-6666-666666666666");

            // 4. IDs para Personas/Usuarios y Finanzas
            var idPersona1 = Guid.Parse("88888888-8888-8888-8888-888888888888");
            var idCobro1 = Guid.Parse("BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB");
            var idFactura1 = Guid.Parse("CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCCCC");

            var tipoCanchaData = new TipoCancha[]
            {
               new TipoCancha { Id = idFutbol5, Nombre = "Futbol 5", Superficie = 100, Capacidad = 10, DuracionMax = 2, PrecioBaseHora = 5000 },
               new TipoCancha { Id = idFutbol11, Nombre = "Futbol 11", Superficie = 100, Capacidad = 22, DuracionMax = 2, PrecioBaseHora = 5000 }
            };

            var canchaData = new Cancha[]
            {
                new Cancha { Id = idCancha1, Numero = 1, Estado = EstadoCancha.Disponible, TipoCanchaId = idFutbol5 },
                new Cancha { Id = idCancha2, Numero = 2, Estado = EstadoCancha.Disponible, TipoCanchaId = idFutbol5 },
                new Cancha { Id = idCancha3, Numero = 3, Estado = EstadoCancha.Ocupada, TipoCanchaId = idFutbol11 }
            };

            var actividadData = new Actividad[]
            {
                new Actividad { Id = idActividad1, Nombre = "Turno Fijo Amigos", Fecha = new DateTime(2026, 6, 1, 20, 0, 0), CupoMaximo = 10, CanchaId = idCancha1 },
                new Actividad { Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), Nombre = "Entrenamiento Escuelita", Fecha = new DateTime(2026, 6, 2, 18, 0, 0), CupoMaximo = 22, CanchaId = idCancha3 }
            };

            var usuarioData = new Usuario[]
            {
                new Usuario { Id = idPersona1, Nombre = "Luciano Alvarez", Edad = 23, Direccion = "Calle Falsa 123", Email = "luciano@ejemplo.com", Telefono = "1234567890" }
            };

            var asistenciaData = new Asistencia[]
            {
                new Asistencia { Id = Guid.Parse("99999999-9999-9999-9999-999999999999"), FechaHorario = new DateTime(2026, 6, 1, 20, 0, 0), PersonaId = idPersona1, ActividadId = idActividad1 }
            };

            var reservaData = new Reserva[]
            {
                new Reserva { Id = 1, Fecha = new DateTime(2026, 6, 1), HoraInicio = new TimeSpan(20, 0, 0), HoraFin = new TimeSpan(22, 0, 0), Estado = EstadoReserva.Confirmada, CanchaId = idCancha1, UsuarioId = idPersona1 }
            };

            var mantenimientoData = new Mantenimiento[]
            {
                new Mantenimiento { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), CanchaId = idCancha2, Fecha = new DateTime(2026, 6, 3), HoraInicio = new DateTime(2026, 6, 3, 8, 0, 0), HoraFin = new DateTime(2026, 6, 3, 12, 0, 0), Motivo = "Mantenimiento preventivo", Estado = true }
            };

            var cobroData = new Cobro[]
            {
                new Cobro { Id = idCobro1, ReferenciaId = Guid.Parse("DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDDDD"), TipoReferencia = TipoReferencia.Reserva, Fecha = new TimeSpan(14, 30, 0), MedioPago = "Tarjeta de Crédito", MontoOriginal = 10000, MontoFinal = 10000, Estado = EstadoCobro.Confirmada }
            };

            var facturaData = new Factura[]
            {
                new Factura { id = idFactura1, NumeroComprobante = 10001, FechaEmision = new DateTime(2026, 6, 1, 14, 35, 0), CobroId = idCobro1 }
            };

            var reembolsoData = new Reembolso[]
            {
                new Reembolso { Id = 1, CobroId = idCobro1, Motivo = "Cancelación de reserva", Monto = 10000, Fecha = new DateTime(2026, 6, 5, 10, 0, 0) }
            };

            var descuentoData = new Descuento[]
            {
                new Descuento { Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), Nombre = "Descuento de Verano", Porcentaje = 10, EstadoActivo = true }
            };

            var partidoData = new Partido[]
            {
                new Partido { Id = 1, Fecha = new DateTime(2026, 6, 5, 16, 0, 0), EquipoLocal = "Equipo A", EquipoVisitante = "Equipo B", GolesLocal = 2, GolesVisitante = 1, Resultado = "Victoria Local" }
            };

            // --- Inyección de datos ---
            modelBuilder.Entity<TipoCancha>().HasData(tipoCanchaData);
            modelBuilder.Entity<Cancha>().HasData(canchaData);
            modelBuilder.Entity<Actividad>().HasData(actividadData);
            modelBuilder.Entity<Usuario>().HasData(usuarioData);
            modelBuilder.Entity<Asistencia>().HasData(asistenciaData);
            modelBuilder.Entity<Reserva>().HasData(reservaData);
            modelBuilder.Entity<Mantenimiento>().HasData(mantenimientoData);
            modelBuilder.Entity<Cobro>().HasData(cobroData);
            modelBuilder.Entity<Factura>().HasData(facturaData);
            modelBuilder.Entity<Reembolso>().HasData(reembolsoData);
            modelBuilder.Entity<Descuento>().HasData(descuentoData);
            modelBuilder.Entity<Partido>().HasData(partidoData);
        }
    }
}