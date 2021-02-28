using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppStock.Models
{
    public class Fournisseur
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "FOURNISSEUR")]
        public string nom_fournisseur { get; set; }

        
        [Display(Name = "MATRICULE")]
       
       
        public string matricule { get; set; }

       

        [Required]
        [Display(Name = "ADRESSE")]
        public string adresse { get; set; }

        [Required]
        [Display(Name = "EMAIL")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "numéro de telephone comporte 8 chiffre.")]
        [Display(Name = "TELEPHONE")]
        public string telephone { get; set; }

        public virtual ICollection<Commande> commandes  { get; set; }

    }
}