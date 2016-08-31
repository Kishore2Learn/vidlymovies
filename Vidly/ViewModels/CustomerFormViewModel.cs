using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyMovies.Models;
namespace VidlyMovies.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer{ get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}