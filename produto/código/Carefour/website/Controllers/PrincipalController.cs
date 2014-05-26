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
        private static Produto _produto;
        private static Usuario _Cliente = new Usuario();
        private static long numeroPedido;
        private static string retorno;
        private HtmlString dadosCompra;
        
        public ActionResult Index()
        {
            return View();
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

            return RedirectToAction("Carrinho");
        }

        public ActionResult Carrinho()
        {
            _produto.listaProdutos = (List<Item>)Session["Carrinho"];


            if (!(_produto.listaProdutos == null))
            {
                _produto.AjustaLista();
                ViewBag.SubTotal = _produto.CalculaCarrinho();
                return View(_produto.listaProdutos);
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
            foreach (Item o in _produto.listaProdutos)
            {
                if (o.id == id)
                    item = o;
            }
            _produto.listaProdutos.Remove(item);

            return View("Carrinho", _produto.listaProdutos);
        }

        public ActionResult ConfirmaCompra()
        {
            ViewBag.ValorTotalCompra = _produto.CalculaCarrinho();
            ViewBag.ItensPedido = _produto.ResumoPedido(_produto.listaProdutos);
            return View();
        }


        [HttpPost]
        public ActionResult ConfirmaCompra(Cliente _usuario)
        {
            if (!String.IsNullOrEmpty(_usuario.nome))
            {
                Pedido AL = new Pedido(_produto.listaProdutos);
                AL.FinalizaPedido(_produto.listaProdutos, _usuario);

                retorno = _Cliente.DadosCliente(_usuario);
                numeroPedido = AL.numero;

                return RedirectToAction("CompraFinalizada");
            }
            else
                return View();
        }



        public ActionResult CompraFinalizada()
        {
            this.dadosCompra = new HtmlString(retorno);
            ViewBag.DadosCompra = this.dadosCompra;
            ViewBag.NumeroPedido = numeroPedido;
            ViewBag.DataEntrega = DateTime.Now.AddDays(15).ToString("dd-MM-yyyy");
            ViewBag.ResumoPedido = _produto.ResumoPedido(_produto.listaProdutos);
            ViewBag.ValorTotalCompra = _produto.CalculaCarrinho(); ;

            dadosCompra = null;
            numeroPedido = 0;
            Session["Carrinho"] = null;

            return View();
        }
    }
}
