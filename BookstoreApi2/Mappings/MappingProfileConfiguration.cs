using AutoMapper;

namespace BookstoreApi.Mappings
{
    public class MappingProfileConfiguration
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            var mp = new MappingProfile();

            var config = new MapperConfiguration(cfg => { cfg.AddProfile(mp); });

            return config;
        }
    }
}
