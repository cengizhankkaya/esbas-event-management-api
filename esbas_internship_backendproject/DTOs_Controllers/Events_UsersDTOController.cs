using esbas_internship_backendproject.DTOs;
using esbas_internship_backendproject.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using esbas_internship_backendproject.Entities;
using AutoMapper;


namespace esbas_internship_backendproject.DTOs_Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Events_UsersDTOController : ControllerBase
    {
        private readonly EsbasDbContext _context;
        private readonly IMapper _mapper;
        public Events_UsersDTOController(EsbasDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetEventsUsers()
        {
            var eventsusers = _context.Events_Users
                .Include(eu => eu.Event)
                .Include(eu => eu.User)
                .Select(eu => _mapper.Map<EventsUsersDTO>(eu))
                .ToList();
     

            return Ok(eventsusers);
        }


        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult GetEventsUserByID(int id)
        {
            var eventsUser = _context.Events_Users
                .Include(eu => eu.Event)
                .Include(eu => eu.User)
                .Where(eu => eu.ID == id)
                .Select(eu => _mapper.Map<EventsUsersDTO>(eu))
                .FirstOrDefault();

            if (eventsUser == null)
            {
                return NotFound();
            }

            return Ok(eventsUser);
        }

        [HttpGet("eventID/{eventID}")]
        [Produces("application/json")]
        public IActionResult GetEventsUsersByEventID(int eventID)
        {
            var eventsUsers = _context.Events_Users
                .Include(eu => eu.Event)
                .Include(eu => eu.User)
                .Where(eu => eu.EventID == eventID)
                .Select(eu => _mapper.Map<EventsUsersDTO>(eu))
                .ToList();

            if (eventsUsers == null || eventsUsers.Count == 0)
            {
                return NotFound();
            }

            return Ok(eventsUsers);
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateEventsUsersMap([FromBody] EventsUsersResponseDTO eventsUsersResponseDTO)
        {
            if (eventsUsersResponseDTO == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Kart ID'sinin Users tablosunda var olup olmadığını kontrol edin
            var userExists = _context.Users.Any(u => u.CardID == eventsUsersResponseDTO.CardID);
            if (!userExists)
            {
                return BadRequest(new { message = "Geçersiz CardID. Kullanıcı bulunamadı." });
            }

            // Aynı etkinlik ve kart için zaten bir eşleşme olup olmadığını kontrol edin
            var existingEventUser = _context.Events_Users
                .FirstOrDefault(eu => eu.EventID == eventsUsersResponseDTO.EventID && eu.CardID == eventsUsersResponseDTO.CardID);

            if (existingEventUser != null)
            {
                return Conflict(new { message = "Bu kullanıcı zaten bu etkinlikte kayıtlı." });
            }

            // Yeni eşleşmeyi haritalandır ve veritabanına kaydet
            var event_UsersResponse = _mapper.Map<Events_Users>(eventsUsersResponseDTO);
            _context.Events_Users.Add(event_UsersResponse);
            _context.SaveChanges();

            return Ok(event_UsersResponse);
        }


        //[HttpPost]
        //[Produces("application/json")]
        //public IActionResult CreateEventsUsersMap([FromBody] EventsUsersResponseDTO eventsUsersResponseDTO)
        //{
        //    if (eventsUsersResponseDTO == null || !ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    // Aynı etkinlik ve kart için zaten bir eşleşme olup olmadığını kontrol edin
        //    var existingEventUser = _context.Events_Users
        //        .FirstOrDefault(eu => eu.EventID == eventsUsersResponseDTO.EventID && eu.CardID == eventsUsersResponseDTO.CardID);

        //    if (existingEventUser != null)
        //    {
        //        return Conflict(new { message = "Bu kullanıcı zaten bu etkinlikte kayıtlı." });
        //    }

        //    // Yeni eşleşmeyi haritalandır ve veritabanına kaydet
        //    var event_UsersResponse = _mapper.Map<Events_Users>(eventsUsersResponseDTO);
        //    _context.Events_Users.Add(event_UsersResponse);
        //    _context.SaveChanges();

        //    return Ok(event_UsersResponse);
        //}





        //[HttpPost()]
        //  [Produces("application/json")]
        //  public IActionResult CreateEventsUsersMap([FromBody] EventsUsersResponseDTO eventsUsersResponseDTO)
        //  {
        //      if (eventsUsersResponseDTO == null || !ModelState.IsValid)
        //      {
        //          return BadRequest(ModelState); 
        //      }

        //    var event_UsersResponse = _mapper.Map<Events_Users>(eventsUsersResponseDTO);

        //      _context.Events_Users.Add(event_UsersResponse);
        //      _context.SaveChanges();

        //      return Ok(event_UsersResponse);
        //  }


        [HttpPut("{id}")]
        [Produces("application/json")]
        public IActionResult UpdateEventsUsers(int id, [FromBody] EventsUsersResponseDTO eventsUsersResponseDTO)
        {
            if (eventsUsersResponseDTO == null)
            {
                return BadRequest();
            }

            var eventsUsersResponse = _context.Events_Users.FirstOrDefault(eu => eu.ID == id);

            if (eventsUsersResponse == null)
            {
                return NotFound();
            }

            eventsUsersResponse.EventID = eventsUsersResponseDTO.EventID;
            eventsUsersResponse.CardID = eventsUsersResponseDTO.CardID;
          
       
            _context.SaveChanges();

            return Ok(eventsUsersResponse);
        }

        [HttpDelete("SoftDelete{id}")]
        [Produces("application/json")]
        public IActionResult SoftDeleteEventsUsers(int id)
        {
            var eventsUsers = _context.Events_Users.FirstOrDefault(eu => eu.ID == id);

            if (eventsUsers == null)
            {
                return NotFound();
            }

            eventsUsers.Status = false;


            _context.Events_Users.Update(eventsUsers);
            _context.SaveChanges();

            return NoContent();
        }

        /*[HttpDelete("ForceDelete{eventId}/{userId}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteEvents_Users(int eventId, int userId)
        {
            var eventUser = await _context.Events_Users
                .FirstOrDefaultAsync(eu => eu.EventID == eventId && eu.User.UserID == userId);

            if (eventUser == null)
            {
                return NotFound();
            }

            _context.Events_Users.Remove(eventUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

    }

  }
