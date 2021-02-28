using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppStock.Models
{
    public class Employee
    {
        public int Id { get; set; }
         
       


        [Display(Name = "MATRICULE")]
        public string matricule { get; set; }

        [Required]
        [Display(Name = "NOM")]
        [MaxLength(30)]
        public string nom { get; set; }

        [Required]
        [Display(Name = "PRENOM")]
        [MaxLength(30)]
        public string prenom { get; set; }


        [Display(Name = "EMAIL")]
        [Required]
        public string email { get; set; }

        [Required]
        [Display(Name = "IDENTIFIANT")]
        [MaxLength(10)]
        public string identifiant { get; set; }

        [Required]
        [Display(Name = "MOT DE PASSE")]
        [MaxLength(10)]
        public string motdepasse { get; set; }


        public int FonctionID { get; set; }

        [ForeignKey("FonctionID")]
        public virtual Fonction fonction { get; set; }

        public virtual ICollection<Mvtarticle> mvtarticles { get; set; }
    }
}