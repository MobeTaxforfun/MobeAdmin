using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Domain.ViewModel.SystemManage.Page
{
    public class ListedSysDepartmentViewModel
    {
    }

    public class CreateSysDepartmentViewModel
    {
        [Required(ErrorMessage = "部門名稱為必填")]
        public string DepartmentName { get; set; }
    }

    public class UpdateSysDepartmentViewModel
    {
        [Required(ErrorMessage = "Id 並未正常載入")]
        public int Id { get; set; }
        [Required(ErrorMessage = "部門名稱為必填")]
        public string DepartmentName { get; set; }
    }

    public class DeleteSysDepartmentViewModel
    {
        [Required(ErrorMessage = "Id 並未正常載入")]
        public int Id { get; set; }
    }
}
