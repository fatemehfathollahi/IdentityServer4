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

        public static PersistedGrant ToModel(this PlusPersistedGrant entity)
        {
            return entity == null ? null : Mapper.Map<PersistedGrant>(entity);
        }
      
        public static PlusPersistedGrant ToEntity(this PersistedGrant model)
        {
            return model == null ? null : Mapper.Map<PlusPersistedGrant>(model);
        }

        public static void UpdateEntity(this PersistedGrant model, PlusPersistedGrant entity)
        {
            Mapper.Map(model, entity);
        }
    }

    public class PersistedGrantMapperProfile : Profile
    {
      
        public PersistedGrantMapperProfile()
        {
            CreateMap<PlusPersistedGrant, PersistedGrant>(MemberList.Destination)
                .ReverseMap();
        }
    }
}