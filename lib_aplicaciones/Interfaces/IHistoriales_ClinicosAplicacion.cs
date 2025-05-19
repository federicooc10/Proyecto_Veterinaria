using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IHistoriales_ClinicosAplicacion
    {
        void Configurar(string StringConexion);
        List<Historiales_Clinicos> PorCodigo(Historiales_Clinicos? entidad);
        List<Historiales_Clinicos> Listar();
        Historiales_Clinicos? Guardar(Historiales_Clinicos? entidad);
        Historiales_Clinicos? Modificar(Historiales_Clinicos? entidad);
        Historiales_Clinicos? Borrar(Historiales_Clinicos? entidad);
    }
}