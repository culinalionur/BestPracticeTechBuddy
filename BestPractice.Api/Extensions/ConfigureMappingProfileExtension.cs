using AutoMapper;
using BestPractice.Api.Data.Models;
using BestPractice.Api.Models;

namespace BestPractice.Api.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMapperMappingProfile()));

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
            return services;
        }
    }
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            CreateMap<Contact, ContactDVO>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => z.FirstName + " " + z.LastName))
                //.ForMember(x => x.Id , y => y.MapFrom(z => z.Id)) => iki property adı aynı olduğundan belirtmemize gerek yok
                .ReverseMap();
        }
    }
}
