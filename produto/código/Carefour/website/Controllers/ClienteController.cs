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
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfirmaCompra(Pedido pedido)
        {
            Cliente cliente = new Cliente();
            return View(cliente);
        }


        public ActionResult CompraFinalizada(Cliente cliente)
        {
            return View(cliente);
        }

        [HttpPost]
        public ActionResult ConfirmaCompra(Cliente cliente)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            clienteDAO.InserirCliente(cliente);

            return RedirectToAction("CompraFinalizada",cliente);
        }

       

    }
}
