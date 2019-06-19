using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data.Entites
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A name is required for the employee")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "A valid email is required")]
        public string Email { get; set; }
        
        public string Position { get; set; }

        public DateTime StartDate { get; set; }

        public bool isCurrent { get; set; }
    }
}