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
    public class NoticiaController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public NoticiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {    

            var noticias = _context.DataNoticias.ToList();
            return View(noticias);

        }
        public IActionResult RegistrarNoticia(){
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarNoticia(Noticia noticia, int datos){
            if(ModelState.IsValid){
            _context.Add(noticia);
            _context.SaveChanges();
            return RedirectToAction("RegistrarNoticia");
            }   
            return View();          
        }

    }
}