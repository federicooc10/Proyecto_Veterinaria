using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class Formulas_MedicamentosAplicacion : IFormulas_MedicamentosAplicacion
    {
        private IConexion? IConexion = null;

        public Formulas_MedicamentosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Formulas_Medicamentos? Borrar(Formulas_Medicamentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Formulas_Medicamentos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Formulas_Medicamentos? Guardar(Formulas_Medicamentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Formulas_Medicamentos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Formulas_Medicamentos> Listar()
        {
            return this.IConexion!.Formulas_Medicamentos!
                .Take(20)
                .Include(x => x._Formula)
                .Include(x => x._Medicamento)
                .ToList();
        }

        public List<Formulas_Medicamentos> PorId(Formulas_Medicamentos? entidad)
        {
            return this.IConexion!.Formulas_Medicamentos!
                .Where(x => x.Id! == entidad!.Id!)
                .Include(x => x._Formula)
                .Include(x => x._Medicamento)
                .ToList();
        }

        public Formulas_Medicamentos? Modificar(Formulas_Medicamentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Formulas_Medicamentos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
