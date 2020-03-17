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
    public class DepartmentController : Controller
    {
        private readonly LeaveRequestFormApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DepartmentController(LeaveRequestFormApplicationDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        [HttpGet("/api/departments")]
        public async Task<IEnumerable<DepartmentDto>> GetDepartments()
        {
            var departments = await _context.Departments.ToListAsync();

            return _mapper.Map<List<Department>, List<DepartmentDto>>(departments);
        }
    }
}