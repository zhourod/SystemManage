using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhouRod.SystemManage.SystemManage.SM;
using ZhouRod.SystemManage.SystemManageApp.SM.Dto;

namespace ZhouRod.SystemManage.SystemManageApp.SM
{
    public class SMUserAppService : AsyncCrudAppService<SMUser, SMUserDto, int, PagedSMUserResultRequestDto, SMUserDto, SMUserDto>, ISMUserAppService
    {
        private readonly IRepository<SMUser> _sMUserRepository;

        public SMUserAppService(IRepository<SMUser> sMUserRepository)
            : base(sMUserRepository)
        {
            _sMUserRepository = sMUserRepository;

            LocalizationSourceName = SystemManageConsts.LocalizationSourceName;
        }

        public override async Task<SMUserDto> GetAsync(EntityDto<int> input)
        {
            var sMUser = await _sMUserRepository.GetAll().FirstOrDefaultAsync(x => x.Id == input.Id);
            if (sMUser == null)
            {
                throw new EntityNotFoundException(typeof(SMUser), input.Id);
            }
            return ObjectMapper.Map<SMUserDto>(sMUser);
        }

        protected override IQueryable<SMUser> CreateFilteredQuery(PagedSMUserResultRequestDto input)
        {
            return Repository.GetAll()

                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.UserAccount.Contains(input.Keyword) || x.Email.Contains(input.Keyword))
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);
        }

        protected override IQueryable<SMUser> ApplySorting(IQueryable<SMUser> query, PagedSMUserResultRequestDto input)
        {
            return query.OrderBy(r => r.UserAccount);
        }

        public override async Task<SMUserDto> CreateAsync(SMUserDto input)
        {

            //判断CODE是否已存在
            var model = await _sMUserRepository.GetAllIncluding().FirstOrDefaultAsync(x => x.UserAccount == input.UserAccount);
            if (model != null)
            {
                throw new UserFriendlyException(L("SMUser UserAccount already exists"));
            }

            //检查是否已被软删除，已经软删除的数据，无法通过
            using (UnitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                //判断CODE是否已存在
                var model0 = await _sMUserRepository.GetAllIncluding().FirstOrDefaultAsync(x => x.UserAccount == input.UserAccount);
                if (model0 != null)
                {
                    throw new UserFriendlyException(L("SMUser UserAccount is deleted"));
                }
            }

            var entity = ObjectMapper.Map<SMUser>(input);
            await _sMUserRepository.InsertAsync(entity);
            return MapToEntityDto(entity);
        }

        public override async Task<SMUserDto> UpdateAsync(SMUserDto input)
        {
            //var entity = await _equipmentTypeRepository.GetAsync(input.Id);
            var entity = await _sMUserRepository.GetAll().FirstOrDefaultAsync(x => x.Id == input.Id);

            ObjectMapper.Map(input, entity);

            entity.LastModificationTime = DateTime.Now;
            entity.LastModifierUserId = 1;

            await _sMUserRepository.UpdateAsync(entity);

            return MapToEntityDto(entity);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var entity = await _sMUserRepository.GetAsync(input.Id);
            await _sMUserRepository.DeleteAsync(entity);
        }
    }
}
