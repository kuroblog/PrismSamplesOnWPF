
namespace Prism.Ex.App.Common
{
    using System.Configuration;
    using System.Linq;

    public static class ConfigurationExtensions
    {
        public static void Save(this Configuration config, string key, string value, string sectionName)
        {
            if (config.AppSettings.Settings.AllKeys.Contains(key))
            {
                var result = config.AppSettings.Settings[key].Value;
                if (result != value)
                {
                    config.AppSettings.Settings[key].Value = value;
                    config.Save(ConfigurationSaveMode.Modified);
                }
            }
            else
            {
                config.AppSettings.Settings.Add(key, value);
                config.Save(ConfigurationSaveMode.Modified);
            }

            ConfigurationManager.RefreshSection(sectionName);
        }

        public static void SaveAppSetting(this Configuration config, string key, string value) => config.Save(key, value, "appSettings");
    }
}
