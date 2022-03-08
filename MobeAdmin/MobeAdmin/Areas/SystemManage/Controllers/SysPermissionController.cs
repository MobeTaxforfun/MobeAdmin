using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobeAdmin.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class SysPermissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
