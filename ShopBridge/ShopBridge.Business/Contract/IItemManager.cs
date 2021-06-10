using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Business.Contract
{
    public interface IItemManager
    {
        /// <summary>
        /// Get items as per search criteria
        /// </summary>
        /// <param name="requestData">Search criteria</param>
        /// <returns>Items</returns>
        Task<IList<ItemData>> Get(ListingRequestData requestData);

        /// <summary>
        /// Get specific item by id
        /// </summary>
        /// <param name="itemId">Item id</param>
        /// <returns>Item</returns>
        Task<ItemData> GetById(int itemId);

        /// <summary>
        /// Add/Update item
        /// </summary>
        /// <param name="itemData">Item model</param>
        /// <returns>Generated Item id otherwise failure message</returns>
        Task<Tuple<int, string>> Save(ItemData item);

        /// <summary>
        /// Soft delete item
        /// </summary>
        /// <param name="itemId">Item id</param>
        /// <returns>True/False if removed else failure message</returns>
        Task<Tuple<bool, string>> Remove(int itemId);
    }
}
