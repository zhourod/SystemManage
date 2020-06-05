using Abp.AutoMapper;
using ZhouRod.SystemManage.Authentication.External;

namespace ZhouRod.SystemManage.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
