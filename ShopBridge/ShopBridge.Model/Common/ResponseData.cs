using System.Net;

namespace ShopBridge.Model
{
    public class ResponseData<TEntity>
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public TEntity Data { get; set; }
        public int TotalRecordCount { get; set; }
    }
}
