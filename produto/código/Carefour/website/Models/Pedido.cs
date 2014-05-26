using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Persistence;

namespace WebSite.Models
{
    public class Pedido 
    {
        public int id { get; set; }
        public int numero { get; set; }
        public List<Item> listaDeItems;

        public Pedido(List<Item> listaDeItems)
        {
            this.listaDeItems = listaDeItems;
        }

        public Pedido()
        {
        }

        public double CalcularCustoTotal(){

            double soma = 0;
            for(int i = 0; i < this.listaDeItems.Count; i++)
            {
                soma += soma + (this.listaDeItems[i].preco * this.listaDeItems[i].quantidade);
            }

            return soma;
        }

        public void FinalizaPedido(List<Item> Pedido, Cliente cli)
        {
            // Inserir Cliente
            ClienteDAO cliente = new ClienteDAO();
            int codCli = cliente.InserirCliente(cli);

            // Inserir Pedido
            PedidoDAO _pedido = new PedidoDAO();
            this.numero  = _pedido.InserirPedido(codCli, Pedido);

        }



    }
}