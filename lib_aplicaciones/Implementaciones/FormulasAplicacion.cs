using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class FormulasAplicacion : IFormulasAplicacion
    {
        private IConexion? IConexion = null;
        private IAuditoriasAplicacion? IAuditoriasAplicacion = null;

        public FormulasAplicacion(IConexion iConexion, IAuditoriasAplicacion iAuditoriasAplicacion)
        {
            this.IConexion = iConexion;
            this.IAuditoriasAplicacion = iAuditoriasAplicacion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Formulas? Borrar(Formulas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Formulas!.Remove(entidad);
            this.IConexion.SaveChanges();
            this.IAuditoriasAplicacion!.Configurar(this.IConexion.StringConexion!);
            this.IAuditoriasAplicacion!.Guardar(new Auditorias
            {
                Usuario = "Veterinario",
                Entidad = "Formulas",
                Operacion = "Borrar",
                Fecha = DateTime.Now
            });
            return entidad;
        }

        public Formulas? Guardar(Formulas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Formulas!.Add(entidad);
            this.IConexion.SaveChanges();
            this.IAuditoriasAplicacion!.Configurar(this.IConexion.StringConexion!);
            this.IAuditoriasAplicacion!.Guardar(new Auditorias
            {
                Usuario = "Veterinario",
                Entidad = "Formulas",
                Operacion = "Guardar",
                Fecha = DateTime.Now
            });
            return entidad;
        }

        public List<Formulas> Listar()
        {
            return this.IConexion!.Formulas!
                .Take(20)
                .Include(x => x._Mascota)
                .ToList();
        }

        public List<Formulas> PorCodigo(Formulas? entidad)
        {
            return this.IConexion!.Formulas!
                .Where(x => x.Codigo!.Contains(entidad!.Codigo!))
                .Include(x => x._Mascota)
                .ToList();
        }

        public Formulas? Modificar(Formulas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Formulas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            this.IAuditoriasAplicacion!.Configurar(this.IConexion.StringConexion!);
            this.IAuditoriasAplicacion!.Guardar(new Auditorias
            {
                Usuario = "Veterinario",
                Entidad = "Formulas",
                Operacion = "Modificar",
                Fecha = DateTime.Now
            });
            return entidad;
        }
    }
}
