using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppStock.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "ARTICLE")]
        public string nom_article { get; set; }

        
        [Display(Name = "REFERENCE")]
      
        public string reference { get; set; }

        

        [Required]
        [Display(Name = "QUANTITE")]
        public int quantite { get; set; }

        [Required]
        [Display(Name = "OBSERVATION")]
        public string observation { get; set; }

        [Required]
        public int FamilleID { get; set; }

        [ForeignKey("FamilleID")]
        public virtual Famille famille { get; set; }

        public virtual ICollection<Commande> commandes { get; set; }
        public virtual ICollection<Mvtarticle> mvtarticles { get; set; }


       
    }
}