using System;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class EmployeeModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "A name is required for the employee")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "A valid email is required")]
        public string Email { get; set; }

        public string Position { get; set; }

        [DataType(DataType.Date)]  
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime StartDate { get; set; }
    }
}