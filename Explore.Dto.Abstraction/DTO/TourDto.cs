using System.ComponentModel.DataAnnotations;

namespace ExploreSolution.DTO
{
    public class TourDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        // [Column(TypeName = "money")]
        public decimal Price { get; set; }

        // [Column(TypeName = "varchar(MAX)")]
        public string Notes { get; set; }
    }
}
