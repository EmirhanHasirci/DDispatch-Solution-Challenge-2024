using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DisasterDispatch.Core.Dtos.AppUserDtos
{
   public class UserLoginDto
    {
        [Display(Name = "Tc")]
        [DataType(DataType.Text)]
        [MinLength(11, ErrorMessage = "Tc kimlik değeriniz 11 haneli olmalıdır")]
        [Required(ErrorMessage = "Tc Zorunludur")]
        public string Tc { get; set; }
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Zorunludur")]
        [MinLength(4, ErrorMessage = "Şifre en az 4 basamaktan oluşmalıdır")]
        public string Password { get; set; }
    }
}
