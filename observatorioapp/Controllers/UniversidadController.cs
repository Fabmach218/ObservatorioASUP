using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using observatorioapp.Models;

namespace observatorioapp.Controllers
{
    public class UniversidadController : Controller
    {
        
        private readonly ILogger<UniversidadController> _logger;

        public UniversidadController(ILogger<UniversidadController> logger)
        {
            _logger = logger;
        }

        public IActionResult RegistrarUniversidad(){
            return View();
        }

    }
}