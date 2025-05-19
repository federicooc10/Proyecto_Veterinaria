using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IVeterinariosAplicacion
    {
        void Configurar(string StringConexion);
        List<Veterinarios> PorNombre(Veterinarios? entidad);
        List<Veterinarios> Listar();
        Veterinarios? Guardar(Veterinarios? entidad);
        Veterinarios? Modificar(Veterinarios? entidad);
        Veterinarios? Borrar(Veterinarios? entidad);
    }
}