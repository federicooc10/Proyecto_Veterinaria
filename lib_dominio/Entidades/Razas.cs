using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace lib_dominio.Entidades
{
    public class Razas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; }

        [JsonIgnore] 
        public List<Mascotas>? Mascotas { get; set; }
    }
}