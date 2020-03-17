using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LeaveRequestFormApplication.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(500)]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Leave> Leaves { get; set; }
        public Employee()
        {
            Leaves = new Collection<Leave>();
        }
    }
}
