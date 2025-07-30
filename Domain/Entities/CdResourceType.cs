using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Domain.Entities
{
    public class CdResourceType
    {
        public int ResourceTypeId { get; set; }
        [MaxLength(50)]
        public string? ResourceName { get; set; }
    }
}
