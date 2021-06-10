using ShopBridge.Model;
using System.Net;

namespace ShopBridge.Helper
{
    public static class Response<T>
    {
        /// <summary>
        /// Extension method to generate success response
        /// </summary>
        /// <param name="data">Data to be returned</param>
        /// <param name="message">Success message if any</param>
        /// <param name="totalRecordCount">Total record count to be used in listing response</param>
        /// <returns>Success response</returns>
        public static ResponseData<T> AsSuccess(T data, string message = "", int totalRecordCount = 0)
        {
            ResponseData<T> response = new ResponseData<T>();

            response.IsSuccess = true;
            response.Message = message;
            response.Status = HttpStatusCode.OK;
            response.Data = data;
            response.TotalRecordCount = totalRecordCount;

            return response;
        }

        /// <summary>
        /// Extension method to generate failure response
        /// </summary>
        /// <param name="message">failure message</param>
        /// <param name="status">Http Status of fail</param>
        /// <returns>Failure response</returns>
        public static ResponseData<T> AsFailure(string message = "", HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            ResponseData<T> response = new ResponseData<T>();

            response.IsSuccess = false;
            response.Message = message;
            response.Status = status;
            
            return response;
        }
    }
}
