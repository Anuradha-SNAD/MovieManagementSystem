namespace MovieManagementSystem.DTOs
{
    public class MovieResponseDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public decimal Budget { get; set; }
        public decimal Collection { get; set; }
        public DateOnly ReleasedDate { get; set; }
        public decimal Rating { get; set; }
        public string Hero { get; set; }
        public string Heroine { get; set; }
        public string Producer { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
    }
}
