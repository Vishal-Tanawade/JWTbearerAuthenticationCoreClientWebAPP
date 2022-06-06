using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWTbearerAuthenticationCoreClientWebAPP.Models
{
    public class UserModel
    {
        [DisplayName("Email")]
        [EmailAddress]
        [Required(ErrorMessage = "Enail id can`t be blank")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")]
        [Required(ErrorMessage = "Password can`t be blank")]
        public string Password { get; set; }

    }
}
