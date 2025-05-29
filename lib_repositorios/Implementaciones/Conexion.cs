using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Formulas>? Formulas { get; set; }
        public DbSet<Formulas_Medicamentos>? Formulas_Medicamentos { get; set; }
        public DbSet<Historiales_Clinicos>? Historiales_Clinicos { get; set; }
        public DbSet<Mascotas>? Mascotas { get; set; }
        public DbSet<Medicamentos>? Medicamentos { get; set; }
        public DbSet<Razas>? Razas { get; set; }
        public DbSet<Veterinarios>? Veterinarios { get; set; }
        public DbSet<Auditorias> Auditorias { get; set; } = null!;

    }
}