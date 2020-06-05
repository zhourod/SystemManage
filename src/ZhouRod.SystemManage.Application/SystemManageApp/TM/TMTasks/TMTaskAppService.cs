using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZhouRod.SystemManage.SystemManage.TM;
using ZhouRod.SystemManage.SystemManageApp.TM.TMTasks.Dto;

namespace ZhouRod.SystemManage.SystemManageApp.TM.TMTasks
{
    public class TMTaskAppService : AsyncCrudAppService<TMTask, TMTaskDto, int, PagedTMTaskResultRequestDto, TMTaskDto, TMTaskDto>, ITMTaskAppService
    {
        private readonly IRepository<TMTask> _tMTaskRepository;

        public TMTaskAppService(IRepository<TMTask> tMTaskRepository)
            : base(tMTaskRepository)
        {
            _tMTaskRepository = tMTaskRepository;


            LocalizationSourceName = SystemManageConsts.LocalizationSourceName;
        }

        //public List<TMTask> GetAllWithPeople(int? assignedPersonId, TaskState? state)
        //{
        //    var query = _tMTaskRepository.GetAll();
        //    //Add some Where conditions...

        //    if (assignedPersonId.HasValue)
        //    {
        //        query = query.Where(task => task.AssignedPerson.Id == assignedPersonId.Value);
        //    }

        //    if (state.HasValue)
        //    {
        //        query = query.Where(task => task.State == state);
        //    }

        //    return query
        //        .OrderByDescending(task => task.CreationTime)
        //        .Include(task => task.AssignedPerson) //Include assigned person in a single query
        //        .ToList();
        //}

        //public GetTasksOutput GetTasks(GetTasksInput input)
        //{
        //    //Called specific GetAllWithPeople method of task repository.
        //    var tasks = GetAllWithPeople(input.AssignedPersonId, input.State);

        //    //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
        //    return new GetTasksOutput
        //    {
        //        Tasks = ObjectMapper.Map<List<TMTaskDto>>(tasks)

        //    };
        //}

        //public async Task<List<TMTask>> GetAllWithStatus(PagedTMTaskResultRequestDto input)
        //{
        //    var temp =  _tMTaskRepository.GetAllList()
        //        .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Description.Contains(input.Keyword))
        //        .WhereIf(input.State.HasValue, x => x.State == input.State)
        //        .WhereIf(input.AssignedPersonId.HasValue, x => x.AssignedPersonId == input.AssignedPersonId)
        //        .AsQueryable();
        //    var temp1 =  temp.OrderBy(r => r.Id)
        //        .Include(task => task.AssignedPerson);
        //    return ObjectMapper.Map<List<TMTask>>(temp1);
        //    //return temp1;


        //    //var tMTasks = await _tMTaskRepository.GetAllListAsync();
        //    //return tMTasks;
        //    //.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Description.Contains(input.Keyword))
        //    //.WhereIf(input.State.HasValue, x => x.State == input.State)
        //    //.WhereIf(input.AssignedPersonId.HasValue, x => x.AssignedPersonId == input.AssignedPersonId)
        //    ;
        //}

        protected override IQueryable<TMTask> CreateFilteredQuery(PagedTMTaskResultRequestDto input)
        {
            return  Repository.GetAllIncluding(task => task.AssignedPerson)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Description.Contains(input.Keyword))
                .WhereIf(input.State.HasValue, x => x.State == input.State)
                .WhereIf(input.AssignedPersonId.HasValue, x => x.AssignedPersonId == input.AssignedPersonId)
                ;

        }

        protected override IQueryable<TMTask> ApplySorting(IQueryable<TMTask> query, PagedTMTaskResultRequestDto input)
        {
            return query.OrderBy(r => r.Id);
            
              //  .Include(task => task.AssignedPerson)
        }


        public override async Task<TMTaskDto> GetAsync(EntityDto<int> input)
        {
            var tMTask = await _tMTaskRepository.GetAll().FirstOrDefaultAsync(x => x.Id == input.Id);
            if (tMTask == null)
            {
                throw new EntityNotFoundException(typeof(TMTask), input.Id);
            }
            return ObjectMapper.Map<TMTaskDto>(tMTask);
        }

        public override async Task<TMTaskDto> CreateAsync(TMTaskDto input)
        {
            
            var entity = ObjectMapper.Map<TMTask>(input);
            //entity.CreationTime = DateTime.UtcNow;
            await _tMTaskRepository.InsertAsync(entity);
            return MapToEntityDto(entity);
        }

        public override async Task<TMTaskDto> UpdateAsync(TMTaskDto input)
        {
            //var entity = await _equipmentTypeRepository.GetAsync(input.Id);
            var entity = await _tMTaskRepository.GetAll().FirstOrDefaultAsync(x => x.Id == input.Id);

            ObjectMapper.Map(input, entity);

            await _tMTaskRepository.UpdateAsync(entity);

            return MapToEntityDto(entity);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var entity = await _tMTaskRepository.GetAsync(input.Id);
            await _tMTaskRepository.DeleteAsync(entity);
        }
    }
}
