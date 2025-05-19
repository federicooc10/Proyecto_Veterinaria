using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Formulas_Medicamentos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Formula { get; set; }
        public int Medicamento { get; set; }
        public int Cantidad { get; set; }
        [ForeignKey("Formula")]
        public Formulas? _Formula { get; set; }
        [ForeignKey("Medicamento")]
        public Medicamentos? _Medicamento { get; set; }

    }
}