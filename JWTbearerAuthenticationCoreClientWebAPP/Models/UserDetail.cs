using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWTbearerAuthenticationCoreClientWebAPP.Models
{
    public class UserDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }

        [DisplayName("First Name")]
        [StringLength(30, MinimumLength = 5)]//length
        [Required(ErrorMessage = "First Name can`t be blank")]
        public string FName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(30, MinimumLength = 5)]//length
        [Required(ErrorMessage = "Last Name can`t be blank")]
        public string LName { get; set; }

        [StringLength(30, MinimumLength = 8)]//length
        [DisplayName("UserName")]
        [Required(ErrorMessage = "User Name can`t be blank")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Date of Birth can`t be blank")]
        public DateTime Dob { get; set; }
        //[StringLength(6, MinimumLength = 4)]//length

        [Required(ErrorMessage = "Please select gender")]
        public string Gender { get; set; }

        [DisplayName("PhoneNumber")]
        [RegularExpression("^[5-9][0-9]{9}$")]//check reg expression_
        [Required(ErrorMessage = "Enter Correct Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Email")]
        [EmailAddress]
        [Required(ErrorMessage = "Enail id can`t be blank")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")]
        [Required(ErrorMessage = "Password can`t be blank")]
        public string Password { get; set; }

        [ForeignKey("SecurityQuestion")]
        [Required(ErrorMessage = "Select Security Question")]
        public int SqId { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [DisplayName("Answer")]
        [Required(ErrorMessage = "Security answer cannot be empty")]
        public string SqAns { get; set; }
    }
}
