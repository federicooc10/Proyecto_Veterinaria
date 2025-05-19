using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IMedicamentosAplicacion
    {
        void Configurar(string StringConexion);
        List<Medicamentos> PorCodigo(Medicamentos? entidad);
        List<Medicamentos> Listar();
        Medicamentos? Guardar(Medicamentos? entidad);
        Medicamentos? Modificar(Medicamentos? entidad);
        Medicamentos? Borrar(Medicamentos? entidad);
    }
}