using Unity;
using Unity.Lifetime;

namespace Code_Submission_Gerald_A_Wakefield.Configuration
{
    public static class ServiceInjector
    {
        private static readonly IUnityContainer UnityContainer = new UnityContainer();
        public static void Register<T, I>() where I : T
        {
            UnityContainer.RegisterType<T, I>(new ContainerControlledLifetimeManager());
        }
        public static void InjectStub<T>(T instance)
        {
            UnityContainer.RegisterInstance(instance, new ContainerControlledLifetimeManager());
        }
        public static T Retrieve<T>()
        {
            return UnityContainer.Resolve<T>();
        }
    }
}
