using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class VeterinariosAplicacion : IVeterinariosAplicacion
    {
        private IConexion? IConexion = null;

        public VeterinariosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Veterinarios? Borrar(Veterinarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Veterinarios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Veterinarios? Guardar(Veterinarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Veterinarios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Veterinarios> Listar()
        {
            return this.IConexion!.Veterinarios!.Take(20).ToList();
        }

        public List<Veterinarios> PorCodigo(Veterinarios? entidad)
        {
            return this.IConexion!.Veterinarios!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();
        }

        public Veterinarios? Modificar(Veterinarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Veterinarios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
