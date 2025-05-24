using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace lib_dominio.Entidades
{
    public class Mascotas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Raza { get; set; }
        [ForeignKey("Raza")] public Razas? _Raza { get; set; }
        
        [JsonIgnore] 
        public List<Formulas>? Formulas { get; set; }
    }
}