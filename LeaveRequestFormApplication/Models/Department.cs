using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LeaveRequestFormApplication.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Title { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new Collection<Employee>();
        }
    }
}
