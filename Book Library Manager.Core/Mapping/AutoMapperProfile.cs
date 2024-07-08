using AutoMapper;
using AutoMapper.Configuration;
using Book_Library_Manager.Core.Models.Domain;
using Book_Library_Manager.Core.Models.DTOs;

namespace Book_Library_Manager.Core.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BookDto, Book>().ReverseMap();
        CreateMap<CreateBookDto, Book>().ReverseMap();
        CreateMap<UpdateBookDto, Book>().ReverseMap();
        CreateMap<UpdateBookDto, BookDto>().ReverseMap();
    }
}
