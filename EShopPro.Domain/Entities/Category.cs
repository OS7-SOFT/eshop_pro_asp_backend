using EShopPro.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace EShopPro.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
