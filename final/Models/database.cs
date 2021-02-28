using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace final.Models
{
    public class database : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public database() : base("name=database")
        {
        }

        public System.Data.Entity.DbSet<AppStock.Models.Fournisseur> Fournisseurs { get; set; }

        public System.Data.Entity.DbSet<AppStock.Models.Machine> Machines { get; set; }

        public System.Data.Entity.DbSet<AppStock.Models.Operation> Operations { get; set; }

        public System.Data.Entity.DbSet<AppStock.Models.Fonction> Fonctions { get; set; }

        public System.Data.Entity.DbSet<AppStock.Models.Famille> Familles { get; set; }

        public System.Data.Entity.DbSet<AppStock.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<AppStock.Models.Article> Articles { get; set; }

        public System.Data.Entity.DbSet<AppStock.Models.Commande> Commandes { get; set; }

        public System.Data.Entity.DbSet<AppStock.Models.Mvtarticle> Mvtarticles { get; set; }
    
    }
}
