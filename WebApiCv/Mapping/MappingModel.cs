namespace WebApiCv
{
    using AutoMapper;
    using Dtos;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MappingModel : Profile
    {
        #region Construnctores
        public MappingModel()
        {
            CreateMap<Users, UserDto>();
            CreateMap<UserDto, Users>();
            CreateMap<UserDto, CreateUserDto>();
            CreateMap<CreateUserDto, UserDto>();
            CreateMap<Users, CreateUserDto>();
            CreateMap<CreateUserDto, Users>();
        }
        #endregion
    }
}
