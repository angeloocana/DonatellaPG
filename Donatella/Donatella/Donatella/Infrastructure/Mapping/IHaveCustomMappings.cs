using AutoMapper;

namespace Donatella.Infrastructure.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}