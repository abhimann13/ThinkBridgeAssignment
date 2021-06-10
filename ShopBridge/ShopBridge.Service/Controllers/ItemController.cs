using Microsoft.Practices.Unity;
using ShopBridge.Business.Contract;
using ShopBridge.Helper;
using ShopBridge.Model;
using ShopBridge.Service.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopBridge.Service.Controllers
{
    public class ItemController : ApiController
    {
        private readonly IItemManager _itemManager;

        /// <summary>
        /// Constructor to resolve manager dependency
        /// </summary>
        public ItemController()
        {
            _itemManager = IocEngine.Container.Resolve<IItemManager>();
        }

        /// <summary>
        /// Get items as per search criteria
        /// </summary>
        /// <param name="requestData">Search criteria</param>
        /// <returns>Items</returns>
        [HttpPost]
        public async Task<ResponseData<IList<ItemData>>> Get(ListingRequestData requestData)
        {
            requestData = requestData ?? new ListingRequestData();
            var items = await _itemManager.Get(requestData).ConfigureAwait(false);

            return Response<IList<ItemData>>.AsSuccess(items, totalRecordCount:requestData.TotalRecordCount);
        }

        /// <summary>
        /// Get specific item by id
        /// </summary>
        /// <param name="id">Item id</param>
        /// <returns>Item</returns>
        [HttpGet]
        public async Task<ResponseData<ItemData>> GetById(int id)
        {
            if (id > 0)
            {
                var item = await _itemManager.GetById(id).ConfigureAwait(false);

                if (item != null)
                    return Response<ItemData>.AsSuccess(item);
                else
                    return Response<ItemData>.AsFailure("Item not found");
            }
            else
                return Response<ItemData>.AsFailure("Item id is required");
        }

        /// <summary>
        /// Add/Update item
        /// </summary>
        /// <param name="item">Item model</param>
        /// <returns>Success/Failure response</returns>
        [HttpPost]
        public async Task<ResponseData<int>> Save(ItemData item)
        {
            if (ModelState.IsValid)
            {
                var result = await _itemManager.Save(item).ConfigureAwait(false);

                if (result.Item1 > 0)
                    return Response<int>.AsSuccess(result.Item1); 
                else
                    return Response<int>.AsFailure(result.Item2);
            }
            else
            {
                return Response<int>.AsFailure();
            }
        }

        /// <summary>
        /// Soft delete item
        /// </summary>
        /// <param name="itemId">Item id</param>
        /// <returns>True/false based on operation succeed or failed</returns>
        [HttpPost]
        public async Task<ResponseData<bool>> Remove([FromBody]int itemId)
        {
            var result = await _itemManager.Remove(itemId).ConfigureAwait(false);

            if (result.Item1)
                return Response<bool>.AsSuccess(result.Item1);
            else
                return Response<bool>.AsFailure(result.Item2);
        }
    }
}
