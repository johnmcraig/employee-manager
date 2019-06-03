using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class EmployeeModel
    {
        [Required(ErrorMessage = "A name is required for the employee")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "A valid email is required")]
        public string Email { get; set; }
    }
}