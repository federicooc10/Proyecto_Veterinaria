
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using lib_dominio.Entidades;

namespace lib_dominio.Entidades


{

    public class Formulas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Codigo { get; set; } = "";
        public int Mascota { get; set; }
        [ForeignKey("Mascota")] public Mascotas? _Mascota { get; set; }

        [JsonIgnore]
        public List<Formulas_Medicamentos>? Formulas_Medicamentos { get; set; }
        [JsonIgnore]
        public List<Historiales_Clinicos>? Historiales_Clinicos { get; set; }
    }
}