using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ZhouRod.SystemManage.Localization
{
    public static class SystemManageLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SystemManageConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SystemManageLocalizationConfigurer).GetAssembly(),
                        "ZhouRod.SystemManage.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
