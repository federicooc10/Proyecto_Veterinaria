using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class MascotasAplicacion : IMascotasAplicacion
    {
        private IConexion? IConexion = null;

        public MascotasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Mascotas? Borrar(Mascotas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Mascotas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Mascotas? Guardar(Mascotas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Mascotas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Mascotas> Listar()
        {
            return this.IConexion!.Mascotas!
                .Take(20)
                .Include(x => x._Raza)
                .ToList();
        }

        public List<Mascotas> PorNombre(Mascotas? entidad)
        {
            return this.IConexion!.Mascotas!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .Include(x => x._Raza)
                .ToList();
        }

        public Mascotas? Modificar(Mascotas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Mascotas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
