using AutoMapper;
using Duende.IdentityServer.Models;
using Identity.Models;
using System;

namespace Identity.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersistedGrant, PersistedGrants>()
                .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<PersistedGrants, PersistedGrant>();

            CreateMap<Client, Clients>()
                .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Clients, Client>();
        }
    }
}
