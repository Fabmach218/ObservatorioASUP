
using System;
using Microsoft.AspNetCore.Identity;

namespace observatorioapp.Models

{
  
    public class Usuario : IdentityUser
    {

        [PersonalData]
        public string Nombre { get; set; }

        [PersonalData]
        public string Apellido { get; set; }

     
    }


}