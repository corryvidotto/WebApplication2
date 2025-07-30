using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Domain.Entities
{
    public class Resource
    {
        public int ResourceId { get; set; }
        [MaxLength(50)]
        public string? Title { get; set; }
        public int? ResourceTypeId { get; set; }
        public int? ResourceTopicId { get; set; }
    }
}
