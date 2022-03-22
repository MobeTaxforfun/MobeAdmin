using Microsoft.AspNetCore.Mvc;
using MobeAdmin.Controllers;
using MobeAdmin.Domain.ViewModel.SystemManage.Page;
using MobeAdmin.Service.Interface.SystemManage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public async Task<IActionResult> ListedDepartment(int? page, [DefaultValue(0)] int Enable, string Name)
        {
            try
            {
                int pager = (page ?? 1) - 1;
                return Json(Success(await _SysDepartmentService.ListedSysDepartmentAsync(pager, 10, Enable, Name)));
            }
            catch (Exception e)
            {
                return Json(Failed("系統錯誤"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([Bind(Prefix = "CreateSysDepartment")] CreateSysDepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Json(Success(@$"新增成功，新增資料 {await _SysDepartmentService.CreateSysDepartmentAsync(model)} 筆"));
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
        public async Task<IActionResult> UpdateDepartment([Bind(Prefix = "UpdateSysDepartment")] UpdateSysDepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Json(Success(@$"更新成功，異動資料 {await _SysDepartmentService.UpdateSysDepartmentAsync(model)} 筆"));
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
        public async Task<IActionResult> DeleteDepartment([Bind(Prefix = "DeleteSysDepartment")] DeleteSysDepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Json(Success(@$"刪除成功，刪除資料 {await _SysDepartmentService.DeleteSysDepartmentAsync(model)} 筆"));
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
        public async Task<IActionResult> GetOneDepartment(int Id)
        {
            try
            {
                var result = await _SysDepartmentService.GetOneSysDepartmentByIdAsync(Id);
                return Json(Success(result));
            }
            catch (Exception e)
            {
                return Json(Failed("系統錯誤"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> SetIsEnable(int Id, int Enable)
        {
            try
            {
                return Json(Success(@$"更新成功，異動資料 {await _SysDepartmentService.SetSysDepartmentEnableById(Id, Enable)} 筆"));
            }
            catch (Exception e)
            {
                return Json(Failed("系統錯誤"));
            }
        }
    }
}
