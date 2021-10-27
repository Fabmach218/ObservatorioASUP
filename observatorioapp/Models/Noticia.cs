using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace observatorioapp.Models
{
    [Table("t_noticia")]
    public class Noticia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {get; set; }
        [Required(ErrorMessage = "COLOQUE TÍTULO A LA NOTICIA")]
        public string Titulo {get; set; }
        [Required(ErrorMessage = "COLOQUE EL LINK DE LA IMAGEN")]
        public string LinkImagen {get; set; }
        [Required(ErrorMessage = "COLOQUE EL LINK DE LA NOTICIA")]
        public string LinkNoticia {get; set; }
    }
}