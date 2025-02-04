namespace EShopPro.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? updatedDate { get; set; }

    }
}
