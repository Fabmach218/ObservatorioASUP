using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using observatorioapp.Models;
using observatorioapp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace observatorioapp.Controllers
{
    public class UniversidadController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public UniversidadController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EleccionUniversidad(){
            return View();
        }

        public IActionResult RegistrarUniversidad(){
            return View();
        }
        
        [HttpPost]
        public IActionResult RegistrarUniversidad(Universidad universidad, int datos){
            if(ModelState.IsValid){
            _context.Add(universidad);
            _context.SaveChanges();
            return RedirectToAction("ListarUniversidad");
            }   
            return View();          
        }

        public IActionResult ListarUniversidad(){
            var universidad = _context.DataUniversidades.ToList();
            return View(universidad);
        }

        public IActionResult Delete(int? id){
            var universidad = _context.DataUniversidades.Find(id);
            _context.DataUniversidades.Remove(universidad);
            _context.SaveChanges();
            return RedirectToAction("ListarUniversidad");
        }

    }
}