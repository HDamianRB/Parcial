using CoWorkSpace.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CoWorkSpace.Back.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        // Definición de DbSets para cada entidad
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Membresia> Membresias { get; set; }
        public DbSet<EspacioTrabajo> EspaciosTrabajo { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<EventoMiembro> EventosMiembros { get; set; }
        public DbSet<Recurso> Recursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}