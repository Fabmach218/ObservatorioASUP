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
    public class NoticiaController : Controller
    {
        
        private readonly ILogger<NoticiaController> _logger;
        public NoticiaController(ILogger<NoticiaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(){
            return View();
        }

    }
}