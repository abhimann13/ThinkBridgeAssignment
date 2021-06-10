using ShopBridge.DataAdapter.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.DataAdapter.Contract
{
    public interface IItemRepository
    {
        /// <summary>
        /// Get items as per search criteria
        /// </summary>
        /// <param name="request">Search criteria</param>
        /// <returns>Items</returns>
        Task<List<Item>> Get(ListingRequest request);

        /// <summary>
        /// Get specific item by id
        /// </summary>
        /// <param name="itemId">Item id</param>
        /// <returns>Item</returns>
        Task<Item> GetById(int itemId);

        /// <summary>
        /// Add/Update item
        /// </summary>
        /// <param name="item">Item detail</param>
        /// <returns>Generated Item id otherwise failure message</returns>
        Task<Tuple<int, string>> Save(Item item);

        /// <summary>
        /// Soft delete item
        /// </summary>
        /// <param name="itemId">Item id</param>
        /// <returns>True/False if removed else failure message</returns>
        Task<Tuple<bool, string>> Remove(int itemId);
    }
}
