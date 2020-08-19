using AutoMapper;
using IdentityServer4.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
  
    public static class PlusPersistedGrantMappers
    {
        static PlusPersistedGrantMappers()
        {
            Mapper = new MapperConfiguration(cfg =>cfg.AddProfile<PersistedGrantMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static IdentityServer4.Models.PersistedGrant ToModel(this Domain.Models.PersistedGrant entity)
        {
            return entity == null ? null : Mapper.Map<IdentityServer4.Models.PersistedGrant>(entity);
        }
      
        public static Domain.Models.PersistedGrant ToEntity(this IdentityServer4.Models.PersistedGrant model)
        {
            return model == null ? null : Mapper.Map<Domain.Models.PersistedGrant>(model);
        }

        public static void UpdateEntity(this IdentityServer4.Models.PersistedGrant model, Domain.Models.PersistedGrant entity)
        {
            Mapper.Map(model, entity);
        }
    }

    public class PersistedGrantMapperProfile : Profile
    {
      
        public PersistedGrantMapperProfile()
        {
            CreateMap<Domain.Models.PersistedGrant, IdentityServer4.Models.PersistedGrant>(MemberList.Destination)
                .ReverseMap();
        }
    }
}