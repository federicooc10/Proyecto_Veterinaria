namespace lib_dominio.Entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string? Nombre { get; set; }
        public List<Historiales_Clinicos>? Historiales_Clinicos { get; set; }
    }
}