using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.Controllers
{
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        
        
    }
}
