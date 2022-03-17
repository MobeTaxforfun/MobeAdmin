﻿using Microsoft.AspNetCore.Mvc;
using MobeAdmin.Controllers;
using MobeAdmin.Domain.ViewModel.SystemManage.Page;
using MobeAdmin.Service.Interface.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobeAdmin.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class SysDepartmentController : BaseController
    {
        private readonly ISysDepartmentService _SysDepartmentService;
        public SysDepartmentController(ISysDepartmentService SysDepartmentService)
        {
            _SysDepartmentService = SysDepartmentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListedDepartment()
        {
            return Json(Success());
        }

        [HttpPost]
        public IActionResult CreateDepartment(CreateSysDepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Json(Success(@$"新增成功，新增資料 {_SysDepartmentService.CreateSysDepartmentAsync(model)} 筆"));
                }
                else
                {
                    return Json(ValidationFailed(
                        ModelState.Where(x => x.Value.Errors.Count > 0)
                            .ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                            ), "欄位錯誤"));
                }
            }
            catch (Exception e)
            {
                return Json(Failed("系統錯誤"));
            }
        }
        [HttpPost]
        public IActionResult UpdateDepartment(UpdateSysDepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Json(Success(@$"更新成功，異動資料 {_SysDepartmentService.UpdateSysDepartmentAsync(model)} 筆"));
                }
                else
                {
                    return Json(ValidationFailed(
                        ModelState.Where(x => x.Value.Errors.Count > 0)
                            .ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                            ), "欄位錯誤"));
                }
            }
            catch (Exception e)
            {
                return Json(Failed("系統錯誤"));
            }
        }
        [HttpPost]
        public IActionResult DeleteDepartment(DeleteSysDepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Json(Success(@$"刪除成功，刪除資料 {_SysDepartmentService.DeleteSysDepartmentAsync(model)} 筆"));
                }
                else
                {
                    return Json(ValidationFailed(
                        ModelState.Where(x => x.Value.Errors.Count > 0)
                            .ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                            ), "欄位錯誤"));
                }
            }
            catch (Exception e)
            {
                return Json(Failed("系統錯誤"));
            }
        }

    }
}
