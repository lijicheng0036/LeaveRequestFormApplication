using AutoMapper;
using LeaveRequestFormApplication.Data.Dto;
using LeaveRequestFormApplication.Models;

namespace LeaveRequestFormApplication.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Department, DepartmentDto>()
            .ForMember(dest => dest.Employees, opt => opt.Ignore());

            CreateMap<Leave, LeaveDto>();
            CreateMap<LeaveType, LeaveTypeDto>();
        }        
    }
}
