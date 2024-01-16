using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Models;

namespace BusinessObject;

public class MapperConfig
{
    public static Mapper InitAutoMapper()
    {
        var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<CategoryDTO, Category>());

        var mapper = new Mapper(config);
        return mapper;
    }
}