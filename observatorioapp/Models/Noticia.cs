using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace observatorioapp.Models
{
    [Table("t_noticia")]
    public class Noticia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {get; set; }
        public string Titulo {get; set; }
        public string LinkImagen {get; set; }
        public string LinkNoticia {get; set; }
    }
}