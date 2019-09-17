
namespace Prism.Ex.App.Common
{
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public abstract class BaseConfigManager : IConfigManager
    {
        protected Configuration Config { get; } = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
        {
            ExeConfigFilename = string.Concat(Assembly.GetCallingAssembly().Location, ".config")
        }, ConfigurationUserLevel.None);

        public virtual string ReadAppSetting(string key) => Config.AppSettings.Settings[key].Value;

        public void RemoveAppSetting(string key)
        {
            if (Config.AppSettings.Settings.AllKeys.Contains(key))
            {
                Config.AppSettings.Settings.Remove(key);
            }
        }

        public virtual void SaveAppSetting(string key, string value)
        {
            if (Config.AppSettings.Settings.AllKeys.Contains(key))
            {
                var result = Config.AppSettings.Settings[key].Value;
                if (result != value)
                {
                    Config.AppSettings.Settings[key].Value = value;
                    Config.Save(ConfigurationSaveMode.Modified);
                }
            }
            else
            {
                Config.AppSettings.Settings.Add(key, value);
                Config.Save(ConfigurationSaveMode.Modified);
            }
        }

        public virtual string ReadConnectionString(string key) => Config.ConnectionStrings.ConnectionStrings[key].ConnectionString;

        public virtual string ReadAllText(string path) => File.ReadAllText(path);

        public virtual string ModuleVersion => ReadAppSetting(nameof(ModuleVersion));
    }
}
