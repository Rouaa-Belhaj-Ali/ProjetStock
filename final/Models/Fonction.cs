using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppStock.Models
{
    public class Fonction
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "FONCTION")]
        public string nom_fonction { get; set; }
        

        public virtual ICollection<Employee> employees { get; set; }

    }
}