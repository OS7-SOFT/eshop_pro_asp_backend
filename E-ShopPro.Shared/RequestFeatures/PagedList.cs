namespace E_ShopPro.Shared.RequestFeatures
{
    public class PagedList<T>
    {
        public List<T> Items { get; }
        public MetaData MetaData { get; set; }
        private PagedList(List<T> items, int pageNumber, int pageSize, int totalRecords)
        {
            Items = items;
            MetaData = new MetaData
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
            };
        }

        public static PagedList<T> Create(List<T> items, int pageNumber, int pageSize, int totalRecords)
            => new PagedList<T>(items, pageNumber, pageSize, totalRecords);
    }
}
