using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryProject.Models;

namespace BakeryProject.Controllers
{
    public class NewProductController : Controller
    {
        BakeryEntities db = new BakeryEntities();
        // GET: AddProduct
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ProductName, ProductPrice")] Product np)
        {
            Product newproduct = new Product();
            newproduct.ProductName = np.ProductName;
            newproduct.ProductPrice = np.ProductPrice;

            db.Products.Add(newproduct);
            db.SaveChanges();

            Message m = new Message();
            m.MessageText = "Thank you for adding your product to our menu!";
            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}