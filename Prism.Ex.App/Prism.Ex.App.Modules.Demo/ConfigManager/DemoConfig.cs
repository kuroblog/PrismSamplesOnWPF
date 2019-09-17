
namespace Prism.Ex.App.Modules.Demo
{
    using Prism.Ex.App.Common;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class DemoConfig : BaseConfigManager
    {
        public string ModuleName => ReadAppSetting(nameof(ModuleName));
    }
}
