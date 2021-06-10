namespace ShopBridge.DataAdapter.Contract
{
    public interface IExceptionLoggerRepository
    {
        /// <summary>
        /// Log exception in database
        /// </summary>
        /// <param name="entity">Exception log entity</param>
        /// <returns>True/False based on exception successfully logged or not</returns>
        bool Save(ExceptionLog entity);
    }
}
