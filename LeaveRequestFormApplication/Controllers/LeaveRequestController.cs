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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveRequestFormApplication.Controllers
{
    [Route("api/[controller]")]
    public class LeaveRequestController : Controller
    {
        private readonly LeaveRequestFormApplicationDbContext _context;
        private readonly IMapper _mapper;
        public LeaveRequestController(LeaveRequestFormApplicationDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<LeaveDto>> GetLeave()
        {

            var leaveList = await _context.Leaves
            .Include(x => x.Employee)
            .Include(x => x.LeaveType)
            .ToListAsync();

            return _mapper.Map<List<Leave>, List<LeaveDto>>(leaveList);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<LeaveDto> GetLeave(int id)
        {
            var leaveX = await _context.Leaves
                .Include(x => x.Employee)
                .Include(x => x.LeaveType)
                .SingleOrDefaultAsync(x => x.Id == id);
            
            return _mapper.Map<Leave, LeaveDto>(leaveX);
        }

        // POST api/<controller>
        [HttpPost("/api/createNewLeave")]
        public async Task<IActionResult> CreateLeave([FromBody] LeaveDto createLeaveDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leave = _mapper.Map<LeaveDto, Leave>(createLeaveDto);
            leave.LastUpdated = DateTime.Now;
            leave.IsApproved = false;
            
            _context.Leaves.Add(leave);

            await _context.SaveChangesAsync();

            var result = _mapper.Map<Leave, LeaveDto>(leave);
            return Ok(result);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeave(int id, [FromBody] LeaveDto createLeaveDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leaveX = await _context.Leaves.SingleOrDefaultAsync(x => x.Id == id);
            leaveX.LastUpdated = DateTime.Now;
            _mapper.Map(createLeaveDto, leaveX);

            await _context.SaveChangesAsync();

            var result = _mapper.Map<Leave, LeaveDto>(leaveX);
            return Ok(result);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeave(int id)
        {
            var leaveX = await _context.Leaves.FindAsync(id);

            if (leaveX == null) return NotFound("Id not found");

            _context.Leaves.Remove(leaveX);

            await _context.SaveChangesAsync();
            var result = _mapper.Map<Leave, LeaveDto>(leaveX);
            return Ok(result);
        }
    }
}
