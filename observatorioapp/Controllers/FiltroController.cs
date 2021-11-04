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

      public IActionResult Resultados(string titulo, int idEntidad, string fechainicio, string fechafin){
        
        var normativas = _context.DataNormativas.Include(n => n.entidad).ToList();
        
        var query1 = normativas;
        var query2 = normativas;
        var query3 = normativas;

        if(titulo != null){
          query1 =  query1.Where(n => n.titulo.Contains(titulo)).ToList();
        }
        
        if(idEntidad != 0){
          query2 = query2.Where(n => n.entidad.Id == idEntidad).ToList();
        }

        if(fechainicio != null || fechafin != null){
          
          if(fechainicio == null){
            query3 = query3.Where(n => n.fecha >= DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", null) && n.fecha <= DateTime.ParseExact(fechafin, "yyyy-MM-dd", null)).ToList();
          }else if(fechafin == null){
            query3 = query3.Where(n => n.fecha >= DateTime.ParseExact(fechainicio, "yyyy-MM-dd", null) && n.fecha <= DateTime.Now).ToList();
          }else{
            query3 = query3.Where(n => n.fecha >= DateTime.ParseExact(fechainicio, "yyyy-MM-dd", null) && n.fecha <= DateTime.ParseExact(fechafin, "yyyy-MM-dd", null)).ToList();
          }

        }

        var resultado = query1.Intersect(query2).Intersect(query3).ToList();
        return View(resultado);

      }

       public IActionResult DownLoadNormativa(int id){
        
           var normativas = _context.DataNormativas.Find(id);
           return File(normativas.archivo, "application/pdf", normativas.nombrefile);  
          

       }

    }
}