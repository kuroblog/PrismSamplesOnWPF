
namespace Prism.Ex.App.Common
{
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public abstract class BaseConfigManager : IConfigManager
    {
        protected Configuration config { get; } = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
        {
            ExeConfigFilename = string.Concat(Assembly.GetCallingAssembly().Location, ".config")
        }, ConfigurationUserLevel.None);

        public virtual string ReadAppSetting(string key) => config.AppSettings.Settings[key].Value;

        public void RemoveAppSetting(string key)
        {
            if (config.AppSettings.Settings.AllKeys.Contains(key))
            {
                config.AppSettings.Settings.Remove(key);
            }
        }

        public virtual void SaveAppSetting(string key, string value)
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
        }

        public virtual string ReadConnectionString(string key) => config.ConnectionStrings.ConnectionStrings[key].ConnectionString;

        public virtual string ReadAllText(string path) => File.ReadAllText(path);

        public virtual string ModuleVersion => ReadAppSetting(nameof(ModuleVersion));
    }
}
