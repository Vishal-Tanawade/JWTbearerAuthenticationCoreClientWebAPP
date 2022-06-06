using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWTbearerAuthenticationCoreClientWebAPP.Models
{
    //This class used at the time of login for dropdown list user type
    public class UserType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTypeId { get; set; }

        [DisplayName("User Type")]
        [Required(ErrorMessage = "Login type should not be blank eg. Manager / User")]
        [StringLength(30, MinimumLength = 5)]
        public string UserTypeName { get; set; }

    }
}
