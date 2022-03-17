using AutoMapper;
using MobeAdmin.DataAccess.Interface;
using MobeAdmin.DataAccess.Interface.AdminDb;
using MobeAdmin.Domain.ViewModel.SystemManage.Page;
using MobeAdmin.Service.Interface.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Service.Service.SystemManage
{
    public class SysDepartmentService : ISysDepartmentService
    {
        private readonly IDepartmentRepository _DepartmentRepository;
        private readonly IMapper _Mapper;
        public SysDepartmentService(IMapper Mapper, IDepartmentRepository DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;
            _Mapper = Mapper;
        }
        public Task<int> CreateSysDepartmentAsync(CreateSysDepartmentViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteSysDepartmentAsync(DeleteSysDepartmentViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<List<ListedSysDepartmentViewModel>> ListedSysDepartmentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateSysDepartmentAsync(UpdateSysDepartmentViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
