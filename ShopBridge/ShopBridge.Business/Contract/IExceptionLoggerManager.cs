using ShopBridge.Model;

namespace ShopBridge.Business.Contract
{
    public interface IExceptionLoggerManager
    {
        /// <summary>
        /// Log exception in database
        /// </summary>
        /// <param name="exceptionData">Exception log model</param>
        /// <returns>True/False based on exception successfully logged or not</returns>
        string Save(ExceptionLogData exceptionData);
    }
}
