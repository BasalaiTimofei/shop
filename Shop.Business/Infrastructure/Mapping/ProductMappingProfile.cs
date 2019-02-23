using AutoMapper;

namespace Shop.Business.Infrastructure.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Data.Models.Product, Models.Product>()
                .ForMember(f => f.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(f => f.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(f => f.Price, opt => opt.MapFrom(m => m.Price));

            CreateMap<Models.Product, Data.Models.Product>()
                .ForMember(f => f.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(f => f.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(f => f.Price, opt => opt.MapFrom(m => m.Price));
        }
    }
}