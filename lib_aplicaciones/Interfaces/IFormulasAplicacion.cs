using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IFormulasAplicacion
    {
        void Configurar(string StringConexion);
        List<Formulas> PorCodigo(Formulas? entidad);
        List<Formulas> Listar();
        Formulas? Guardar(Formulas? entidad);
        Formulas? Modificar(Formulas? entidad);
        Formulas? Borrar(Formulas? entidad);
    }
}