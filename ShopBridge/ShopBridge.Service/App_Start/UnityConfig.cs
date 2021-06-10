using Microsoft.Practices.Unity;
using ShopBridge.Business.Contract;
using ShopBridge.Business.Impl;
using ShopBridge.DataAdapter.Contract;
using ShopBridge.DataAdapter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Service.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IExceptionLoggerRepository, ExceptionLoggerRepository>();
            
            container.RegisterType<IExceptionLoggerManager, ExceptionLoggerManager>(
                new InjectionConstructor(
                    container.Resolve<IExceptionLoggerRepository>()
                    )
                );

            container.RegisterType<IItemRepository, ItemRepository>();
            
            container.RegisterType<IItemManager, ItemManager>(
                new InjectionConstructor(
                    container.Resolve<IItemRepository>()
                    )
                );
        }
    }
}