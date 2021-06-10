using Microsoft.Practices.Unity;

namespace ShopBridge.Service.Infrastructure
{
    public static class IocEngine
    {
        public static IUnityContainer Container { get; private set; }
        static IocEngine()
        {
            Container = new UnityContainer();
        }
    }
}