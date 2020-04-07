using AutoMapper;
using Explore.DataAccess.Abstraction.Entities;
using Explore.Dto.Abstraction.CustomMapper;
using Explore.Dto.Abstraction.DTO;

namespace Explore.Dto.Abstraction.Mapper
{
    public class ReservationMapper : BaseMapper<ReservationEntity, Reservation>
    {
        public static Reservation Map(ReservationEntity fromModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ReservationEntity, Reservation>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.ReservationId))
                .ForMember(x => x.TourId, s => s.MapFrom(x => x.Tour.TourId));
            });

            IMapper mapper = config.CreateMapper();

            return mapper.Map<ReservationEntity, Reservation>(fromModel);
        }
    }
}