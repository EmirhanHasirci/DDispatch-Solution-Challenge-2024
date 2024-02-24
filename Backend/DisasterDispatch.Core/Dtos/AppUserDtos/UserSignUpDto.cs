using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DisasterDispatch.Core.Dtos.AppUserDtos
{
    public class UserSignUpDto
    {
        [Display(Name = "Tc")]
        [DataType(DataType.Text)]
        [MinLength(11,ErrorMessage ="Tc kimlik değeriniz 11 haneli olmalıdır")]
        [Required(ErrorMessage = "Tc Zorunludur")]
        public string Tc { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        public string UserName { get; set; }
        [Display(Name = "İsim")]
        [Required(ErrorMessage = "İsim zorunludur")]
        public string Name { get; set; }
        [Display(Name = "Soyisim")]
        [Required(ErrorMessage = "Soyisim zorunludur")]
        public string Surname { get; set; }
        [Display(Name = "Mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Mail Zorunludur")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Zorunludur")]
        [MinLength(4, ErrorMessage = "Şifre en az 4 basamaktan oluşmalıdır")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifrenizi yeniden girmeniz zorunludur")]
        [Display(Name = "Şifre Yeniden")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler birbiriyle eşleşmiyor")]
        public string ConfirmPassword{ get; set; }
    }
}
