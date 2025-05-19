using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IFormulasPresentacion
    {
        Task<List<Formulas>> Listar();
        Task<List<Formulas>> PorCodigo(Formulas? entidad);
        Task<Formulas?> Guardar(Formulas? entidad);
        Task<Formulas?> Modificar(Formulas? entidad);
        Task<Formulas?> Borrar(Formulas? entidad);
    }
}