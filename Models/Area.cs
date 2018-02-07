using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoCursos.Models
{
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id  { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<Curso> Curso { get; set; }
    }
}