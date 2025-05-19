namespace lib_dominio.Entidades
{
    public class Razas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public List<Mascotas>? Mascotas { get; set; }
    }
}