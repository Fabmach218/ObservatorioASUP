using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace observatorioapp.Models
{
    [Table("t_universidad")]
    public class Universidad 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id")]
        public int Id {get; set; }

        [Column("nombre")]
        public string Nombre {get; set; }

        [Column("telefono")]
        public string Telefono {get; set; }

        [Column("direccion")]
        public string Direccion {get; set; }

        [Column("aniversario")]
        public DateTime Aniversario {get; set; }

        [Column("nomRec")]
        public string NombreRector {get; set; }

        [Column("apeRec")]
        public string ApellidoRector {get; set; }

        [Column("fecNacRec")]
        public DateTime FechaNacimientoRector {get; set; }

        [Column("corRec")]
        public string CorreoRector {get; set; }
    } 
}