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

        private void atualizarIdioma()
        {
            if (Session["Idioma"] == null)
                Session["Idioma"] = "PT";

            ViewBag.btnContinuarComprando = Tradutor.Traduzir("btnContinuarComprando", (String)Session["Idioma"]);
            ViewBag.FecharCompra = Tradutor.Traduzir("FecharCompra", (String)Session["Idioma"]);
            ViewBag.LimparCarrinho = Tradutor.Traduzir("LimparCarrinho", (String)Session["Idioma"]);
            ViewBag.Nome = Tradutor.Traduzir("produto_nome", (String)Session["Idioma"]);
            ViewBag.Quantidade = Tradutor.Traduzir("produto_quantidade", (String)Session["Idioma"]);
            ViewBag.Preco = Tradutor.Traduzir("produto_preco", (String)Session["Idioma"]);
            ViewBag.Atualizar = Tradutor.Traduzir("Atualizar", (String)Session["Idioma"]);
            ViewBag.SubTotalV = Tradutor.Traduzir("SubTotal", (String)Session["Idioma"]);
            ViewBag.Voltar = Tradutor.Traduzir("Voltar", (String)Session["Idioma"]);
        }

        public ActionResult Index()
        {

            atualizarIdioma();
            return View();
        }

        public ActionResult Idioma(string id)
        {
            if (id == "PT")
                Session["Idioma"] = "PT";
            else
                Session["Idioma"] = "EN";

            return RedirectToAction("Carrinho", "Carrinho");
        }

        public ActionResult Carrinho()
        {
            atualizarIdioma();
            produtoController.GetProduto().listaProdutos = (List<Item>)Session["Carrinho"];

            if (!(produtoController.GetProduto().listaProdutos == null))
            {
                produtoController.GetProduto().AjustaLista();
                ViewBag.SubTotal = produtoController.GetProduto().CalculaCarrinho();
                return View(produtoController.GetProduto().listaProdutos);
            }
            else
            {
                string script = Tradutor.Traduzir("SemProdCarrinho", (String)Session["Idioma"]);
                return this.JavaScript(script);
            }

        }

        [HttpPost]
        public ActionResult Carrinho(PrincipalController Principal, int[] produtoId, string[] quantidade)
        {
            atualizarIdioma();
            List<Item> carrinho;
            carrinho = (List<Item>)Session["Carrinho"];
           

            int j = 0;
            for (int w = 0; w < carrinho.Count; w++ )
            {
                 Item AL = new Item();
                 AL = carrinho[w];

                for (int i = 0; i < produtoId.Length; i++)
                {
                    if (produtoId[i].Equals(AL.id))
                    {
                        AL.quantidade = int.Parse(quantidade[0]);
                    }
                }
                carrinho[w] = AL;
            }
            
            Session["Carrinho"] = carrinho;
            return RedirectToAction("Carrinho");
        }

        public ActionResult LimparCarrinho()
        {
            atualizarIdioma();
            Session["Carrinho"] = null;
            produtoController.LimparProdutos();
            return View("Carrinho", produtoController.GetProduto().listaProdutos);
        }

        public ActionResult RemoverItemCarrinho(int id)
        {
            atualizarIdioma();
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
