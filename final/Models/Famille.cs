using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppStock.Models
{
    public class Famille
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "FAMILLE")]
        public string nom_famille { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}