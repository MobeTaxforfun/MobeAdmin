﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobeAdmin.Areas.DataSearchManage.Controllers
{
    [Area("DataSearchManage")]
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
