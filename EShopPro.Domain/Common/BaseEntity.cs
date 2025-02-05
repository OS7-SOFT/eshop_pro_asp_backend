using System.ComponentModel.DataAnnotations;

namespace EShopPro.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? updatedDate { get; set; }

    }
}
