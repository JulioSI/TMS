using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Persistence;

namespace WebSite.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string urlImagem { get; set; }

        public List<Produto> listaDeProdutos { get; set; }

        public List<Categoria> GetCategorias(string idioma)
        {
            CategoriaDAO AL = new CategoriaDAO();
            List<Categoria> Lista = AL.ObterCategoriasCadastradas(idioma);

            return Lista;
        }

    }
}