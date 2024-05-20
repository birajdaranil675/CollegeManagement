using AutoMapper;
using MyCollege.Api.DTOs;
using MyCollege.Api.Model;

namespace MyCollege.Api.Infrastructure
{
    public static class MappingConfiguration
    {
        public static MapperConfiguration Config => new(cfg => {
            cfg.CreateMap<StudentDto, Student>();
            cfg.CreateMap<Student, StudentDto>();
            cfg.CreateMap<Student, StudentInputDto>();
            cfg.CreateMap<StudentInputDto, Student>();
            cfg.CreateMap<Student, StudentUpdateInputDto>();
            cfg.CreateMap<StudentUpdateInputDto, Student>();
        });
    }

    public class COMapper : ICOMapper
    {
        private readonly IMapper _mapper;
        public COMapper(MapperConfiguration mapper)
        {
            _mapper = mapper.CreateMapper();
        }
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map<TSource, TDestination>(source, destination);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return _mapper.Map(source, sourceType, destinationType);
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }

    public interface ICOMapper
    {
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
        object Map(object source, Type sourceType, Type destinationType);
        TDestination Map<TDestination>(object source);
    }
}
