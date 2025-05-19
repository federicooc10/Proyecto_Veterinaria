using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IRazasAplicacion
    {
        void Configurar(string StringConexion);
        List<Razas> PorCodigo(Razas? entidad);
        List<Razas> Listar();
        Razas? Guardar(Razas? entidad);
        Razas? Modificar(Razas? entidad);
        Razas? Borrar(Razas? entidad);
    }
}