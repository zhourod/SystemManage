using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZhouRod.SystemManage.Authorization;
using ZhouRod.SystemManage.Controllers;
using ZhouRod.SystemManage.SystemManageApp.SM;
using ZhouRod.SystemManage.SystemManageApp.SM.Dto;
using ZhouRod.SystemManage.Web.Models.SystemManage.SM.SMUsers;

namespace ZhouRod.SystemManage.Web.Controllers
{
    [AbpAuthorize(PermissionNames.Pages_SMusers)]
    public class SMUsersController : SystemManageControllerBase
    {
        private readonly ISMUserAppService _sMUserAppService;

        public SMUsersController(ISMUserAppService sMUserAppService)
        {
            _sMUserAppService = sMUserAppService;
        }

        public async Task<IActionResult> Index()
        {
            var modelDto = (await _sMUserAppService
                .GetAllAsync(new PagedSMUserResultRequestDto
                {
                    //MaxResultCount = int.MaxValue
                    MaxResultCount = 10
                })
                ).Items;
            var viewModel = new SMUserListViewModel
            {
                SMUsers = modelDto
            };
            return View( viewModel);
        }

        public async Task<ActionResult> EditModal(int id)
        {
            var modelDto = await _sMUserAppService.GetAsync(new EntityDto(id));
            var editViewModel = new EditSMUserModalViewModel
            {
                SMUser = modelDto
            };
            return View("_EditModal", editViewModel);
        }
    }
}