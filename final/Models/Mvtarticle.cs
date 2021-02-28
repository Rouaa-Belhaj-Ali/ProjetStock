using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppStock.Models
{
    public class Mvtarticle
    {

        public int id { get; set; }

        

        [Display(Name = "REFERENCE")]
        public string reference { get; set; }

        [Required]
        [Display(Name = "DATE")]
        public string date { get; set; }

        [Required]
        [Display(Name = "OBSERVATION")]
        public string observation { get; set; }
      
        [Required]
        public int OperationID { get; set; }

        [ForeignKey("OperationID")]
        public virtual Operation operation { get; set; }



        [Required]
        public int ArticleID { get; set; }

        [ForeignKey("ArticleID")]
        public virtual Article article { get; set; }

        [Required]
        [Display(Name = "QUANTITE")]
        public int quantite { get; set; } 

        [Required]
        public int MachineID { get; set; }

        [ForeignKey("MachineID")]
        public virtual Machine machine { get; set; }



        [Required]
        public int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual Employee employee { get; set; }

    }
}