using MobeAdmin.Domain.ViewModel.SystemManage.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Service.Interface.SystemManage
{
    public interface ISysDepartmentService
    {
        Task<List<SysDepartmentViewModel>> ListedSysDepartmentAsync();
        Task<PaginateSysDepartmentViewModel> ListedSysDepartmentAsync(int page, int itemsPerPage, int IsEnable, string DepartmentName);
        Task<int> CreateSysDepartmentAsync(CreateSysDepartmentViewModel model);
        Task<int> UpdateSysDepartmentAsync(UpdateSysDepartmentViewModel model);
        Task<int> DeleteSysDepartmentAsync(DeleteSysDepartmentViewModel model);
        Task<SysDepartmentViewModel> GetOneSysDepartmentByIdAsync(int Id);
        Task<int> SetSysDepartmentEnableById(int Id,int Enable);
    }
}
