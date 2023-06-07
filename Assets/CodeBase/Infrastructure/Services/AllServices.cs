namespace CodeBase.Infrastructure.Services
{
    public class AllServices
    {
        private static AllServices instance;
        public static AllServices Container => instance ??= new AllServices();

        public void RegisterSingle<TService>(TService implementation) where TService : IService
        {
            Implementation<TService>.serviceInstance = implementation;
        }

        public TService Single<TService>() where TService : IService
        {
            return Implementation<TService>.serviceInstance;
        }

        private static class Implementation<TService> where TService : IService
        {
            public static TService serviceInstance;
        }
    }
}