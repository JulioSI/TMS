using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebSite.Persistence;

namespace WebSite.Models
{
    public enum CategoriaProduto
    {
        carne = 1,
        laticinio = 2,
        padaria = 3,
        Hortifrutigranjeiros = 4
    }

    [Serializable]
    public class Produto
    {
        public List<Item> listaProdutos;

        public Produto() { }

        public Produto(int id)
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            List<Categoria> listaCategorias = categoriaDAO.ObterCategoriasCadastradas();
            ProdutoDAO produto = new ProdutoDAO();
            listaProdutos = produto.ProdutosDisponiveis(id, listaCategorias);
        }

        public void AjustaLista()
        {
            ProdutoDAO Produto = new ProdutoDAO();
            Produto.AtualizaDetalhesDoProduto(ref listaProdutos);
        }

        public HtmlString ResumoPedido(List<Item> lista)
        {
            string produto = String.Empty;

            foreach (Item item in lista)
            {
                produto += item.descricao.ToString() + " - " + item.quantidade + "x " + item.preco.ToString("c") + "<br />";
            }

            HtmlString retorno = new HtmlString(produto);

            return retorno;
        }

        public string CalculaCarrinho()
        {
            double total = 0;
            Item _item;

            for (int i = 0; i < listaProdutos.Count; i++)
            {
                _item = listaProdutos[i];
                total += (_item.quantidade * _item.preco);
            }

            return total.ToString("c");
        }


        public int id { get; set; }



        [DisplayName("Caminho da Imagem")]
        [StringLength(200, ErrorMessage = "O campo permite no máximo 50 caracteres!")]
        public string imagem { get; set; }


        [Required]
        [DisplayName("Descrição do Produto")]
        public string descricao { get; set; }


        [Required]
        public double preco { get; set; }

        [Required]
        public Categoria categoria { get; set; }
    }


}