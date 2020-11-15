using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    //4.37{
    public class RegisterDto
    {
       /*4.38:*/ [Required]//validation
        public string Username { get; set; }

/*4.38:*/ [Required]//validation
        public string Password { get; set; }
    }
}//}4.37