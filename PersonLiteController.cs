using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class PersonLiteController : Controller
    {
        private Community_AssistEntities db = new Community_AssistEntities();
        // GET: Personnel
        public ActionResult Index()
        {
            var peeps = from p in db.Person
                        from pa in p.PersonAddress
                        from c in p.Contact
                        where c.ContactTypeKey == 1
                        select new
                        {
                            p.PersonKey,
                            p.PersonLastName,
                            p.PersonFirstName,
                            p.PersonEmail,
                            pa.PersonAddressApt,
                            pa.PersonAddressStreet,
                            pa.PersonAddressCity,
                            pa.PersonAddressState,
                            pa.PersonAddressZip,
                            c.ContactNumber
                        };
            List<Personlite> peepsList = new List<Personlite>();
            foreach (var p in peeps)
            {
                Personlite pl = new Personlite();
                
                pl.LastName = p.PersonLastName;
                pl.FirstName = p.PersonFirstName;
                pl.Email = p.PersonEmail;
                pl.Apartment = p.PersonAddressApt;
                pl.Street = p.PersonAddressStreet;
                pl.City = p.PersonAddressCity;
                pl.State = p.PersonAddressState;
                pl.Zipcode = p.PersonAddressZip;
                peepsList.Add(pl);
            }

            return View(peepsList);
        }

       
        public ActionResult Create([Bind(Include = "LastName, FirstName, Email, Password, Apartment, Street, City, State, Zipcode, homePhone, WorkPhone")]
        Personlite pl)
        {
            int result = db.usp_Register(pl.LastName, pl.FirstName, pl.Email, pl.Password, pl.Apartment, pl.Street, pl.City, pl.State, pl.Zipcode, pl.HomePhone, pl.WorkPhone);
            return View();
        }
    }
}