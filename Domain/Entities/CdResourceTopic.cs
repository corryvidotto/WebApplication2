using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Domain.Entities
{
    public class CdResourceTopic
    {
        public int TopicId { get; set; }
        [MaxLength(50)]
        public string? TopicName { get; set; }
    }
}
