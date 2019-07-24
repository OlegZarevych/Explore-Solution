using Explore.DataAccess.Abstraction.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace Explore.DataAccess.Abstraction.Entities
{
    public class ReservationEntity : IEntity
    {
        [Key]
        public int ReservationId { get; set; }

        public int TourId { get; set; }

        [Required]
        [StringLength(200)]
        public string CustomerFullName { get; set; }

        [Required]
        [StringLength(15)]
        public string CustomerPhone { get; set; }

        public TourEntity Tour { get; set; }

    }
}