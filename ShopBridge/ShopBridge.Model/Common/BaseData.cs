using System;

namespace ShopBridge.Model
{
    public class BaseData
    {
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
