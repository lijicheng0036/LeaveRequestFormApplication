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
    public class LeaveTypeController : Controller
    {
        private readonly LeaveRequestFormApplicationDbContext _context;
        private readonly IMapper _mapper;
        public LeaveTypeController(LeaveRequestFormApplicationDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        [HttpGet("/api/leave-types")]
        public async Task<IEnumerable<LeaveTypeDto>> GetLeaveTypes()
        {
            var leaveTypes = await _context.LeaveTypes.ToListAsync();

            return _mapper.Map<List<LeaveType>, List<LeaveTypeDto>>(leaveTypes);
        }
    }
}