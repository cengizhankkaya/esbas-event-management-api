using esbas_internship_backendproject.DTOs;
using esbas_internship_backendproject.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using esbas_internship_backendproject.Entities;
using AutoMapper;

namespace esbas_internship_backendproject.DTOs_Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class User_IsOfficeEmployeeDTOController : ControllerBase
    {
        private readonly EsbasDbContext _context;
        private readonly IMapper _mapper;
        public User_IsOfficeEmployeeDTOController(EsbasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetUserGenders()
        {
            var userIsOfficeEmployee = _context.User_IsOfficeEmployee
                .Select(uı => _mapper.Map<UserIsOfficeEmployeeDTO>(uı))
                .ToList();

            return Ok(userIsOfficeEmployee);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult GetUserIsOfficeEmployee(int id)
        {
            var userIsOfficeEmployee = _context.User_IsOfficeEmployee
                .Where(uı => uı.I_ID == id)
                .Select(et => _mapper.Map<UserIsOfficeEmployeeDTO>(et))
                .FirstOrDefault();

            if (userIsOfficeEmployee == null)
            {
                return NotFound();
            }

            return Ok(userIsOfficeEmployee);
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateUserIsOfficeEmployee([FromBody] UserIsOfficeEmployeeResponseDTO user_IsOfficeEmployeeResponseDTO)
        {
            if (user_IsOfficeEmployeeResponseDTO == null)
            {
                return BadRequest();
            }

            var userIsOfficeEmployeeResponse = _mapper.Map<User_IsOfficeEmployee>(user_IsOfficeEmployeeResponseDTO);


            _context.User_IsOfficeEmployee.Add(userIsOfficeEmployeeResponse);
            _context.SaveChanges();

            return Ok(userIsOfficeEmployeeResponse);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public IActionResult UpdateUserIsOfficeEmployee(int id, [FromBody] UserIsOfficeEmployeeResponseDTO userIsOfficeEmployeeResponseDTO)
        {
            if (userIsOfficeEmployeeResponseDTO == null)
            {
                return BadRequest();
            }

            var user_IsOfficeEmployeeResponse = _context.User_IsOfficeEmployee.FirstOrDefault(uı => uı.I_ID == id);

            if (user_IsOfficeEmployeeResponse == null)
            {
                return NotFound();
            }

            user_IsOfficeEmployeeResponse.Name = userIsOfficeEmployeeResponseDTO.Name;

            _context.SaveChanges();

            return Ok(user_IsOfficeEmployeeResponse);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public IActionResult SoftDeleteUserIsOfficeEmployee(int id)
        {
            var userIsOfficeEmployee = _context.User_IsOfficeEmployee.FirstOrDefault(uı => uı.I_ID == id);

            if (userIsOfficeEmployee == null)
            {
                return NotFound();
            }

            // Kaydın durumunu "deleted" olarak günceller.
            userIsOfficeEmployee.Status = false;


            _context.User_IsOfficeEmployee.Update(userIsOfficeEmployee);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
