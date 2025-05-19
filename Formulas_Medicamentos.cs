namespace lib_dominio.Entidades
{
    public class Formulas_Medicamentos
    {
        public int Id { get; set; }
        public int Formula { get; set; }
        public int Medicamento { get; set; }
        public int Cantidad { get; set; }
        public Formulas? _Formula { get; set; }
        public Medicamentos? _Medicamento { get; set; }

    }
}