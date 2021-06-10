using ShopBridge.DataAdapter.Contract;

namespace ShopBridge.DataAdapter.Repository
{
    public class ExceptionLoggerRepository : IExceptionLoggerRepository
    {
        /// <summary>
        /// Log exception in database
        /// </summary>
        /// <param name="entity">Exception log entity</param>
        /// <returns>True/False based on exception successfully logged or not</returns>
        public bool Save(ExceptionLog exception)
        {
            using (var context = new ShopBridgeEntities())
            {
                context.ExceptionLogs.Add(exception);
                context.SaveChanges();
                return true;
            }
        }
    }
}
