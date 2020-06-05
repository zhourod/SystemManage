using System.ComponentModel.DataAnnotations;

namespace ZhouRod.SystemManage.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}