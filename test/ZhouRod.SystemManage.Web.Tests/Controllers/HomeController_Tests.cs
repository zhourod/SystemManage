using System.Threading.Tasks;
using ZhouRod.SystemManage.Models.TokenAuth;
using ZhouRod.SystemManage.Web.Controllers;
using Shouldly;
using Xunit;

namespace ZhouRod.SystemManage.Web.Tests.Controllers
{
    public class HomeController_Tests: SystemManageWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}