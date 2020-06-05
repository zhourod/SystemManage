using Abp.Domain.Entities;

namespace ZhouRod.SystemManage.SystemManage.TM
{
    public class TMPerson : Entity<int>
    {
        public string Name { get; set; }
    }
}
