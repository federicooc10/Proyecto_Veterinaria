using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IFormulas_MedicamentosPresentacion
    {
        Task<List<Formulas_Medicamentos>> Listar();
        Task<List<Formulas_Medicamentos>> PorCodigo(Formulas_Medicamentos? entidad);
        Task<Formulas_Medicamentos?> Guardar(Formulas_Medicamentos? entidad);
        Task<Formulas_Medicamentos?> Modificar(Formulas_Medicamentos? entidad);
        Task<Formulas_Medicamentos?> Borrar(Formulas_Medicamentos? entidad);
    }
}