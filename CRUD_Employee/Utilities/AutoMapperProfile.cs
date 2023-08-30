using AutoMapper;
using CRUD_Employee.DTOs;
using CRUD_Employee.Models;
using System.Globalization;

namespace CRUD_Employee.Utilities
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(destiny =>
                destiny.DepartmentName,
                opt => opt.MapFrom(origin => origin.IdDepartmentNavigation.Name)
                )
                .ForMember(destiny =>
                destiny.HireDate,
                opt => opt.MapFrom(origin => origin.HireDate.Value.ToString("dd/MM/yyyy"))
                )
                .ForMember(destiny =>
                destiny.Salary,
                opt => opt.MapFrom(origin => Convert.ToString(origin.Salary, CultureInfo.InvariantCulture))
                );


            CreateMap<EmployeeDTO, Employee>()
                .ForMember(destiny =>
                destiny.IdDepartmentNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destiny =>
                destiny.HireDate,
                opt => opt.MapFrom(origin => DateTime.ParseExact(origin.HireDate, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                )
                .ForMember(destiny =>
                destiny.Salary,
                opt => opt.MapFrom(origin => Decimal.Parse(origin.Salary, NumberStyles.AllowDecimalPoint ,CultureInfo.InvariantCulture))
                );
        }
    }
}
