using Application.Interfaces.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Commands
{
    public class CommandReserva : ICommandReserva
    {
        private readonly AppDbContext _context;

        public CommandReserva(AppDbContext context)
        {
            _context = context;
        }

        public async Task AgregarAsync(Reserva reserva)
        {
            await _context.Reserva.AddAsync(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task ModificarAsync(Reserva reserva)
        {
            Reserva? existente = await _context.Reserva.FirstOrDefaultAsync(r => r.Id == reserva.Id);
            if (existente == null) return;

            existente.CanchaId   = reserva.CanchaId;
            existente.UsuarioId  = reserva.UsuarioId;
            existente.Fecha      = reserva.Fecha;
            existente.HoraInicio = reserva.HoraInicio;
            existente.HoraFin    = reserva.HoraFin;
            existente.Estado     = reserva.Estado;

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            Reserva? eliminar = await _context.Reserva.FirstOrDefaultAsync(r => r.Id == id);
            if (eliminar == null) return;

            _context.Reserva.Remove(eliminar);
            await _context.SaveChangesAsync();
        }
    }
}
