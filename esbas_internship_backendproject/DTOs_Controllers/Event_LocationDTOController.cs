using esbas_internship_backendproject.DTOs;
using Microsoft.AspNetCore.Mvc;
using esbas_internship_backendproject.Entities;
using AutoMapper;
using esbas_internship_backendproject.ResponseDTO;

namespace esbas_internship_backendproject.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class Event_LocationDTOController : ControllerBase
    {

        private readonly EsbasDbContext _context;
        private readonly IMapper _mapper;
        public Event_LocationDTOController(EsbasDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetEventLocations()
        {
            var eventLocations = _context.Event_Location
                .Select(el => _mapper.Map<EventLocationDTO>(el))
                .ToList();

            return Ok(eventLocations);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult GetEventLocation(int id)
        {
            var eventLocation = _context.Event_Location
                .Where(el => el.L_ID == id)
                .Select(el => _mapper.Map<EventLocationDTO>(el))
                .FirstOrDefault();

            if (eventLocation == null)
            {
                return NotFound();
            }

            return Ok(eventLocation);
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateEventLocation([FromBody] EventLocationResponseDTO eventLocationResponseDTO)
        {
            if (eventLocationResponseDTO == null)
            {
                return BadRequest();
            }

            var eventLocationResponse = _mapper.Map<Event_Location>(eventLocationResponseDTO);

            _context.Event_Location.Add(eventLocationResponse);
            _context.SaveChanges();

            return Ok(eventLocationResponse);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public IActionResult UpdateEventLocation(int id, [FromBody] EventLocationResponseDTO eventLocationResponseDTO)
        {
            if (eventLocationResponseDTO == null)
            {
                return BadRequest();
            }

            var eventLocationResponse = _context.Event_Location.FirstOrDefault(el => el.L_ID == id);

            if (eventLocationResponse == null)
            {
                return NotFound();
            }

            eventLocationResponse.Name = eventLocationResponseDTO.Name;

            _context.SaveChanges();

            return Ok(eventLocationResponse);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public IActionResult SoftDeleteEventLocation(int id)
        {
            var eventLocation = _context.Event_Location.FirstOrDefault(el => el.L_ID == id);

            if (eventLocation == null)
            {
                return NotFound();
            }

            // Kaydın durumunu "deleted" olarak günceller.
            eventLocation.Status = false;


            _context.Event_Location.Update(eventLocation);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
