using System.ComponentModel.DataAnnotations;

namespace MovieManagementSystem.DTOs
{
    public class MovieRequestDTO
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Range(100000,double.MaxValue)]
        public decimal Budget { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Collection { get; set; }
        [Required]
        public DateOnly ReleasedDate { get; set; }
        [Range(1, 10)]
        public decimal Rating { get; set; }
        [Required]
        public string Hero { get; set; }
        [Required]
        public string Heroine { get; set; }
        [Required]
        public string Producer { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Language { get; set; }
    }
}
