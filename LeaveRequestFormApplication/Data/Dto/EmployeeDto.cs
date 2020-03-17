namespace LeaveRequestFormApplication.Data.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }
        public string Email { get; set; }

        public int DepartmentId { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
