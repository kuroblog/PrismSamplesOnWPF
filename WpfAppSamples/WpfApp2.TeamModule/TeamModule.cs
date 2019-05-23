
namespace WpfApp2.TeamModule
{
    using Prism.Ioc;
    using Prism.Modularity;
    using WpfApp2.TeamModule.UserControls;

    public class TeamModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Team>();
        }
    }
}
