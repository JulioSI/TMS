using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Persistence;

namespace WebSite.Controllers
{
    public class ClienteController : Controller
    {

        private static Usuario _Cliente = new Usuario();
        private static long numeroPedido;
        private static string retorno;
        private HtmlString dadosCompra;
        private ProdutoController produtoController = new ProdutoController();

        private void AtualizarDicionario()
        {
            if (Session["Idioma"] == null)
                Session["Idioma"] = "PT";

            ViewBag.Voltar = Tradutor.Traduzir("Voltar", (String)Session["Idioma"]);
            ViewBag.Cliente = Tradutor.Traduzir("Cliente", (String)Session["Idioma"]);
            ViewBag.ConfirmaCompra = Tradutor.Traduzir("ConfirmaCompra", (String)Session["Idioma"]);
            ViewBag.FormaPg = Tradutor.Traduzir("FormaPg", (String)Session["Idioma"]);
            ViewBag.Boleto = Tradutor.Traduzir("Boleto", (String)Session["Idioma"]);
            ViewBag.Cartao = Tradutor.Traduzir("Cartao", (String)Session["Idioma"]);
            ViewBag.Resumo = Tradutor.Traduzir("Resumo", (String)Session["Idioma"]);
            ViewBag.Frete = Tradutor.Traduzir("Frete", (String)Session["Idioma"]);
            ViewBag.Valor = Tradutor.Traduzir("produto_preco", (String)Session["Idioma"]);
            ViewBag.Inf = Tradutor.Traduzir("inf", (String)Session["Idioma"]);
            ViewBag.InfA = Tradutor.Traduzir("infA", (String)Session["Idioma"]);
            ViewBag.InfB = Tradutor.Traduzir("infB", (String)Session["Idioma"]);
            ViewBag.InfC = Tradutor.Traduzir("infc", (String)Session["Idioma"]);
            ViewBag.EndEntrega = Tradutor.Traduzir("EndEntrega", (String)Session["Idioma"]);
            ViewBag.Pedido = Tradutor.Traduzir("Pedido", (String)Session["Idioma"]);
            ViewBag.NumP = Tradutor.Traduzir("numP", (String)Session["Idioma"]);
            ViewBag.PrevEnt = Tradutor.Traduzir("prevEnt", (String)Session["Idioma"]);
        }


        public ActionResult Index()
        {
            AtualizarDicionario();
            return View();
        }
        public ActionResult ConfirmaCompra()
        {
            AtualizarDicionario();
            if (Session["Carrinho"] == null)
            {
                return RedirectToAction("Index", "Principal");
            }
            else
            {
                ViewBag.ValorTotalCompra = produtoController.GetProduto().CalculaCarrinho();
                ViewBag.ItensPedido = produtoController.GetProduto().ResumoPedido(produtoController.GetProduto().listaProdutos);
                return View();
            }
        }

        public ActionResult Idioma(string id)
        {
            if (id == "PT")
                Session["Idioma"] = "PT";
            else
                Session["Idioma"] = "EN";

            return RedirectToAction("ConfirmaCompra", "Cliente");
        }

        [HttpPost]
        public ActionResult ConfirmaCompra(Cliente _usuario)
        {
            AtualizarDicionario();
            if (!String.IsNullOrEmpty(_usuario.nome))
            {
                Pedido AL = new Pedido(produtoController.GetProduto().listaProdutos);
                AL.FinalizaPedido(produtoController.GetProduto().listaProdutos, _usuario);

                retorno = _Cliente.DadosCliente(_usuario);
                numeroPedido = AL.numero;

                return RedirectToAction("CompraFinalizada");
            }
            else
                return View();
        }

        public ActionResult CompraFinalizada()
        {
            AtualizarDicionario();
            this.dadosCompra = new HtmlString(retorno);
            ViewBag.DadosCompra = this.dadosCompra;
            ViewBag.NumeroPedido = numeroPedido;
            ViewBag.DataEntrega = DateTime.Now.AddDays(15).ToString("dd-MM-yyyy");
            ViewBag.ResumoPedido = produtoController.GetProduto().ResumoPedido(produtoController.GetProduto().listaProdutos);
            ViewBag.ValorTotalCompra = produtoController.GetProduto().CalculaCarrinho(); ;

            dadosCompra = null;
            numeroPedido = 0;
            Session["Carrinho"] = null;

            return View();
        }



    }
}
