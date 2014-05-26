using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class CarrinhoController : Controller
    {
        //
        // GET: /Carrinho/

        ProdutoController produtoController = new ProdutoController();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Carrinho()
        {
            produtoController.GetProduto().listaProdutos = (List<Item>)Session["Carrinho"];


            if (!(produtoController.GetProduto().listaProdutos == null))
            {
                produtoController.GetProduto().AjustaLista();
                ViewBag.SubTotal = produtoController.GetProduto().CalculaCarrinho();
                return View(produtoController.GetProduto().listaProdutos);
            }
            else
            {
                string script = "Não existe itens no carrinho de compra, volte á página anterior e adicione alguns produtos!";
                return this.JavaScript(script);
            }

        }

        [HttpPost]
        public ActionResult Carrinho(PrincipalController Principal, int[] produtoId, string[] quantidade)
        {
            List<Item> carrinho;
            carrinho = new List<Item>();

            int j = 0;
            for (int i = 0; i < quantidade.Length; i++)
            {
                if (!quantidade[i].Equals("0"))
                {
                    carrinho.Add(new Item
                    {
                        id = (int)produtoId[j],
                        quantidade = int.Parse(quantidade[i])
                    });
                    j++;
                }
            }

            Session["Carrinho"] = carrinho;
            return RedirectToAction("Carrinho");
        }

        public ActionResult RemoverItemCarrinho(int id)
        {
            Item item = null;
            foreach (Item o in produtoController.GetProduto().listaProdutos)
            {
                if (o.id == id)
                    item = o;
            }
            produtoController.GetProduto().listaProdutos.Remove(item);

            return View("Carrinho", produtoController.GetProduto().listaProdutos);
        }

    }
}
