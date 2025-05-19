using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IVeterinariosPresentacion
    {
        Task<List<Veterinarios>> Listar();
        Task<List<Veterinarios>> PorCodigo(Veterinarios? entidad);
        Task<Veterinarios?> Guardar(Veterinarios? entidad);
        Task<Veterinarios?> Modificar(Veterinarios? entidad);
        Task<Veterinarios?> Borrar(Veterinarios? entidad);
    }
}