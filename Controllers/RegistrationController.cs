using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryProject.Models;


namespace BakeryProject.Controllers
{
    public class RegistrationController : Controller
    {
        BakeryEntities b = new BakeryEntities();

        // GET: Registration
        public ActionResult Index()
        {
            if (Session["personKey"] != null)
            {
                Message m = new Message();
                m.MessageText = "You have registered already. No need to do it again!";
                return RedirectToAction("Result", m);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonFirstName, PersonLastName, PersonEmail, PersonDateAdded")]Person p)
        {
            p.PersonDateAdded = DateTime.Now;
            b.People.Add(p);
            b.SaveChanges();

            Message m = new Message();
            m.MessageText = "You are now registered.";
            return RedirectToAction("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}