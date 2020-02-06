using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data.Entities
{
    public class Employee : BaseEntity
    {
        [Required(ErrorMessage = "A name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A valid email is required")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        
        public string Position { get; set; }

        public decimal Salary { get; set; }

        public decimal HourlyRate { get; set; }
        
        [DataType(DataType.Date)]  
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        /* As complexity grows, begin to add features of the entity that can be individually edited 
        [Required(ErrorMessage = "A name is required")]
        public string FirstName { get; set; } 
        [Required(ErrorMessage = "A name is required")]
        public string LastName { get; set; }  
        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        */
    }
}