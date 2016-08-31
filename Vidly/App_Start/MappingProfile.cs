using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyMovies.DTOs;
using VidlyMovies.Models;

namespace VidlyMovies.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieGenreTypes, MovieGenreTypeDTO>();
            Mapper.CreateMap<Rental, RentalDTO>();

            // DTO to Domain
            Mapper.CreateMap<CustomerDTO, Customer>()
                .ForMember(c => c.ID, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTO, Movie>()
                .ForMember(m=>m.ID,opt=>opt.Ignore());
        }
    }
}