using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace observatorioapp.Models
{

    [Table("t_normativa")]
    public class Normativa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id {get; set; }

        [Required(ErrorMessage = "COLOQUE EL NÚMERO DE LA NORMATIVA")]
        public string numero {get; set; }

        [Required(ErrorMessage = "COLOQUE EL TÍTULO DE LA NORMATIVA")]
        public string titulo {get; set; }

        [Required(ErrorMessage = "COLOQUE LA DESCRIPCIÓN DE LA NORMATIVA")]
        public string descripcion {get; set; }

       
        public string nombrefile {get; set; }

        [Required(ErrorMessage = "COLOQUE LA FECHA")]
        public DateTime fecha {get; set; }
    
        public Entidad entidad {get; set; }

        
    }

}