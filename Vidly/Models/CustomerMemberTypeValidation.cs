using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMovies.Models
{
    public class CustomerMemberTypeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if ((customer.MembershipTypeID==MembershipType.PayAsYouGo) && (!customer.IsSubscribedToNewsLetter))
            {
                return new ValidationResult("You need to subscribe for New Letter if you want to opt for Pay As You Go");
            }
            
            return ValidationResult.Success;
        }
    }
}