using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WebSite.Models;


namespace WebSite.Persistence
{
    public class ClienteDAO : MySQL
    {

        public int InserirCliente(Cliente cliente)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "INSERT INTO tb_clientes (nome, email, senha, dataNascimento, sexo, endereco, telefone) " +
            "VALUES ('" + cliente.nome + "','" + cliente.email + "','" + cliente.senha + "','" + DateTime.Parse(cliente.dataNascimento.ToString()).ToString("yyyy-MM-dd") + "','" + cliente.sexo + "','" + cliente.endereco + "','" + cliente.telefone + "'); Select Max(id) from tb_clientes;";

            int i = 0;
            conn.Open();
            i = int.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();

            return i;

        }
    }
}