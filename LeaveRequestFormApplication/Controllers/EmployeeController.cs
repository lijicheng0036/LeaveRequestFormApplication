using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LeaveRequestFormApplication.Data;
using LeaveRequestFormApplication.Data.Dto;
using LeaveRequestFormApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveRequestFormApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly LeaveRequestFormApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeController(LeaveRequestFormApplicationDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        [HttpGet("/api/employees")]
        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            var employees = await _context.Employees.Include(e => e.Department).ToListAsync();

            return _mapper.Map<List<Employee>, List<EmployeeDto>>(employees);
        }
    }
}