namespace E_ShopPro.Shared.RequestFeatures
{
    public class MetaData
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get;set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
        public bool HasNextPage => PageNumber < TotalPages;
        public bool HasPreviousPage => PageNumber > 1;
    }
}
