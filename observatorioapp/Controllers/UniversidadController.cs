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
using Microsoft.AspNetCore.Authorization;

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
            var universidades = _context.DataUniversidades.ToList();

            return View(universidades);
        }

         [Authorize(Roles = "Admin")]

        public IActionResult EleccionUniversidad(){
            return View();
        }

         [Authorize(Roles = "Admin")]
        public IActionResult RegistrarUniversidad(){
            return View();
        }
        
         [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult RegistrarUniversidad(Universidad universidad, int datos){
            if(ModelState.IsValid){
            _context.Add(universidad);
            _context.SaveChanges();
            return RedirectToAction("ListarUniversidad");
            }   
            return View();          
        }


         [Authorize(Roles = "Admin")]

        public IActionResult ListarUniversidad(){
            var universidad = _context.DataUniversidades.ToList();
            return View(universidad);
        }

         [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id){
            var universidad = _context.DataUniversidades.Find(id);
            _context.DataUniversidades.Remove(universidad);
            _context.SaveChanges();
            return RedirectToAction("ListarUniversidad");
        }

         [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id){
            Universidad objUniversidad = _context.DataUniversidades.Find(id);
            if(objUniversidad  == null){
                return NotFound();
            }
            return View(objUniversidad );
        }

         [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(int id, [Bind("id, nombre, telefono, direccion, aniversario, nombrerector, apellidorector, fechanacimientorector, correorector, imagen")] Universidad  objUniversidad ){
            _context.Update(objUniversidad );
            _context.SaveChanges();
            ViewData["Message"] = "UNIVERSIDAD ACTUALIZADA";
            return RedirectToAction("ListarUniversidad");
        }
    }
}