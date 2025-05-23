using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Clientes? Clientes()
        {
            return new Clientes() 
            { 
                Documento = 123456687, 
                Nombre = "Test-" + DateTime.Now.ToString("yyyyMMddhhmmss")
            };
        }

        public static Razas? Razas()
        {
            return new Razas()
            {
                Nombre = "Test-" + DateTime.Now.ToString("yyyyMMddhhmmss")
            };
        }

        public static Formulas? Formulas()
        {
            return new Formulas()
            {
                Codigo = "Test-" + DateTime.Now.ToString("yyyyMMddhhmmss"),
                Mascota = 1,
                
            };
        }

        public static Historiales_Clinicos? Historiales_Clinicos()
        {
            return new Historiales_Clinicos()
            {
                Codigo = "Test-" + DateTime.Now.ToString("yyyyMMddhhmmss"),
                Fecha = DateTime.Now,
                Cliente=1,
                Formula=1,
                Veterinario=1,
            };
        }

        public static Mascotas? Mascotas()
        {
            return new Mascotas()
            {
                Nombre= "Test-" + DateTime.Now.ToString("yyyyMMddhhmmss"),
                Raza = 2
            };
        }

        public static Medicamentos? Medicamentos()
        {
            return new Medicamentos()
            {
                Nombre = "Test-" + DateTime.Now.ToString("yyyyMMddhhmmss")
            };
        }

        public static Veterinarios? Veterinarios()
        {
            return new Veterinarios()
            {
                Documento= 1235678,
                Nombre = "Test-" + DateTime.Now.ToString("yyyyMMddhhmmss")
            };
        }

        public static Formulas_Medicamentos? Formulas_Medicamentos()
        {
            return new Formulas_Medicamentos()
            {
                Formula = 1,
                Medicamento = 2,
                Cantidad = 2,
              
            };
        }
    }
}