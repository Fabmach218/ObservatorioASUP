using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using observatorioapp.Data;

namespace observatorioapp.Controllers
{
    public class FiltroController : Controller 
    {

      private readonly ApplicationDbContext _context; 

      public FiltroController(ApplicationDbContext context)
      {
          _context = context;
      } 
      
    public IActionResult Busqueda(){
        
        var entidades = _context.DataEntidades.ToList();
        ViewBag.items = entidades;
        return View();
    }

      public IActionResult Resultados(string titulo, int idEntidad, DateTime fechainicio, DateTime fechafin){

        var normativas = _context.DataNormativas.Where(n => n.titulo.Contains(titulo) && n.entidad.Id == idEntidad && n.fecha >= fechainicio && n.fecha <= fechafin).Include( e => e.entidad).ToList();
        //var normativas = _context.DataNormativas.Where(n => n.titulo.Contains(titulo) && n.entidad.Id == idEntidad && n.fecha >= fechainicio && n.fecha <= fechafin).Include( e => e.entidad).ToList();
        return View(normativas);

      }

       public IActionResult DownLoadNormativa(int id){
        
           var normativas = _context.DataNormativas.Find(id);
           return File(normativas.archivo, "application/pdf", normativas.nombrefile);  
          

       }

    }
}