using AutoMapper;
using ADPortsTask.Data.Models;
using ADPortsTask.DTOs;
using ADPortsTask.DTOs.Employee;
using ADPortsTask.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace ADPortsTask.Services
{
    public class MapperService : IMapperService
    {
        readonly IMapper autoMapperInstance;

        public MapperService()
        {
            autoMapperInstance = new Mapper(new MapperConfiguration(cfg => {

 
                cfg.CreateMap<Employee, EmployeeBaseDto>();
                cfg.CreateMap<Employee, EmployeeMinimalDto>().ReverseMap();

 
                cfg.CreateMap<ApplicationUser, AuthRegisterDto>().ReverseMap().ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
                cfg.CreateMap<UserMinimalDto, ApplicationUser>().ReverseMap();
                cfg.CreateMap<UserUpdateDTO, ApplicationUser>().ReverseMap();

            }));
        }

        /// <summary>
        /// Internal wrapper.
        /// </summary>
        public TDestination Map<TDestination>(object source) => (TDestination)Map(source, source.GetType(), typeof(TDestination));

        /// <summary>
        /// Internal wrapper.
        /// </summary>
        public TDestination Map<TSource, TDestination>(TSource source) => (TDestination)Map(source, typeof(TSource), typeof(TDestination));

        /// <summary>
        /// Internal wrapper.
        /// </summary>
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination) => (TDestination)Map(source, destination, typeof(TSource), typeof(TDestination));

        /// <summary>
        /// Automapper wrapper.
        /// </summary>
        public object Map(object source, Type sourceType, Type destinationType) => autoMapperInstance.Map(source, sourceType, destinationType);

        /// <summary>
        /// Automapper wrapper.
        /// </summary>
        public object Map(object source, object destination, Type sourceType, Type destinationType) => autoMapperInstance.Map(source, destination, sourceType, destinationType);
    }
}