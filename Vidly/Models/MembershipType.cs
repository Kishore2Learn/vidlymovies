﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyMovies.Models
{
    public class MembershipType
    {
        public byte ID { get; set; }
        public string MemberShipDescription { get; set; }
        public byte SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte PayAsYouGo = 1;
    }
}