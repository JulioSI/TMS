using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class Item : Produto
    {
        public int id { get; set; }

        [Required]
        public int quantidade { get; set; }       
    }
}