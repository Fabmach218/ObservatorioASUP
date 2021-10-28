using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace observatorioapp.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller 
    {
        
      
      public IActionResult Panel(){

           return View();

      }

    }
}