using ShopBridge.Business.Contract;
using ShopBridge.DataAdapter;
using ShopBridge.DataAdapter.Contract;
using ShopBridge.Model;

namespace ShopBridge.Business.Impl
{
    public class ExceptionLoggerManager : IExceptionLoggerManager
    {
        private readonly IExceptionLoggerRepository _exceptionLoggerRepository;

        /// <summary>
        /// Constructor to instantiate repository
        /// </summary>
        /// <param name="exceptionLoggerRepository">Exception log repo</param>
        public ExceptionLoggerManager(IExceptionLoggerRepository exceptionLoggerRepository)
        {
            _exceptionLoggerRepository = exceptionLoggerRepository;
        }

        /// <summary>
        /// Log exception in database
        /// </summary>
        /// <param name="exceptionData">Exception log model</param>
        /// <returns>True/False based on exception successfully logged or not</returns>
        public string Save(ExceptionLogData exceptionData)
        {
            var exception = EntityMapper.Map<ExceptionLog>(exceptionData);

            var result = _exceptionLoggerRepository.Save(exception);
            return exceptionData.ReferenceId;
        }
    }
}
