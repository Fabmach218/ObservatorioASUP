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
    public class NormativaController : Controller
    {
        
        private readonly ILogger<NormativaController> _logger;

        public NormativaController(ILogger<NormativaController> logger)
        {
            _logger = logger;
        }

        public IActionResult RegistrarNormativa(){
            return View();
        }

    }
}