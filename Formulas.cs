namespace lib_dominio.Entidades
{

    public class Formulas
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public int Mascota { get; set; }
        public Mascotas? _Mascota { get; set; }
        public List<Formulas_Medicamentos>? Formulas_Medicamentos { get; set; }
        public List<Historiales_Clinicos>? Historiales_Clinicos { get; set; }
    }
}