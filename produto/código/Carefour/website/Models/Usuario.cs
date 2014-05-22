using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Models
{
    public class Usuario : Controller
    {
        public List<Cliente> listaUsuarios = new List<Cliente>();

        public void CriaUsuario(Cliente usuarioModelo)
        {
            listaUsuarios.Add(usuarioModelo);
        }

        public string DadosCliente(Cliente cli)
        {
            string produto = String.Empty;

            produto += cli.nome  + " " + "<br />";
            produto += cli.email + " " + "<br /><br />";
            produto += cli.endereco + " " + "<br />";
            produto += cli.telefone + " " + "<br /><br />";
                    
            //HtmlString retorno = new HtmlString(produto);

            return produto;
        }

    }
}
