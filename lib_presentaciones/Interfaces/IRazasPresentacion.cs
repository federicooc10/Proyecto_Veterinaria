using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IRazasPresentacion
    {
        Task<List<Razas>> Listar();
        Task<List<Razas>> PorCodigo(Razas? entidad);
        Task<Razas?> Guardar(Razas? entidad);
        Task<Razas?> Modificar(Razas? entidad);
        Task<Razas?> Borrar(Razas? entidad);
    }
}