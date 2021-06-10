using ShopBridge.DataAdapter;
using ShopBridge.DataAdapter.Model;
using ShopBridge.Model;

namespace ShopBridge.Business
{
    public class EntityMapper
    {
        private static readonly object sync = new object();
        private static AutoMapper.IMapper mapper = null;
        private static AutoMapper.MapperConfiguration config = null;

        /// <summary>
        /// Instantiate Auto Mapper with mapping configuration
        /// </summary>
        public static void InitializeMapper()
        {
            if (mapper == null)
            {
                lock (sync)
                {
                    if (mapper == null)
                    {
                        config = new AutoMapper.MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<ItemData, Item>().ReverseMap();
                            cfg.CreateMap<ExceptionLogData, ExceptionLog>()
                                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => $"Reference ID : {src.ReferenceId}\n{src.Message}"));
                            cfg.CreateMap<ListingRequestData, ListingRequest>().ReverseMap();
                        });

                        mapper = config.CreateMapper();
                    }
                }
            }
        }

        /// <summary>
        /// Map source data to destination object
        /// </summary>
        /// <typeparam name="TDestination">Type of destination entity</typeparam>
        /// <param name="source">Source Object instance</param>
        /// <returns>returns the detination object instance</returns>
        public static TDestination Map<TDestination>(object source) where TDestination : class
        {
            if (mapper != null)
            {
                return mapper.Map<TDestination>(source);
            }
            else
            {
                return null;
            }
        }
    }
}