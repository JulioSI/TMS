using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WebSite.Models;


namespace WebSite.Persistence
{
    
    public class CategoriaDAO : MySQL
    {
        public List<Categoria> ObterCategoriasCadastradas(string idioma)
        {
            List<Categoria> lista = new List<Categoria>();

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT id, nome, urlImagem FROM tb_categorias order by nome";

            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lista.Add(new Categoria
                    {
                        id = (int)dr["id"],
                        nome = Tradutor.Traduzir(dr["nome"].ToString(), idioma),
                        urlImagem = dr["urlImagem"].ToString()
                    });
                }
            }
            conn.Close();

            return lista;
        }

    }
}