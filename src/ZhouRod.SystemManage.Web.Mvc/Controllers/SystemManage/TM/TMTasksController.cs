using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZhouRod.SystemManage.Authorization;
using ZhouRod.SystemManage.Controllers;
using ZhouRod.SystemManage.SystemManageApp.TM.People;
using ZhouRod.SystemManage.SystemManageApp.TM.TMTasks;
using ZhouRod.SystemManage.SystemManageApp.TM.TMTasks.Dto;
using ZhouRod.SystemManage.Web.Models.SystemManage.TM.TMTasks;

namespace ZhouRod.SystemManage.Web.Controllers.SystemManage.TM
{
    [AbpAuthorize(PermissionNames.Pages_TMTasks)]
    public class TMTasksController : SystemManageControllerBase
    {
        private readonly ITMTaskAppService _tMTaskAppService;
        private readonly IPersonAppService _personAppService;

        public TMTasksController(ITMTaskAppService tMTaskAppService, IPersonAppService personAppService)
        {
            _tMTaskAppService = tMTaskAppService;
            _personAppService = personAppService;
        }

        public async Task<IActionResult> Index()
        {
            var modelDto = (await _tMTaskAppService
                .GetAllAsync(new PagedTMTaskResultRequestDto
                {
                    //MaxResultCount = int.MaxValue
                    MaxResultCount = 10
                })
                ).Items;
            var pmodelDto = (await _personAppService
                .GetAllPeople());
            var viewModel = new TMTaskListViewModel
            {
                TMTasks = modelDto,
                TMPersons = pmodelDto
            };
            return View(viewModel);
        }

        public async Task<ActionResult> EditModal(int id)
        {
            var modelDto = await _tMTaskAppService.GetAsync(new EntityDto(id));
            var pmodelDto = (await _personAppService
                .GetAllPeople());
            var editViewModel = new EditTMTaskModalViewModel
            {
                TMTask = modelDto,
                TMPersons = pmodelDto
            };
            return View("_EditModal", editViewModel);
        }
    }
}