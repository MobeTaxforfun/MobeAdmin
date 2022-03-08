using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobeAdmin.Areas.UserManage.Controllers
{
    [Area("UserManage")]
    public class SysUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
