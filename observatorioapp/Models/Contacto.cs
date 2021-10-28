using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace observatorioapp.Models
{
    [Table("t_contacto")]
    public class Contacto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {get; set; }
        [Required(ErrorMessage = "INGRESE SU NOMBRE")]
        public string Nombre {get; set; }
        [Required(ErrorMessage = "INGRESE SU EMAIL")]
        public string Correo {get; set; }
        [Required(ErrorMessage = "INGRESE SU CELULAR")]
        public string Celular {get; set; }
        [Required(ErrorMessage = "INGRESE SU MENSAJE")]
        public string Mensaje {get; set; }
        [Required]
        public DateTime Fecha {get; set; }
    }
}