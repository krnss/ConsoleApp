using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameShop.Models;
using GameShop.Interfase;
using GameShop.ADONET;

namespace GameShop.Controllers
{
    public class HomeController : Controller
    {
        public static ADONETProvaider Provaider = new ADONETProvaider();
        [HttpGet]
        public ActionResult Index()
        {
            List<IProduct> games = Provaider.SelectAllGame();
 
            return View(games);
        }


        [HttpGet]
        public ActionResult Show(int? id)
        {
            ViewBag.Message = "Your Product page.";

            if (id == null)
                return HttpNotFound();

            return View(Provaider.SelectGame(id));
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Message = "Edit Product page.";

            if (id == null)
                return HttpNotFound();

            return View(Provaider.SelectGame(id));
        }
        [HttpPost]
        public RedirectResult Edit(int Id,string Name ,string Autor,int Prise,string UrlFoto)
        {
            Provaider.UpdateGame(new Game(Id, Name, Autor, Prise, UrlFoto));

            return Redirect($"/Home/Show/{Id}");
        }



        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Message = "ADD Product page.";
           
            return View();
        }
        [HttpPost]
        public RedirectResult AddProduct(string Name, string Autor, int Prise, string UrlFoto)
        {
            Provaider.InsertGame(new Game(Name, Autor, Prise, UrlFoto));

            return Redirect($"/Home");
        }


        [HttpDelete]
        public ActionResult DeleteGame(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Provaider.DeleteGame(id);

            return Redirect($"/Home");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}