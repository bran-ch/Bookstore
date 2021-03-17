using AutoMapper;

namespace BookstoreApi.Mappings
{
    public class MappingProfileConfiguration
    {
        public static MappingConfiguration InitializeAutoMapper()
        {
            var mp = new MappingProfile();

            var config = new MappingConfiguration(cfg => { cfg.AddProfile(mp); });

            return config;
        }
    }
}
