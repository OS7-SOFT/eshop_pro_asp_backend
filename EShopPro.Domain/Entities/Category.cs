using EShopPro.Domain.Common;

namespace EShopPro.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
