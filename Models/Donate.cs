using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Donate
    {
        public string PersonLastName { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonEmail { get; set; }
        public decimal DonationAmount { get; set; }
        public int DonationKey { get; set; }

    }
}