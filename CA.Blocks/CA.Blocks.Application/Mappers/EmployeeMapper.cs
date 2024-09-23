using AutoMapper;
using CA.Blocks.Application.Common.ViewModels;
using CA.Blocks.Application.Employee.Commands.CreateEmployee;
using CA.Blocks.Application.Employee.Commands.UpdateEmployee;
using CA.Blocks.Application.ViewModels;
using CA.Blocks.Domain.Entities;
namespace CA.Blocks.Application.Mappers;
public static class EmployeeMapper
{
    public static EmployeeViewModel ToViewModel(this CA.Blocks.Domain.Entities.Employee input)
    {
        var config = new MapperConfiguration(cfg => 
            cfg.CreateMap<CA.Blocks.Domain.Entities.Employee, EmployeeViewModel>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(
                       src => new EnumViewModel(src.Gender))));

        var mapper = new Mapper(config);

        return mapper.Map<EmployeeViewModel>(input);
    }

    public static IReadOnlyList<EmployeeViewModel> ToViewModel(this IReadOnlyList<CA.Blocks.Domain.Entities.Employee> input)
    {
        var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<CA.Blocks.Domain.Entities.Employee, EmployeeViewModel>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(
                       src => new EnumViewModel(src.Gender))));

        var mapper = new Mapper(config);

        return mapper.Map<IReadOnlyList<EmployeeViewModel>>(input);
    }

    public static CA.Blocks.Domain.Entities.Employee ToEntity(this CreateEmployeeCommand input)
    {
        var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<CreateEmployeeCommand, CA.Blocks.Domain.Entities.Employee>());

        var mapper = new Mapper(config);

        return mapper.Map<CA.Blocks.Domain.Entities.Employee>(input);
    }

    public static CA.Blocks.Domain.Entities.Employee ToEntity(this UpdateEmployeeCommand input, CA.Blocks.Domain.Entities.Employee entity)
    {
        var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<UpdateEmployeeCommand, CA.Blocks.Domain.Entities.Employee>());

        var mapper = new Mapper(config);

        return mapper.Map(input, entity);
    }
}
