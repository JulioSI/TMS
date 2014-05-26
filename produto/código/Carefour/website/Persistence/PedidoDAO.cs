using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WebSite.Models;


namespace WebSite.Persistence
{
    public class PedidoDAO : MySQL
    {
        public int InserirPedido(int numCliente, List<Item> pedido)
        {
            int NumPedido = 0;
            int idPedido = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();
            
            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = "Select Max(numero) + 1 from tb_Pedidos";
            NumPedido = int.Parse(cmd.ExecuteScalar().ToString());

            cmd.CommandText = "Insert into tb_Pedidos (numero, id_cliente, data) Values(" + NumPedido + "," + numCliente + ", sysdate()); select Max(id) from tb_Pedidos;";
            idPedido = int.Parse(cmd.ExecuteScalar().ToString());

            foreach (Item item in pedido)
            {
                cmd.CommandText = "insert into tb_items (nome, descricao, preco, quantidade, id_pedido, urlImagem) Values ('" + item.descricao + "', Null,"+ item.preco.ToString().Replace(",",".") + "," + item.quantidade + "," + idPedido + ", Null);";
                cmd.ExecuteNonQuery();
            }

            conn.Close();

            return NumPedido;
        }
    }
}