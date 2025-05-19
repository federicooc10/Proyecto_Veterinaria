using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IHistoriales_ClinicosPresentacion
    {
        Task<List<Historiales_Clinicos>> Listar();
        Task<List<Historiales_Clinicos>> PorCodigo(Historiales_Clinicos? entidad);
        Task<Historiales_Clinicos?> Guardar(Historiales_Clinicos? entidad);
        Task<Historiales_Clinicos?> Modificar(Historiales_Clinicos? entidad);
        Task<Historiales_Clinicos?> Borrar(Historiales_Clinicos? entidad);
    }
}