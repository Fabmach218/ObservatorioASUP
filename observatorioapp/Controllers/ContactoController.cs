using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using observatorioapp.Models;
using observatorioapp.Data;

namespace observatorioapp.Controllers
{
    public class ContactoController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public ContactoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(){
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarContacto(Contacto c){
            
            c.Fecha = DateTime.Now;

            if(ModelState.IsValid){
                _context.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }else{
                return View("Index");
            }
        }
        
    }
}