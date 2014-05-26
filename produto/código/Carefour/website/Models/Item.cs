using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    
    [Serializable]
    public class Item : Produto
    {
        public Item() { }

        public int id { get; set; }

        public double preco { get; set; }

        public string descricao { get; set; }

        [Required]
        public int quantidade { get; set; }       
    }
}