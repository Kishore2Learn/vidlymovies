using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyMovies.Models;

namespace VidlyMovies.DTOs
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipTypeDTO MembershipType { get; set; }
        //[CustomerMemberTypeValidation]
        public byte MembershipTypeID { get; set; }
        public DateTime BirthDate { get; set; }
    }
}