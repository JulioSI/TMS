using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;
using MySql.Data.MySqlClient;

namespace WebSite.Persistence
{
    public class ItemDAO : MySQL
    {
        public void InserirItems(List<Item> listaItems)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();

            foreach (Item item in listaItems)
            {
                cmd.CommandText = "INSERT INTO tb_items (nome, descricao, preco, urlImagem, quantidade, id_peidido) VALUES ('" + item.nome + "','" + item.descricao + "'," + item.preco + ",'" + item.urlImagem + "'," + item.quantidade + "," + item.pedido.id + ")";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}