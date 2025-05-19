using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IFormulas_MedicamentosAplicacion
    {
        void Configurar(string StringConexion);
        List<Formulas_Medicamentos> PorCodigo(Formulas_Medicamentos? entidad);
        List<Formulas_Medicamentos> Listar();
        Formulas_Medicamentos? Guardar(Formulas_Medicamentos? entidad);
        Formulas_Medicamentos? Modificar(Formulas_Medicamentos? entidad);
        Formulas_Medicamentos? Borrar(Formulas_Medicamentos? entidad);
    }
}