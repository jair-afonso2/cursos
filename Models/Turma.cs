using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoCursos.Models
{
    public class Turma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdCurso { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        [Required]
        public string DiasSemana { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime HorarioInicio { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime HorarioFim { get; set; }

        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }
    }
}