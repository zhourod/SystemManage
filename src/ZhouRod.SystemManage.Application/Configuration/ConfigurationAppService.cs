using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ZhouRod.SystemManage.Configuration.Dto;

namespace ZhouRod.SystemManage.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SystemManageAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
