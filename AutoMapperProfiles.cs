using AutoMapper;
using StaffApplication.DTOs;

namespace StaffRegistrationPortal
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserViewModel>();

            CreateMap<User, LogViewModel>();

            CreateMap<User, DeactivateViewModel>();

            CreateMap<User, ReactivateViewModel>();

            CreateMap<Employee, EmployeeViewModel>();

            CreateMap<Employee, DeletedViewModel>();

        }
    }
}
