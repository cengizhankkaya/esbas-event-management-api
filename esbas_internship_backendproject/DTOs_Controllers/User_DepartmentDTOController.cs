using esbas_internship_backendproject.DTOs;
using esbas_internship_backendproject.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using esbas_internship_backendproject.Entities;
using AutoMapper;

namespace esbas_internship_backendproject.DTOs_Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class User_DepartmentDTOController : ControllerBase
    {
        private readonly EsbasDbContext _context;
        private readonly IMapper _mapper;
        public User_DepartmentDTOController(EsbasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetUserDepartments()
        {
            var userDepartments = _context.User_Department
                .Select(ud => _mapper.Map<UserDepartmentDTO>(ud))   
                .ToList();

            return Ok(userDepartments);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult GetUserDepartmentByID(int id)
        {
            var userDepartment = _context.User_Department
                .Where(ud => ud.D_ID == id)
                .Select(ud => _mapper.Map<UserDepartmentDTO>(ud))
                .FirstOrDefault();

            if (userDepartment == null)
            {
                return NotFound();
            }

            return Ok(userDepartment);
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateUserDepartment([FromBody] UserDepartmentResponseDTO userDepartmentResponseDTO)
        {
            if (userDepartmentResponseDTO == null)
            {
                return BadRequest();
            }

            var userDepartmentResponse = _mapper.Map<User_Department>(userDepartmentResponseDTO);

            _context.User_Department.Add(userDepartmentResponse);
            _context.SaveChanges();

            return Ok(userDepartmentResponse);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public IActionResult UpdateUserDepartment(int id, [FromBody] UserDepartmentResponseDTO userDepartmentResponseDTO)
        {
            if (userDepartmentResponseDTO == null)
            {
                return BadRequest();
            }

            var userDepartmentResponse = _context.User_Department.FirstOrDefault(ud => ud.D_ID == id);

            if (userDepartmentResponse == null)
            {
                return NotFound();
            }

            userDepartmentResponse.Name = userDepartmentResponseDTO.Name;

            _context.SaveChanges();

            return Ok(userDepartmentResponse);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public IActionResult SoftDeleteUserDepartment(int id)
        {
            var userDepartment = _context.User_Department.FirstOrDefault(ud => ud.D_ID == id);

            if (userDepartment == null)
            {
                return NotFound();
            }

            // Kaydın durumunu "deleted" olarak günceller.
            userDepartment.Status = false;


            _context.User_Department.Update(userDepartment);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
