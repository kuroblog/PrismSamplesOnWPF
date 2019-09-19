
namespace Prism.Ex.App.Common
{
    using System;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows;

    [ExcludeFromCodeCoverage]
    public abstract class BaseConfigManager : IConfigManager
    {
        protected virtual Configuration Config { get; } = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
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

        public virtual void SaveAppSetting(string key, string value) =>

            //if (Config.AppSettings.Settings.AllKeys.Contains(key))
            //{
            //    var result = Config.AppSettings.Settings[key].Value;
            //    if (result != value)
            //    {
            //        Config.AppSettings.Settings[key].Value = value;
            //        Config.Save(ConfigurationSaveMode.Modified);
            //    }
            //}
            //else
            //{
            //    Config.AppSettings.Settings.Add(key, value);
            //    Config.Save(ConfigurationSaveMode.Modified);
            //}

            Config.SaveAppSetting(key, value);

        public virtual string ReadConnectionString(string key) => Config.ConnectionStrings.ConnectionStrings[key].ConnectionString;

        public virtual string ReadAllText(string path) => File.ReadAllText(path);

        public virtual string ModuleVersion => ReadAppSetting(nameof(ModuleVersion));

        protected readonly Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public virtual string DisplayLanguage => appConfig.AppSettings.Settings[nameof(DisplayLanguage)].Value;
        // or
        //public virtual string DisplayLanguage => (appConfig.GetSection("appSettings") as AppSettingsSection).Settings[nameof(DisplayLanguage)].Value;

        public virtual void SetDisplayLanguage(string language = "")
        {
            if (string.IsNullOrEmpty(language))
            {
                language = DisplayLanguage;
            }

            var languageResources = Application.Current.Resources.MergedDictionaries?.FirstOrDefault(p => p.Source.OriginalString.ToLower().Contains(language.ToLower()));
            if (languageResources != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(languageResources);
            }
            else
            {
                languageResources = new ResourceDictionary { Source = new Uri($"/Prism.Ex.App.Asset;component/Languages/{language}.xaml", UriKind.RelativeOrAbsolute) };
            }

            Application.Current.Resources.MergedDictionaries.Add(languageResources);

            appConfig.SaveAppSetting(nameof(DisplayLanguage), language);
        }
    }
}
