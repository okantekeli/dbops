
using System.ComponentModel.DataAnnotations;

namespace Dbops.Application.Domain;
public class User
{
    
    [Required]
    [Display(Name = "User Id")]
    public int UserId {get;set;}

    [Required]
    [StringLength(100)]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email Address")]
    public string Email {get;set;} = string.Empty;

    [Required]
    [StringLength(50)]
    [DataType(DataType.Text)]
    [Display(Name = "Name")]
    public string Name {get;set;} = string.Empty;

    [Required]
    [StringLength(50)]
    [DataType(DataType.Text)]
    [Display(Name = "Lastname")]
    public string LastName {get;set;} = string.Empty;

    [Required]
    [StringLength(150)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password {get;set;} = string.Empty;

    public User()
    {
    
    }
}