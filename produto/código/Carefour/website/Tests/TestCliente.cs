using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSite.Models;
using WebSite.Persistence;

namespace WebSite.Tests
{
    [TestClass]
    public class TestCliente
    {
        [TestMethod]
        public void InserirCliente()
        {
            Cliente cliente = new Cliente();
            cliente.nome = "Charles";
            cliente.email = "charlees1509@hotmail.com";
            cliente.dataNascimento = new DateTime(2014, 04, 3);
            cliente.endereco = "rua tal";
            cliente.senha = "123";
            cliente.sexo ='M';
            cliente.telefone = "99999999";

            
            ClienteDAO cdao =  new ClienteDAO();

            Assert.IsTrue(cdao.InserirCliente(cliente));
        }

    }
}