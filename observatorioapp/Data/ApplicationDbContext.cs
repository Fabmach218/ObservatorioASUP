using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace observatorioapp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
         public DbSet<observatorioapp.Models.Usuario> DataUsuarios {get; set; }
        public DbSet<observatorioapp.Models.Noticia> DataNoticias {get; set; }
        public DbSet<observatorioapp.Models.Universidad> DataUniversidades {get; set; }

    }
}
