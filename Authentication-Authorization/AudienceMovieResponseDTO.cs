namespace MovieManagementSystem.DTOs
{
    public class AudienceMovieResponseDTO
    {
        public string Title { get; set; }
        public string Hero { get; set; }
        public string Heroine { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
        public decimal Rating { get; set; }
        public DateOnly ReleasedDate { get; set; }

    }
}
