using System;

namespace LeaveRequestFormApplication.Data.Dto
{
    public class LeaveDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public float? Duration { get; set; }
        public string Description { get; set; }

        public int EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
