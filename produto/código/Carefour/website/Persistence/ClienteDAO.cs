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
       
        public bool InserirCliente(Cliente cliente) 
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "INSERT INTO tb_clientes (nome, email, senha, dataNascimento, sexo, endereco, telefone) "+
            "VALUES ('" + cliente.nome + "','" + cliente.email + "','" + cliente.senha + "'," + String.Format("{0:dd/MM/yyyy}",cliente.dataNascimento) + ",'" + cliente.sexo + "','" + cliente.endereco + "','" + cliente.telefone + "')";
            
            int i = 0;
            conn.Open();
            i = cmd.ExecuteNonQuery();
            conn.Close();

            if(i != 0)
                return true;
            else
                return false;
        }
    }
}