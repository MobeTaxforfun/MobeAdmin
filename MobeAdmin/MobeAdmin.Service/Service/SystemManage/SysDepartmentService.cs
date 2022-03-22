using AutoMapper;
using MobeAdmin.DataAccess.Interface;
using MobeAdmin.DataAccess.Interface.AdminDb;
using MobeAdmin.Domain.Model.AdminDb;
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
        public async Task<int> CreateSysDepartmentAsync(CreateSysDepartmentViewModel model)
        {
            var department = _Mapper.Map<Department>(model);

            department.UpdateTime = DateTime.Now;
            department.CreateTime = DateTime.Now;
            department.IsEnable = true;
            department.IsDelete = false;

            return await _DepartmentRepository.CreateAsync(department);
        }

        public async Task<int> DeleteSysDepartmentAsync(DeleteSysDepartmentViewModel model)
        {
            return await _DepartmentRepository.DeleteAsync(_Mapper.Map<Department>(model));
        }

        public async Task<int> UpdateSysDepartmentAsync(UpdateSysDepartmentViewModel model)
        {
            var department = _Mapper.Map<Department>(model);

            department.UpdateTime = DateTime.Now;

            return await _DepartmentRepository.UpdateAsync(department);
        }

        public async Task<List<SysDepartmentViewModel>> ListedSysDepartmentAsync()
        {
            return _Mapper.Map<List<SysDepartmentViewModel>>((await _DepartmentRepository.ListedAllAsync()).ToList());
        }

        public async Task<SysDepartmentViewModel> GetOneSysDepartmentByIdAsync(int Id)
        {
            return _Mapper.Map<SysDepartmentViewModel>(await _DepartmentRepository.GetOne(Id));
        }

        public async Task<PaginateSysDepartmentViewModel> ListedSysDepartmentAsync(int page, int itemsPerPage, int IsEnable, string DepartmentName)
        {
            PaginateSysDepartmentViewModel model = new();

            var result = await _DepartmentRepository.PaginateAsync(page, itemsPerPage, IsEnable, DepartmentName);
            model.Max = result.Item1;
            model.PageData = _Mapper.Map<List<SysDepartmentViewModel>>(result.Item2);

            return model;
        }

        public async Task<int> SetSysDepartmentEnableById(int Id, int Enable)
        {
            return await _DepartmentRepository.SetDepartmentEnableById(Id, Enable);
        }
    }
}
