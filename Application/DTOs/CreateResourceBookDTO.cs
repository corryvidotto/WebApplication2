namespace WebApplication2.Application.DTOs
{
    public class CreateResourceBookDTO
    {
        public string Title { get; set; }
        public int ResourceTypeId { get; set; }
        public int ResourceTopicId { get; set; }

        public string? Author { get; set; }
        public int Pages { get; set; }
        public double Cost { get; set; }
        public DateOnly PublishDate { get; set; }
    }
}
