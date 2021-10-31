using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult RegistrarNormativa(){

            var entidades = _context.DataEntidades.ToList();
            ViewBag.items = entidades;
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarNormativa(Normativa normativa , int idEntidad , List<IFormFile> files){
            var flag = false;

            if(ModelState.IsValid){

                if(files.Count > 0 ){

                    foreach(var file in files){

                       Console.WriteLine(Path.GetExtension(file.FileName).Substring(1));

                        if(Path.GetExtension(file.FileName).Substring(1) == "pdf"){

                       var filePath  = "C:\\Users\\Julio\\OneDrive - Universidad de San Martin de Porres\\Documentos\\ASUP-Project\\ObservatorioASUP\\observatorioapp\\NormativasPdf\\" + file.FileName;
                      
                         using (var stream = System.IO.File.Create(filePath))
                        {
                          file.CopyToAsync(stream);
                        }

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


       public IActionResult ListarNormativa(){
        
           return View();

       }


    }
}