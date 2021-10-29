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

         [Authorize(Roles = "Admin")]
        public IActionResult RegistrarNoticia(){
            return View();
        }

         [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult RegistrarNoticia(Noticia noticia, int datos){
            if(ModelState.IsValid){
            _context.Add(noticia);
            _context.SaveChanges();
            return RedirectToAction("ListarNoticia");
            }   
            return View();          
        }

          [Authorize(Roles = "Admin")]
        public IActionResult EleccionNoticia(){
            return View();
        }

         [Authorize(Roles = "Admin")]

        public IActionResult ListarNoticia(){
            var noticia = _context.DataNoticias.ToList();
            return View(noticia);
        }

         [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id){
            var noticia = _context.DataNoticias.Find(id);
            _context.DataNoticias.Remove(noticia);
            _context.SaveChanges();
            return RedirectToAction("ListarNoticia");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id){
            Noticia objNoticia = _context.DataNoticias.Find(id);
            if(objNoticia == null){
                return NotFound();
            }
            return View(objNoticia);
        }

         [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, Titulo, LinkImagen, LinkNoticia")] Noticia objNoticia){
                _context.Update(objNoticia);
                _context.SaveChanges();
                ViewData["Message"] = "NOTICIA ACTUALIZADA";
                return RedirectToAction("ListarNoticia");
        }

    }
}