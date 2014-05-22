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
        [Required(ErrorMessage = "O preenchimento do nome é obrigatório.")]      
        [StringLength(100,ErrorMessage = "O campo Nome permite no máximo 100 caracteres!")]
        public string nome { get; set; }

        [DisplayName("Email")]
        [StringLength(50)]
        [Required(ErrorMessage = "Informe o Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        public string email { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "O preenchimento do campo senha é obrigatório.")]  
        [PasswordPropertyText()]
        public string senha { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "O preenchimento do campo data de nascimento é obrigatório.")]   
        [DataType(DataType.Date)]
        public DateTime dataNascimento { get; set; }

        [DisplayName("Sexo")]
        public char sexo { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage = "O preenchimento do campo endereço é obrigatório.")]  
        public string endereco { get; set; }

        [DisplayName("Telefone")]
        [Required(ErrorMessage = "O preenchimento do campo telefone é obrigatório.")]
        public string telefone { get; set; }

        public List<Pedido> listaDePedidos { get; set; }

    }
}