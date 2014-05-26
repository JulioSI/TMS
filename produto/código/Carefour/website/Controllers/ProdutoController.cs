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

        public ActionResult Produtos(int produto)
        {
            Produto model;
            model = new Produto(produto);
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
