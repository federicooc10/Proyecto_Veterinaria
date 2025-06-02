using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Formulas>? Formulas { get; set; }
        DbSet<Formulas_Medicamentos>? Formulas_Medicamentos { get; set; }
        DbSet<Historiales_Clinicos>? Historiales_Clinicos { get; set; }
        DbSet<Mascotas>? Mascotas { get; set; }
        DbSet<Medicamentos>? Medicamentos { get; set; }
        DbSet<Razas>? Razas { get; set; }
        DbSet<Veterinarios>? Veterinarios { get; set; }
        DbSet<Auditorias> Auditorias { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<Usuarios> Usuarios { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}