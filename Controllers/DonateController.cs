using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class DonateController : Controller
    {
        Community_AssistEntities db = new Community_AssistEntities();
        // GET: Donate
        public ActionResult Index()
        {
            var donation = from d in db.Donation
                         select new
                         {
                             d.DonationKey,
                             d.Person.PersonFirstName,
                             d.Person.PersonLastName,
                             d.Person.PersonEmail,
                             d.DonationAmount
                         };
            List<Donate> donate = new List<Donate>();
            foreach (var d in donation)
            {
                Donate dnt = new Donate();
                dnt.DonationKey = d.DonationKey;
                dnt.PersonFirstName = d.PersonFirstName;
                dnt.PersonLastName = d.PersonLastName;
                dnt.PersonEmail = d.PersonEmail;
                dnt.DonationAmount = d.DonationAmount;
                donate.Add(dnt);

            }
            return View(donate);
        }
    }
}