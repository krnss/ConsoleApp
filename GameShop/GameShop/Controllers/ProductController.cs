using GameShop.ADONET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameShop.Controllers
{
    public class ProductController : Controller
    {
        public static ADONETProvaider Provaider = new ADONETProvaider();
        // GET: Product        
        public ActionResult Index(int? id)
        {
            ViewBag.Message = "Your Product page.";

            if (id == null)
                return HttpNotFound();

            return View(Provaider.SelectGame(id));
        }

    }
}