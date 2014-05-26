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
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ConfirmaCompra()
        {

            ViewBag.ValorTotalCompra = produtoController.GetProduto().CalculaCarrinho();
            ViewBag.ItensPedido = produtoController.GetProduto().ResumoPedido(produtoController.GetProduto().listaProdutos);
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmaCompra(Cliente _usuario)
        {
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
