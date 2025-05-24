using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace lib_dominio.Entidades
{
    public class Medicamentos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; } = "";

        [JsonIgnore]
        public List<Formulas_Medicamentos>? Formulas_Medicamentos { get; set; }
    }
}