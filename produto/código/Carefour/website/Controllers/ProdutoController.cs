using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class ProdutoController : Controller
    {
        //
        // GET: /Produto/

        private static Produto _produto = new Produto();


        public Produto GetProduto()
        {
            return _produto;
        }

        public void LimparProdutos()
        {
            _produto.listaProdutos.Clear();
        }



        public ActionResult Idioma(string id)
        {
            if (id == "PT")
                Session["Idioma"] = "PT";
            else
                Session["Idioma"] = "EN";

            return RedirectToAction("Produtos", "Produto");
        }

        public ActionResult Produtos(string produto)
        {
            if (Session["Idioma"] == null)
                Session["Idioma"] = "PT";

            ViewBag.Nome = Tradutor.Traduzir("produto_nome", (String)Session["Idioma"]);
            ViewBag.Quantidade = Tradutor.Traduzir("produto_quantidade", (String)Session["Idioma"]);
            ViewBag.Preco = Tradutor.Traduzir("produto_preco", (String)Session["Idioma"]);
            ViewBag.btnComprar = Tradutor.Traduzir("btnComprar", (String)Session["Idioma"]);
            ViewBag.Voltar = Tradutor.Traduzir("Voltar", (String)Session["Idioma"]);
            ViewBag.Carrinho = Tradutor.Traduzir("Carrinho", (string)Session["Idioma"]);
            ViewBag.Imagem = Tradutor.Traduzir("Imagem", (string)Session["Idioma"]);

            Produto model;
            if (String.IsNullOrEmpty(produto)) produto = "1";
            model = new Produto(produto, (String)Session["Idioma"]);
            _produto = model;

            return View(_produto.listaProdutos);
        }

        [HttpPost]
        public ActionResult Produtos(PrincipalController Principal, int[] produtoId, string[] quantidade)
        {
            List<Item> carrinho;

            if (produtoId.Length > 0)
            {
                if (Session["Carrinho"] == null)
                {
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
                }
                else
                {
                    carrinho = (List<Item>)Session["Carrinho"];

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

                }
            }

            return RedirectToAction("Carrinho", "Carrinho");
        }


    }
}
