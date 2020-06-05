using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZhouRod.SystemManage.SystemManage.TM;
using ZhouRod.SystemManage.SystemManageApp.TM.People.Dto;

namespace ZhouRod.SystemManage.SystemManageApp.TM.People
{
    public class PersonAppService : SystemManageAppServiceBase, IPersonAppService
    {
        private readonly IRepository<TMPerson> _personRepository;

        //ABP provides that we can directly inject IRepository<Person> (without creating any repository class)
        public PersonAppService(IRepository<TMPerson> personRepository) 
            
        {
            _personRepository = personRepository;
            
        }

        //public async Task<GetAllPeopleOutput> GetAllPeople()
        //{
        //    var people = await _personRepository.GetAllListAsync();
        //    return new GetAllPeopleOutput
        //    {
        //        //People = people.MapTo<List<TMPersonDto>>()
        //        People = ObjectMapper.Map<List<TMPersonDto>>(people)
        //     };

            
        //}

        public async Task<List<TMPersonDto>> GetAllPeople()
        {
            var people = await _personRepository.GetAllListAsync();

            return ObjectMapper.Map<List<TMPersonDto>>(people);


        }

    }
}
