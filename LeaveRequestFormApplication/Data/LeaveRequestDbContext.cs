using LeaveRequestFormApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveRequestFormApplication.Data
{
    public class LeaveRequestFormApplicationDbContext : DbContext
    {
        public LeaveRequestFormApplicationDbContext(DbContextOptions<LeaveRequestFormApplicationDbContext> options) 
            :base(options){
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
