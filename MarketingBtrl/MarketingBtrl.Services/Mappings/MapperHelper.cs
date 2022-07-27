using AutoMapper;
using System;
using System.Linq;


namespace MarketingBtrl.Services.Mappings
{
    public class MapperHelper
    {
        static IMapper staticMapper;


        static MapperHelper()
        {
            var config = new MapperConfiguration(cfg => {
                var currentAssembly = typeof(MapperHelper).Assembly;
                var mappers = currentAssembly.DefinedTypes.Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(IMapping))).ToList();
                foreach (var mapper in mappers)
                {
                    var obj = Activator.CreateInstance(mapper);
                    ((IMapping)obj).Configure(cfg);
                }

            });

            staticMapper = config.CreateMapper();
        }


        public static T MapFrom<T>(object entity)
        {
            return staticMapper.Map<T>(entity);
        }

        public static T Map<S,T>(S entitySource, T entityTarget)
        {
            return staticMapper.Map(entitySource, entityTarget);
        }

    }
}
