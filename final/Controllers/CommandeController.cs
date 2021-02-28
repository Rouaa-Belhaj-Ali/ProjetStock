using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppStock.Models;
using final.Models;

namespace final.Controllers
{
    public class CommandeController : Controller
    {
        private database db = new database();

        // GET: /Commande/
        public ActionResult Index()
        {



            if (Session["matricule"] != null)
            {

                if (Session["fonction"].ToString() == "magasinier")
                {
                    var commandes = db.Commandes.Include(c => c.article).Include(c => c.fournisseur);
                    return View(commandes.ToList());

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

        // GET: /Commande/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // GET: /Commande/Create
        public ActionResult Create()
        {
            ViewBag.ArticleID = new SelectList(db.Articles, "Id", "nom_article");
            ViewBag.FournisseurID = new SelectList(db.Fournisseurs, "Id", "nom_fournisseur");
            return View();
        }

        // POST: /Commande/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,reference_commande,date,FournisseurID,ArticleID,quantite,observation")] Commande commande)
        {

            string ch = Guid.NewGuid().ToString();
            string x = ch.Substring(0, 8);
            commande.reference_commande = "REFC-" + x.ToString();
            
            if (ModelState.IsValid)
            {
                db.Commandes.Add(commande);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleID = new SelectList(db.Articles, "Id", "nom_article", commande.ArticleID);
            ViewBag.FournisseurID = new SelectList(db.Fournisseurs, "Id", "nom_fournisseur", commande.FournisseurID);
            return View(commande);
        }

        // GET: /Commande/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "Id", "nom_article", commande.ArticleID);
            ViewBag.FournisseurID = new SelectList(db.Fournisseurs, "Id", "nom_fournisseur", commande.FournisseurID);
            return View(commande);
        }

        // POST: /Commande/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,reference_commande,date,FournisseurID,ArticleID,quantite,observation")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "Id", "nom_article", commande.ArticleID);
            ViewBag.FournisseurID = new SelectList(db.Fournisseurs, "Id", "nom_fournisseur", commande.FournisseurID);
            return View(commande);
        }

        // GET: /Commande/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // POST: /Commande/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commande commande = db.Commandes.Find(id);
            db.Commandes.Remove(commande);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
