using System;

namespace ShopBridge.Model
{
    public class ExceptionLogData
    {
        public ExceptionLogData()
        {
            ReferenceId = Guid.NewGuid().ToString();
        }

        public string ReferenceId { get; private set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
