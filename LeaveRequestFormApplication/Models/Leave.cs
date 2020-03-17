using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LeaveRequestFormApplication.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public float? Duration { get; set; }
        public string Description { get; set; }

        public bool IsApproved { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
