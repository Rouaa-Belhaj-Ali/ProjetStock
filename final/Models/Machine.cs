using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppStock.Models
{
    public class Machine
    {
        public int Id { get; set; }


        [Display(Name = "MACHINE")]
        public string nom_machine { get; set; }

        public virtual ICollection<Mvtarticle> mvtarticles { get; set; }
    }
}