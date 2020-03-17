using System.Collections.Generic;

namespace LeaveRequestFormApplication.Data.Dto
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<EmployeeDto> Employees { get; set; }
    }
}
