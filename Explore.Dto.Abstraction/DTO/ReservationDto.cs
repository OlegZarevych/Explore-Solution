using System.ComponentModel.DataAnnotations;

namespace Explore.Dto.Abstraction.DTO
{
    public class ReservationDto
    {
        [Required]
        [StringLength(200)]
        public string CustomerFullName { get; set; }

        [Required]
        [StringLength(15)]
        public string CustomerPhone { get; set; }

        public int TourId { get; set; }

        public int PeopleCount { get; set; }

        public decimal ReservationPrice { get; set; }
    }
}
