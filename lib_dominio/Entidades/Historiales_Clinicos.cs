using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using lib_dominio.Entidades;

namespace lib_dominio.Entidades
{
    public class Historiales_Clinicos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public int Mascota { get; set; }
        public int Cliente { get; set; }
        public int Formula { get; set; }
        public int Veterinario { get; set; }
        [ForeignKey("Mascota")] public Mascotas? _Mascota { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Formula")] public Formulas? _Formula { get; set; }
        [ForeignKey("Veterinario")] public Veterinarios? _Veterinario { get; set; }

    }
}