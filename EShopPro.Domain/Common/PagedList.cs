

namespace EShopPro.Domain.Common
{
    public class PagedList<T>
    {
        public List<T> Items { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalRecords { get; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
        public bool HasNextPage => PageNumber < TotalPages;
        public bool HasPreviousPage => PageNumber > 1;

        private PagedList(List<T> items, int pageNumber, int pageSize, int totalRecords)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
        }

        public static PagedList<T> Create(List<T> items, int pageNumber, int pageSize, int totalRecords)
            => new PagedList<T>(items, pageNumber, pageSize, totalRecords);
    }
}
