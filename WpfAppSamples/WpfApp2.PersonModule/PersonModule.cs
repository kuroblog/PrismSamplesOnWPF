
namespace WpfApp2.PersonModule
{
    using Prism.Ioc;
    using Prism.Modularity;
    using WpfApp2.PersonModule.UserControls;

    public class PersonModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Person>();
        }
    }
}
