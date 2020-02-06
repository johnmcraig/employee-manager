using System;
using System.ComponentModel.DataAnnotations;

namespace server.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}