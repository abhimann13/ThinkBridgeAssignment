using ShopBridge.DataAdapter.Contract;
using ShopBridge.DataAdapter.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ShopBridge.DataAdapter.Repository
{
    public class ItemRepository : IItemRepository
    {
        /// <summary>
        /// Get items as per search criteria
        /// </summary>
        /// <param name="request">Search criteria</param>
        /// <returns>Items</returns>
        public async Task<List<Item>> Get(ListingRequest request)
        {
            using (var context = new ShopBridgeEntities())
            {
                var totalRecordCount = new SqlParameter("totalRecordCount", request.TotalRecordCount);
                totalRecordCount.Direction = ParameterDirection.Output;

                var items = await context.Database.SqlQuery<Item>("exec dbo.spGetItems @search,@pageIndex,@pageSize,@totalRecordCount output",
                    new SqlParameter("search", SqlDbType.NVarChar, 50) { Value = (request.Search == null) ? string.Empty : request.Search },
                    new SqlParameter("pageIndex", SqlDbType.Int) { Value = request.PageIndex },
                    new SqlParameter("pageSize", SqlDbType.Int) { Value = request.PageSize },
                    totalRecordCount).ToListAsync();
                request.TotalRecordCount = Convert.ToInt32(totalRecordCount.Value);
                return items;
            }
        }

        /// <summary>
        /// Get specific item by id
        /// </summary>
        /// <param name="itemId">Item id</param>
        /// <returns>Item</returns>
        public async Task<Item> GetById(int itemId)
        {
            using (var context = new ShopBridgeEntities())
            {
                return await context.Items.FirstOrDefaultAsync(x => x.ItemID == itemId);
            }
        }

        /// <summary>
        /// Add/Update item
        /// </summary>
        /// <param name="item">Item detail</param>
        /// <returns>Generated Item id otherwise failure message</returns>
        public async Task<Tuple<int, string>> Save(Item item)
        {
            using (var context = new ShopBridgeEntities())
            {
                if (item.ItemID > 0)
                {
                    var itemToUpdate = await context.Items.FirstOrDefaultAsync(x => x.ItemID == item.ItemID);
                    if (itemToUpdate != null)
                    {
                        itemToUpdate.Name = item.Name;
                        itemToUpdate.Description = item.Description;
                        itemToUpdate.Price = item.Price;
                        itemToUpdate.ModifiedDate = item.ModifiedDate;
                        context.Entry(itemToUpdate).State = EntityState.Modified;
                    }
                    else
                    {
                        return new Tuple<int,string>(0, "Item not found");
                    }
                }
                else
                {
                    context.Items.Add(item);
                }

                await context.SaveChangesAsync();
                return new Tuple<int, string>(item.ItemID, string.Empty);
            }
        }

        /// <summary>
        /// Soft delete item
        /// </summary>
        /// <param name="itemId">Item id</param>
        /// <returns>True/False if removed else failure message</returns>
        public async Task<Tuple<bool,string>> Remove(int itemId)
        {
            using (var context = new ShopBridgeEntities())
            {
                var itemToRemove = await context.Items.FirstOrDefaultAsync(x => x.ItemID == itemId);
                if (itemToRemove != null)
                {
                    if (itemToRemove.IsActive)
                    {
                        itemToRemove.IsActive = false;
                        itemToRemove.ModifiedDate = System.DateTime.Now;

                        await context.SaveChangesAsync();
                        return new Tuple<bool, string>(true, string.Empty);
                    }
                    else
                        return new Tuple<bool, string>(false, "Item already removed");
                }
                else
                {
                    return new Tuple<bool, string>(false, "Item not found");
                }
            }
        }
    }
}
