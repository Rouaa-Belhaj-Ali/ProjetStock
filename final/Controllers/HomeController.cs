using AppStock.Models;
using final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["matricule"] != null)
            {

                if (Session["fonction"].ToString() == "magasinier")
                {
                    return View();
                }
                else
                {

                    return RedirectToAction("Index", "ListArt");
                }
            }
            else
            {
                return View("login");
            }
          
        }


        


        public ActionResult chartArticle()
        {

            return View();
        }

        public ActionResult chartArticle2()
        {

            return View();
        }

        public ActionResult chartCommande()
        {

            return View();


        }



        //Login form

        public ActionResult login()
        {
            if (Session["matricule"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult login(Employee user)
        {
            using (database db = new database())
            {
                if ((user.identifiant == null || user.motdepasse == null) || (user.identifiant == null && user.motdepasse == null))
                {
                    ViewBag.Message1 = "Il faut remplir les champs Identifiant et mot de passe.";
                }
                else
                {

                       var usr = db.Employees.FirstOrDefault(u => u.identifiant == user.identifiant && u.motdepasse == user.motdepasse);
                         
                    if (usr != null)
                            {
                                Session["matricule"] = usr.matricule.ToString();
                                Session["fonction"] = usr.fonction.nom_fonction.ToString();
                                Session["username"] = usr.nom.ToString();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ViewBag.Message = "les champs Identifiant et mot de passe non valide.";
                            }

                     
                                    
                }
            }
            return View();
        }

       

        //Login form

        public ActionResult logOff(){

            Session.Clear();
            return RedirectToAction("login");
        }





    }
}