using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryProject.Models;


namespace BakeryProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "Email, Password")]LoginClass lc)
        {
            BakeryEntities db = new BakeryEntities();
            int loginResult = db.usp_Login(lc.PersonEmail, lc.PersonPhone);
            if (loginResult != -1)
            {
                var uid = (from r in db.People
                           where r.PersonEmail.Equals(lc.PersonEmail)
                           select r.PersonKey).FirstOrDefault();
                int rKey = (int)uid;
                Session["personKey"] = rKey;

                MessageClass msg = new MessageClass();
                msg.MessageText = "Thank You! You are now logged in as '" + lc.PersonEmail + "'.";
                return RedirectToAction("Result", msg);
            }
            MessageClass message = new MessageClass();
            message.MessageText = "Invalid Login";
            return View("Result", message);
        }
        public ActionResult Result(MessageClass m)
        {
            return View(m);
        }

    }
}