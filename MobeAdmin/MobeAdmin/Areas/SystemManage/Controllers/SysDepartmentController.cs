using Microsoft.AspNetCore.Mvc;
using MobeAdmin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobeAdmin.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class SysDepartmentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
