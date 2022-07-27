using AutoMapper;
using MarketingBtrl.DAL.Entities;
using MarketingBtrl.Services.Dtos;

namespace MarketingBtrl.Services.Mappings
{
    public class DirectorMapper : IMapping
    {
  
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Remuneration, RemunerationDto>()
                .ForMember(x => x.Product, opt => opt.MapFrom(c => c.Product.Name))
                .ForMember(x => x.Retailer, opt => opt.MapFrom(c => c.Retailer.Name));

            cfg.CreateMap<RemunerationEditDto, Remuneration>();
        }
    }
}
