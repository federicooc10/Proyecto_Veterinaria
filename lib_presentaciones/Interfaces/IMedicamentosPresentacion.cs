using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IMedicamentosPresentacion
    {
        Task<List<Medicamentos>> Listar();
        Task<List<Medicamentos>> PorNombre(Medicamentos? entidad);
        Task<Medicamentos?> Guardar(Medicamentos? entidad);
        Task<Medicamentos?> Modificar(Medicamentos? entidad);
        Task<Medicamentos?> Borrar(Medicamentos? entidad);
    }
}