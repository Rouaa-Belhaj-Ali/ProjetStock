using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppStock.Models
{
    public class Commande
    {

        public int Id { get; set; }

       
        [Display(Name = "REFERENCE")]
        public string reference_commande { get; set; }

        [Required]
        [Display(Name = "DATE")]
        public string date { get; set; }

       
        public int FournisseurID { get; set; }

        [ForeignKey("FournisseurID")]
        public virtual Fournisseur fournisseur { get; set; }
       

        
        public int ArticleID { get; set; }

        [ForeignKey("ArticleID")]
        public virtual Article article { get; set; }

        [Required]
        [Display(Name = "QUANTITE")]
        public int quantite { get; set; } 

        [Required]
        [Display(Name = "OBSERVATION")]
        public string observation { get; set; } 

    }
}