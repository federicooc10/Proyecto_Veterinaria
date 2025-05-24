using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace lib_dominio.Entidades
{
    public class Veterinarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Documento { get; set; }
        public string? Nombre { get; set; }

        [JsonIgnore]
        public List<Historiales_Clinicos>? Historiales_Clinicos { get; set; }
    }
}