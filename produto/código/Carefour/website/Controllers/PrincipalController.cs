using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Persistence;

namespace WebSite.Controllers
{
    public class PrincipalController : Controller
    {
        private static Usuario _Cliente = new Usuario();

        public ActionResult Index()
        {
            if (Session["Idioma"] == null)
                Session["Idioma"] = "PT";

            ViewBag.Saudacao = Tradutor.Traduzir("index_title", (String)Session["Idioma"]);
            ViewBag.index_bemVindo = Tradutor.Traduzir("index_bemVindo", (String)Session["Idioma"]);

            Categoria cat = new Categoria();
            return View(cat.GetCategorias((String)Session["Idioma"]));
        }

        public ActionResult Idioma(string id)
        {
            if (id == "PT")
                Session["Idioma"] = "PT";
            else
                Session["Idioma"] = "EN";

            return RedirectToAction("Index", "Principal");
        }
    }
}
