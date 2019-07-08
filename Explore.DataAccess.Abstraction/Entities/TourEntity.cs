using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Explore.DataAccess.Abstraction.Entities
{
    public class TourEntity
    {
        public int TourId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        // [Column(TypeName = "money")]
        public decimal Price { get; set; }

        // [Column(TypeName = "varchar(MAX)")]
        public string Notes { get; set; }

        public List<ReservationEntity> Reservations { get; set; }

    }
}