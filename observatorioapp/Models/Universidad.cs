using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace observatorioapp.Models
{
    [Table("t_universidad")]
    public class Universidad 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id {get; set; }

        [Required(ErrorMessage = "COLOQUE NOMBRE DE LA UNIVERSIDAD")]
        public string nombre {get; set; }

        [Required(ErrorMessage = "COLOQUE TELÉFONO DE LA UNIVERSIDAD")]
        public string telefono {get; set; }

        [Required(ErrorMessage = "COLOQUE DIRECCIÓN DE LA UNIVERSIDAD")]
        public string direccion {get; set; }

        [Required(ErrorMessage = "COLOQUE ANIVERSARIO DE LA UNIVERSIDAD")]
        public DateTime aniversario {get; set; }

        [Required(ErrorMessage = "COLOQUE NOMBRE DEL RECTOR")]
        public string nombrerector {get; set; }

        [Required(ErrorMessage = "COLOQUE APELLIDO DEL RECTOR")]
        public string apellidorector {get; set; }

        [Required(ErrorMessage = "COLOQUE FECHA DE NACIMIENTO DEL RECTOR")]
        public DateTime fechanacimientorector {get; set; }

        [Required(ErrorMessage = "COLOQUE CORREO ELECTRÓNICO DEL RECTOR")]
        public string correorector {get; set; }
    } 
}