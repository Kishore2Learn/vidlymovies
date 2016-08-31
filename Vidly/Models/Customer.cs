using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMovies.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Please enter Customer Name")]
        public string Name { get; set; }

        [Display(Name = "Subscribe To NewsLetter?")]
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        [CustomerMemberTypeValidation]
        [Display(Name ="Membership Type")]
        public byte MembershipTypeID { get; set; }

        [Required(AllowEmptyStrings =true)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
    }
}