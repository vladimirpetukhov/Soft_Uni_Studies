namespace Sweetshop.App.Core
{
    using AutoMapper;
    using DTOs;
    using Models;

    public class SweetshopProfile : Profile
    {
        public SweetshopProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeePersonalInfoDTO>();
            CreateMap<EmployeePersonalInfoDTO, Employee>();
            CreateMap<Employee, ManagerDTO>()
                .ForMember(dest=> dest.EmployeesDTOs, from=> from.MapFrom(x=> x.EmployeeManager))
                .ReverseMap();
            

        }
    }
}
