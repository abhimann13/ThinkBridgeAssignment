using ShopBridge.Business.Contract;
using ShopBridge.DataAdapter;
using ShopBridge.DataAdapter.Contract;
using ShopBridge.DataAdapter.Model;
using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Business.Impl
{
    public class ItemManager : IItemManager
    {
        private readonly IItemRepository _itemRepository;

        /// <summary>
        /// Constructor to instantiate repository
        /// </summary>
        /// <param name="itemRepository">Item Repo</param>
        public ItemManager(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        /// <summary>
        /// Get items as per search criteria
        /// </summary>
        /// <param name="requestData">Search criteria</param>
        /// <returns>Items</returns>
        public async Task<IList<ItemData>> Get(ListingRequestData requestData)
        {
            IList<ItemData> itemDataList;

            var request = EntityMapper.Map<ListingRequest>(requestData);
            var items = await _itemRepository.Get(request);

            itemDataList = EntityMapper.Map<IList<ItemData>>(items);
            requestData.TotalRecordCount = request.TotalRecordCount;

            return itemDataList;
        }

        /// <summary>
        /// Get specific item by id
        /// </summary>
        /// <param name="itemId">Item id</param>
        /// <returns>Item</returns>
        public async Task<ItemData> GetById(int itemId)
        {
            ItemData itemData;
            
            var item = await _itemRepository.GetById(itemId);
            itemData = EntityMapper.Map<ItemData>(item);

            return itemData;
        }

        /// <summary>
        /// Add/Update item
        /// </summary>
        /// <param name="itemData">Item model</param>
        /// <returns>Generated Item id otherwise failure message</returns>
        public async Task<Tuple<int, string>> Save(ItemData itemData)
        {
            var item = EntityMapper.Map<Item>(itemData);
            
            if(itemData.ItemID > 0)
            {
                item.ModifiedDate = System.DateTime.Now;
            }
            else
            {
                item.IsActive = true;
                item.CreatedDate = System.DateTime.Now;
            }

            var result = await _itemRepository.Save(item);
            return result;
        }

        /// <summary>
        /// Soft delete item
        /// </summary>
        /// <param name="itemId">Item id</param>
        /// <returns>True/False if removed else failure message</returns>
        public async Task<Tuple<bool,string>> Remove(int itemId)
        {
            var result = await _itemRepository.Remove(itemId);
            return result;
        }
    }
}
