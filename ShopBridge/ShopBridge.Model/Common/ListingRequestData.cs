namespace ShopBridge.Model
{
    public class ListingRequestData
    {
        public string Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecordCount { get; set; }
    }
}
