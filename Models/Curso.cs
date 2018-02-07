using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoCursos.Models
{
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdArea { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<Turma> Turma { get; set; }

        [ForeignKey("IdArea")]
        public Area Area { get; set; }
    }
}