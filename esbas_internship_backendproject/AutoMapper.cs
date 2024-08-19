using AutoMapper;
using esbas_internship_backendproject.DTOs;
using esbas_internship_backendproject.Entities;
using esbas_internship_backendproject.ResponseDTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace esbas_internship_backendproject // Replace with your namespace  
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<EventsUsersDTO, Events_Users>();
            CreateMap<Events_Users, EventsUsersDTO>();

            CreateMap<EventDTO, Events>();
            CreateMap<Events,EventDTO>();

            CreateMap<UserDTO, Users>();
            CreateMap<Users, UserDTO>();

            CreateMap<UserDepartmentDTO, User_Department>();
            CreateMap<Users, UserDepartmentDTO>();

            CreateMap<UserGenderDTO, User_Gender>();
            CreateMap<User_Gender, UserGenderDTO>();

            CreateMap<UserIsOfficeEmployeeDTO, User_IsOfficeEmployee>();
            CreateMap<User_IsOfficeEmployee, UserIsOfficeEmployeeDTO>();

            CreateMap<EventLocationDTO, Event_Location>();
            CreateMap<Event_Location,EventLocationDTO>();

            CreateMap<EventTypeDTO,Event_Type>();
            CreateMap<Event_Type, EventTypeDTO>();

            CreateMap<EventsUsersResponseDTO, Events_Users>();
            CreateMap<Events_Users,EventsUsersResponseDTO>();

            CreateMap<EventResponseDTO,Events>();
            CreateMap<Events, EventResponseDTO>();

            CreateMap<UserResponseDTO, Users>();
            CreateMap<Users,UserResponseDTO>();

            CreateMap<UserDepartmentResponseDTO, User_Department>();
            CreateMap<User_Department,UserDepartmentResponseDTO>();

            CreateMap<UserGenderResponseDTO,User_Gender>();
            CreateMap<User_Gender,UserGenderResponseDTO>();

            CreateMap<UserIsOfficeEmployeeResponseDTO, User_IsOfficeEmployee>();
            CreateMap<User_IsOfficeEmployee,UserIsOfficeEmployeeResponseDTO>();

            CreateMap<EventLocationResponseDTO,Event_Location>();
            CreateMap<Event_Location,EventLocationResponseDTO>();

            CreateMap<EventTypeResponseDTO, Event_Type>();
            CreateMap<Event_Type,EventTypeResponseDTO>();


        }
    }
}