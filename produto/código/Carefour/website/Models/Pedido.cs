using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class Pedido 
    {
        public int id { get; set; }
        public int numero { get; set; }
        public List<Item> listaDeItems = null;

        public Pedido(List<Item> listaDeItems)
        {
            this.listaDeItems = listaDeItems;
        }

        public double CalcularCustoTotal(){

            double soma = 0;
            for(int i = 0; i < this.listaDeItems.Count; i++)
            {
                soma += soma + (this.listaDeItems[i].preco * this.listaDeItems[i].quantidade);
            }

            return soma;
        }



    }
}