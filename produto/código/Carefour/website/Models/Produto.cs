using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class Produto
    {
        public int id { get; set; }

        [DisplayName("Caminho da Imagem")]
        [StringLength(200, ErrorMessage = "O campo permite no máximo 50 caracteres!")]
        public string imagem { get; set; }


        [Required]
        [DisplayName("Descrição do Produto")]
        public string descricao { get; set; }


        [Required]
        public double preco { get; set; }

        [Required]
        public Categoria categoria { get; set; }
    }

    
}