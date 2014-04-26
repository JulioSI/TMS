using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class PrincipalController : Controller
    {
        private static Produto _produto;
        private static Usuario _Cliente = new Usuario();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Produtos(string produto)
        {
            Produto model;

            switch (produto)
            {
                case "Carnes":
                    model = new Produto(CategoriaProduto.carne);
                    _produto = model;
                    break;
                case "Laticinios":
                    model = new Produto(CategoriaProduto.laticinio);
                    _produto = model;
                    break;
                case "Padaria":
                    model = new Produto(CategoriaProduto.padaria);
                    _produto = model;
                    break;
                case "Hortifrutigranjeiros":
                    model = new Produto(CategoriaProduto.Hortifrutigranjeiros);
                    _produto = model;
                    break;
            }

            return View(_produto.listaProdutos);
        }

        public ActionResult Carrinho()
        {
            Produto model;
                            
            model = new Produto(CategoriaProduto.carne);
            _produto = model;

            ViewBag.SubTotal = "R$ 0,00";
               
            return View(_produto.listaProdutos);
        }

        public ActionResult ConfirmaCompra()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ConfirmaCompra(Cliente _usuario)
        {
            _Cliente.CriaUsuario(_usuario);
            if (!String.IsNullOrEmpty(_usuario.nome))
                return View("CompraFinalizada");
            else
                return View();
        }

        public ActionResult RemoverItemCarrinho(int id)
        {
            Item item = null;
            foreach (Item o in _produto.listaProdutos)
            {
                if (o.id == id)
                    item = o;
            }
            _produto.listaProdutos.Remove(item);

            return View("Carrinho", _produto.listaProdutos);
        }

        public ActionResult CompraFinalizada()
        {
            return View();
        }
    }
}
