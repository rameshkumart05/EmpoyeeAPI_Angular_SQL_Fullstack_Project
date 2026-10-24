using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpoyeeAPI.Model
{
    [Table("employeeTbl")]
    public class EmployeeModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int employeeid { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Select a valid designation.")]
        public int designationid { get; set; }

        [Required, MaxLength(50)] //    [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression(
            @"^(?=(?:\D*\d){10,15}\D*$)\+?[0-9\s()\-]+$",
            ErrorMessage = "Enter a valid contact number containing 10 to 15 digits."
        )]
        [MaxLength(10)]
        public string contactNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        [MaxLength(254)]
        public string email { get; set; } = string.Empty;

        [MaxLength(50)]
        public string city { get; set; } = string.Empty;

        [MaxLength(50)]
        public string sate { get; set; } = string.Empty;

        [MaxLength(10)]
        public string pincode { get; set; } = string.Empty;

        [MaxLength(20)]
        public string altContactno { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string address { get; set; } = string.Empty;

        public DateTime createDate { get; set; }

        public DateTime modifiedDate { get; set; }

        [MaxLength(25)]
        public string role { get; set; } = string.Empty;
    }

    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        public string contactNo { get; set; } = string.Empty;
    }
}
