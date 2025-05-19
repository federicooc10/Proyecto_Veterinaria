namespace lib_dominio.Entidades
{
    public class Medicamentos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public List<Formulas_Medicamentos>? Formulas_Medicamentos { get; set; }
    }
}