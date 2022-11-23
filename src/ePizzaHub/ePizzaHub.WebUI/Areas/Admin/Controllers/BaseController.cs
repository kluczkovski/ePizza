using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ePizzaHub.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ePizzaHub.WebUI.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    [Area("Admin")]
    public class BaseController : Controller
    {
       
    }
}

