namespace ShopBridge.DataAdapter.Model
{
    public class ListingRequest
    {
        public string Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecordCount { get; set; }
    }
}
