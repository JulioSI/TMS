using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;
using MySql.Data.MySqlClient;

namespace WebSite.Persistence
{
    public class ProdutoDAO : MySQL
    {
        public List<Item> ProdutosDisponiveis(int id, List<Categoria> listaCateogias, string idioma)
        {
            List<Item> listaProdutos = new List<Item>();

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT id, concat(Nome, ' - ' , descricao)  as descricao, preco , urlimagem FROM tb_Produtos where id_categoria = " + id;

            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listaProdutos.Add(new Item
                    {
                        id = (int)dr["id"],
                        descricao = Tradutor.Traduzir(dr["descricao"].ToString(), idioma),
                        preco = (double)dr["preco"],
                        imagem = dr["urlimagem"].ToString(),
                        categoria = listaCateogias.Where(c => c.id == id).Single()
                    });
                }
            }
            conn.Close();

            return listaProdutos;

        }

        public void AtualizaDetalhesDoProduto(ref List<Item> lista)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();

            for (int i = 0; i < lista.Count; i++)
            {
                Item item2 = new Item();
                item2 = lista[i];

                cmd.Connection = conn;
                cmd.CommandText = "SELECT id, concat(Nome, ' - ' , descricao)  as descricao, preco FROM tb_Produtos where id = " + item2.id;

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        item2.preco = (double)dr["preco"];
                        item2.descricao = dr["descricao"].ToString();
                    }
                }
                conn.Close();

                lista[i] = item2;

            }
        }


    }
}