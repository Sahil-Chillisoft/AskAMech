using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;
using AskAMech.Infrastructure.Data.Entities;
using AutoMapper;

namespace AskAMech.Infrastructure.Data.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserEntity, User>();
            CreateMap<UserProfileEntity, UserProfile>();
        }
    }
}
