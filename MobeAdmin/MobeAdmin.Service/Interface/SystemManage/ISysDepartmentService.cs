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
        Task<List<ListedSysDepartmentViewModel>> ListedSysDepartmentAsync();
        Task<int> CreateSysDepartmentAsync(CreateSysDepartmentViewModel model);
        Task<int> UpdateSysDepartmentAsync(UpdateSysDepartmentViewModel model);
        Task<int> DeleteSysDepartmentAsync(DeleteSysDepartmentViewModel model);
    }
}
