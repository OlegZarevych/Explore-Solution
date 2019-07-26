using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.Mappers;

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

            //return Mapper.Map<TFrom, TTo>(fromModel);
            return mapper.Map<TFrom, TTo>(fromModel);
        }
    }
}
