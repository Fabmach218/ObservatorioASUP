using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using observatorioapp.Data;
using observatorioapp.Models;

namespace observatorioapp.Controllers
{
    public class NormativaController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly ILogger<NormativaController> _logger;

        public NormativaController(ILogger<NormativaController> logger  , ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult AccionNormativa(){

            return View();
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult RegistrarNormativa(){

            var entidades = _context.DataEntidades.ToList();
            ViewBag.items = entidades;
            return View();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult RegistrarNormativa(Normativa normativa , int idEntidad , List<IFormFile> files){
            var flag = false;

            if(ModelState.IsValid){

                if(files.Count > 0 ){

                    foreach(var file in files){

                       Console.WriteLine(Path.GetExtension(file.FileName).Substring(1));

                        if(Path.GetExtension(file.FileName).Substring(1) == "pdf"){
                      
                          Stream str = file.OpenReadStream();
                          BinaryReader br = new BinaryReader(str);
                          Byte [] fileDet = br.ReadBytes((Int32) str.Length);
                          normativa.archivo = fileDet;
                          normativa.nombrefile = Path.GetFileName(file.FileName);

                        }else {
                            
                            flag = true;
                            break;
                
                        }

 
                    }


                
                }

                if(flag == true){

                     var entidades = _context.DataEntidades.ToList();
                     ViewBag.items = entidades;
                     ModelState.AddModelError("files" , "Solo se aceptan documentos con la extension PDF");
                     return View(normativa);
                }

                var entity = _context.DataEntidades.Find(idEntidad);
                normativa.entidad = entity;
                _context.Add(normativa);
                _context.SaveChanges();
                
                return RedirectToAction("ListarNormativa");

            }

            var entidade = _context.DataEntidades.ToList();
            ViewBag.items = entidade;
            return View(normativa);

        }
      
        
         [Authorize(Roles = "Admin")]
         public IActionResult ListarNormativa(){

             var normativas = _context.DataNormativas.Include(e => e.entidad).ToList();

             return View(normativas);
         }
         
         [Authorize(Roles = "Admin")]
         public IActionResult EditarNormativa(int id){

               var normativa = _context.DataNormativas.Include(e => e.entidad).FirstOrDefault(s => s.id == id);

               if(normativa == null){

                   return NotFound();
               }
              
               var entica = _context.DataEntidades.Find(normativa.entidad.Id);
               var entidades = _context.DataEntidades.Where(s => s.Id != normativa.entidad.Id).ToList();
               
               ViewBag.items = entidades;
               ViewBag.item = entica;
               return View(normativa);

         }
         
         [Authorize(Roles = "Admin")]
         [HttpPost]
         public IActionResult EditarNormativa([Bind("id , numero , titulo , descripcion , fecha , nombrefile , archivo")] Normativa normativa ,  int idEntidad , List<IFormFile> files){
            var flag = false;
            var entica = _context.DataEntidades.Find(idEntidad);
            var entidades = _context.DataEntidades.Where(e => e.Id != idEntidad).ToList();
            

             if(ModelState.IsValid){

               if(files.Count > 0){

                    foreach(var file in files){

                       Console.WriteLine(Path.GetExtension(file.FileName).Substring(1));

                        if(Path.GetExtension(file.FileName).Substring(1) == "pdf"){
                      
                          Stream str = file.OpenReadStream();
                          BinaryReader br = new BinaryReader(str);
                          Byte [] fileDet = br.ReadBytes((Int32) str.Length);
                          normativa.archivo = fileDet;
                          normativa.nombrefile = Path.GetFileName(file.FileName);

                        }else {
                            
                            flag = true;
                            break;
                
                        }

 
                    }

                  

               }else {

                  var norma = _context.DataNormativas.AsNoTracking().Where(s => s.id == normativa.id).FirstOrDefault();
                  normativa.archivo = norma.archivo;
                  normativa.nombrefile = norma.nombrefile;


               }

                 if(flag == true){
                    
                    
                     ViewBag.items = entidades;
                     ViewBag.item = entica;
                     ModelState.AddModelError("files" , "Solo se aceptan documentos con la extension PDF");
                     return View(normativa);
                }

                
                 var entity = _context.DataEntidades.Find(idEntidad);
                 normativa.entidad = entity;
                 _context.Update(normativa);
                 _context.SaveChanges();
                 return RedirectToAction("ListarNormativa");

             }


            
             ViewBag.items = entidades;
             ViewBag.item = entica;
            
             return View(normativa);
         }

       
       [Authorize(Roles = "Admin")]
       public IActionResult EliminarNormativa(int id){
            
             var normativa = _context.DataNormativas.Find(id);

             if(normativa == null){

                 return NotFound();
             }

             _context.DataNormativas.Remove(normativa);
             _context.SaveChanges();

            return RedirectToAction("ListarNormativa");
       }

       public IActionResult DownLoadNormativa(int id){
        
           var normativas = _context.DataNormativas.Find(id);
           return File(normativas.archivo, "application/pdf", normativas.nombrefile);  
          

       }


    }
}