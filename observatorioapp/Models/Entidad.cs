using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace observatorioapp.Models
{
    [Table("t_entidad")]
    public class Entidad
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {get; set; }
        [Required(ErrorMessage = "INGRESE EL NOMBRE DE LA ENTIDAD")]
        public string Nombre {get; set; }
        [Required(ErrorMessage = "INGRESE EL CORREO DE LA ENTIDAD")]
        public string Correo {get; set; }
        [Required(ErrorMessage = "INGRESE EL TELÉFONO DE LA ENTIDAD")]
        public int Telefono {get; set; }
        public List<Normativa> listaNormativas {get; set; }
    }
}