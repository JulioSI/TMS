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

    }
}
