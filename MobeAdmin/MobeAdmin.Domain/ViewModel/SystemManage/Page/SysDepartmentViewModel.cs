using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Domain.ViewModel.SystemManage.Page
{

    public class PageSysDepartmentViewModel
    {
        public CreateSysDepartmentViewModel CreateSysDepartment { get; set; }
        public UpdateSysDepartmentViewModel UpdateSysDepartment { get; set; }
        public DeleteSysDepartmentViewModel DeleteSysDepartment { get; set; }
    }

    public class SysDepartmentViewModel
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
        public int Sort { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsEnable { get; set; }
    }

    public class PaginateSysDepartmentViewModel
    {
        public int Max { get; set; }
        public List<SysDepartmentViewModel> PageData { get; set; }
    }

    public class CreateSysDepartmentViewModel
    {
        [Required(ErrorMessage = "部門名稱為必填")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "部門排序為必填")]
        [Range(0, int.MaxValue, ErrorMessage = "請填入數字")]
        public int? Sort { get; set; }
        public string DepartmentDescription { get; set; }
    }

    public class UpdateSysDepartmentViewModel
    {
        [Required(ErrorMessage = "Id 並未正常載入")]
        public int Id { get; set; }
        [Required(ErrorMessage = "部門名稱為必填")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "部門排序為必填")]
        [Range(0, int.MaxValue, ErrorMessage = "請填入數字")]
        public int? Sort { get; set; }
        public string DepartmentDescription { get; set; }
    }

    public class DeleteSysDepartmentViewModel
    {
        [Required(ErrorMessage = "Id 並未正常載入")]
        public int Id { get; set; }
    }
}
