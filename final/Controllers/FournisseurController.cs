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
    public class FournisseurController : Controller
    {
        private database db = new database();

        // GET: /Fournisseur/
        public ActionResult Index()
        {
           
            if (Session["matricule"] != null)
            {

                if (Session["fonction"].ToString() == "magasinier")
                {

                    return View(db.Fournisseurs.ToList());

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

        // GET: /Fournisseur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fournisseur fournisseur = db.Fournisseurs.Find(id);
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(fournisseur);
        }

        // GET: /Fournisseur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Fournisseur/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,nom_fournisseur,matricule,adresse,email,telephone")] Fournisseur fournisseur)
        {

            string ch = Guid.NewGuid().ToString();
            string x = ch.Substring(0, 8);
            fournisseur.matricule = "MATF-" + x.ToString();


            if (ModelState.IsValid)
            {
                db.Fournisseurs.Add(fournisseur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fournisseur);
        }

        // GET: /Fournisseur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fournisseur fournisseur = db.Fournisseurs.Find(id);
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(fournisseur);
        }

        // POST: /Fournisseur/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,nom_fournisseur,matricule,adresse,email,telephone")] Fournisseur fournisseur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fournisseur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fournisseur);
        }

        // GET: /Fournisseur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fournisseur fournisseur = db.Fournisseurs.Find(id);
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(fournisseur);
        }

        // POST: /Fournisseur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fournisseur fournisseur = db.Fournisseurs.Find(id);
            db.Fournisseurs.Remove(fournisseur);
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
