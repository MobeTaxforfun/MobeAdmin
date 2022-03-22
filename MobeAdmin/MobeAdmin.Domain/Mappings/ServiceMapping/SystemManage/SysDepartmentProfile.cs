using AutoMapper;
using MobeAdmin.Domain.Model.AdminDb;
using MobeAdmin.Domain.ViewModel.SystemManage.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Domain.Mappings.ServiceMapping.SystemManage
{
    public class SysDepartmentProfile : Profile
    {
        public SysDepartmentProfile()
        {
            CreateMap<Department, SysDepartmentViewModel>();
            CreateMap<CreateSysDepartmentViewModel, Department>();
            CreateMap<DeleteSysDepartmentViewModel, Department>();
            CreateMap<UpdateSysDepartmentViewModel, Department>();
        }
    }
}
