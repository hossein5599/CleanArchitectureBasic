using AutoMapper;
using CA.Blocks.Domain.Entities;

namespace CA.Blocks.Application.Common.Dtos;
public class LookupDto
{
    public int Id { get; init; }

    public string? Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CA.Blocks.Domain.Entities.Employee, LookupDto>();
            CreateMap<CA.Blocks.Domain.Entities.Job, LookupDto>();
        }
    }
}