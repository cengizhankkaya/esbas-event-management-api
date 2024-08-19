using esbas_internship_backendproject.DTOs;
using esbas_internship_backendproject.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using esbas_internship_backendproject.Entities;
using AutoMapper;

namespace esbas_internship_backendproject.DTOs_Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class User_GenderDTOController : ControllerBase
    {
        private readonly EsbasDbContext _context;
        private readonly IMapper _mapper;
        public User_GenderDTOController(EsbasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetUserGenders()
        {
            var userGenders = _context.User_Gender
                .Select(ug => _mapper.Map<UserGenderDTO>(ug))
                .ToList();

            return Ok(userGenders);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult GetUserGender(int id)
        {
            var userGender = _context.User_Gender
                .Where(ug => ug.G_ID == id)
                .Select(ug => _mapper.Map<UserGenderDTO>(ug))
               .FirstOrDefault();

            if (userGender == null)
            {
                return NotFound();
            }

            return Ok(userGender);
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateUserGender([FromBody] UserGenderResponseDTO userGenderResponseDTO)
        {
            if (userGenderResponseDTO == null)
            {
                return BadRequest();
            }

            var userGenderResponse = _mapper.Map<User_Gender>(userGenderResponseDTO);

            _context.User_Gender.Add(userGenderResponse);
            _context.SaveChanges();

            return Ok(userGenderResponse);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public IActionResult UpdateUserGender(int id, [FromBody] UserGenderResponseDTO userGenderResponseDTO)
        {
            if (userGenderResponseDTO == null)
            {
                return BadRequest();
            }

            var userGenderResponse = _context.User_Gender.FirstOrDefault(ug => ug.G_ID == id);

            if (userGenderResponse == null)
            {
                return NotFound();
            }

            userGenderResponse.Name = userGenderResponseDTO.Name;

            _context.SaveChanges();

            return Ok(userGenderResponse);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public IActionResult SoftDeleteUserGender(int id)
        {
            var userGender = _context.User_Gender.FirstOrDefault(ug => ug.G_ID == id);

            if (userGender == null)
            {
                return NotFound();
            }

            // Kaydın durumunu "deleted" olarak günceller.
            userGender.Status = false;


            _context.User_Gender.Update(userGender);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
