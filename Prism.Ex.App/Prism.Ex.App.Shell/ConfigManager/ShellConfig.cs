
namespace Prism.Ex.App.Shell
{
    using Prism.Ex.App.Common;

    public class ShellConfig : BaseConfigManager
    {
        public string ProductName => ReadAppSetting(nameof(ProductName));

        public double ShellWidth => double.TryParse(base.ReadAppSetting(nameof(ShellWidth)), out double width) ? width : 1280;

        public double ShellHeight => double.TryParse(ReadAppSetting(nameof(ShellHeight)), out double width) ? width : 960;
    }
}
