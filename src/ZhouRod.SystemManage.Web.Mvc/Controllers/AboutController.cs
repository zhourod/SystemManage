using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using ZhouRod.SystemManage.Controllers;

namespace ZhouRod.SystemManage.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : SystemManageControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
