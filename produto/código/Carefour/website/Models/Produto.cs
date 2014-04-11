using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public enum CategoriaProduto
    {
        carne = 1,
        laticinio = 2,
        padaria = 3,
        Hortifrutigranjeiros = 4
    }

    public class Produto
    {
        public List<Item> listaProdutos = new List<Item>();

        public Produto(CategoriaProduto categoria)
        {
            switch (categoria)
            {
                case CategoriaProduto.carne:

                    listaProdutos.Add(new Item
                    {
                        id = 1,
                        imagem = "",
                        descricao = "Alcatra - Carne super macia.",
                        preco = "R$ 15,00"                        
                    });

                    listaProdutos.Add(new Item
                    {
                        id = 2,
                        imagem = "",
                        descricao = "Picanha - Carne indicada para churrasco, origem argentina.",
                        preco = "R$ 32,00"
                    });

                    listaProdutos.Add(new Item
                    {
                        id = 3,
                        imagem = "",
                        descricao = "Maminha - Carne bovina de ótima qualidade",
                        preco = "R$ 13,00"
                    });

                    listaProdutos.Add(new Item
                    {
                        id = 4,
                        imagem = "",
                        descricao = "Pernil Traseiro - Carne super magra, zero gordura.",
                        preco = "R$ 18,00"
                    });

                    break;

                case CategoriaProduto.Hortifrutigranjeiros:

                    listaProdutos.Add(new Item
                    {
                        id = 5,
                        imagem = "",
                        descricao = "Maça da Prata",
                        preco = "R$ 2,50"
                    });

                    break;

                case CategoriaProduto.laticinio:

                    listaProdutos.Add(new Item
                    {
                        id = 6,
                        imagem = "",
                        descricao = "Leite Longa Vida Cotoches",
                        preco = "R$ 1,50"
                    });

                    break;

                case CategoriaProduto.padaria:

                    listaProdutos.Add(new Item
                    {
                        id = 7,
                        imagem = "",
                        descricao = "Pão Integral - A melhor fibra que se pode ter.",
                        preco = "R$ 4,50"
                    });

                    break;
            }            
        }

        public Item GetItem(int id)
        {
            Item _item = null;

            foreach (Item produtos in listaProdutos)
                if (_item.id.ToString() == id.ToString())
                    _item = produtos;

            return _item;
        }


    }
}