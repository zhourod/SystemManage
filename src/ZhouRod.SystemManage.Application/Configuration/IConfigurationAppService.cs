using System.Threading.Tasks;
using ZhouRod.SystemManage.Configuration.Dto;

namespace ZhouRod.SystemManage.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
