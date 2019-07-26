using AutoMapper;

namespace Explore.Dto.Abstraction.CustomMapper
{
    public class BaseMapper<TFrom, TTo>
    {
        public static TTo Map(TFrom fromModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap <TFrom, TTo> ();
            });

            IMapper mapper = config.CreateMapper();

            return mapper.Map<TFrom, TTo>(fromModel);
        }
    }
}