using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace observatorioapp.Controllers
{
    [Route("[controller]")]
    public class DatosEstadisticosController : Controller
    {
        private readonly ILogger<DatosEstadisticosController> _logger;

        public DatosEstadisticosController(ILogger<DatosEstadisticosController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}