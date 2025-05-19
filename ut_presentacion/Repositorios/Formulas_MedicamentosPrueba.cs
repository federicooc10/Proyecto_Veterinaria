using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class Formulas_MedicamentosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Formulas_Medicamentos>? lista;
        private Formulas_Medicamentos? entidad;

        public Formulas_MedicamentosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Formulas_Medicamentos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Formulas_Medicamentos()!;
            this.iConexion!.Formulas_Medicamentos!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {

            this.entidad!.Cantidad = 99;
            var entry = this.iConexion.Entry<Formulas_Medicamentos>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Formulas_Medicamentos!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}