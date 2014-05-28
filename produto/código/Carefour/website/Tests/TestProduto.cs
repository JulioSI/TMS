using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSite.Models;
using WebSite.Persistence;
using WebSite.Controllers;

namespace WebSite.Tests
{
    [TestClass]
    public class TestProduto
        {
            [TestMethod]
            public void retornaProdutos()
            {
                Produto produto = new Produto("1", "PT");
                List<Item> produtos = produto.listaProdutos;
                Assert.IsNotNull(produtos);

            }

            [TestMethod]
            public void retornaProdutosView()
            {
                ProdutoController produtoController = new ProdutoController();
                ActionResult actionResult = produtoController.Produtos("1");
                Assert.IsNotNull(actionResult);

            }

    }
}