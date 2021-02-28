using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppStock.Models
{
    public class Operation
    {
        public int Id { get; set; }


        [Display(Name = "OPERATION")]
        public string nom_operation { get; set; }

        public virtual ICollection<Mvtarticle> mvtarticles { get; set; }
       
    }
}