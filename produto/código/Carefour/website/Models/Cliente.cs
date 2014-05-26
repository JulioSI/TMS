using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class Cliente
    {

        public int id { get; set; }

        [DisplayName("Nome")]
        [StringLength(100,ErrorMessage = "O campo Nome permite no máximo 100 caracteres!")]
        public string nome { get; set; }

        [DisplayName("Email")]
        [StringLength(50)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        public string email { get; set; }

        [DisplayName("Senha")]
        [PasswordPropertyText()]
        public string senha { get; set; }

        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime dataNascimento { get; set; }

        [DisplayName("Sexo")]
        public char sexo { get; set; }

        [DisplayName("Endereço")]
        public string endereco { get; set; }

        [DisplayName("Telefone")]
        public string telefone { get; set; }

        public List<Pedido> listaDePedidos { get; set; }

    }
}