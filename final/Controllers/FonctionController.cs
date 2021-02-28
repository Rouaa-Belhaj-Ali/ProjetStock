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
    public class FonctionController : Controller
    {
        private database db = new database();

        // GET: /Fonction/
        public ActionResult Index()
        {
          

            if (Session["matricule"] != null)
            {

                if (Session["fonction"].ToString() == "magasinier")
                {

                    return View(db.Familles.ToList());

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

        // GET: /Fonction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fonction fonction = db.Fonctions.Find(id);
            if (fonction == null)
            {
                return HttpNotFound();
            }
            return View(fonction);
        }

        // GET: /Fonction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Fonction/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,nom_fonction")] Fonction fonction)
        {
            if (ModelState.IsValid)
            {
                db.Fonctions.Add(fonction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fonction);
        }

        // GET: /Fonction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fonction fonction = db.Fonctions.Find(id);
            if (fonction == null)
            {
                return HttpNotFound();
            }
            return View(fonction);
        }

        // POST: /Fonction/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,nom_fonction")] Fonction fonction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fonction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fonction);
        }

        // GET: /Fonction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fonction fonction = db.Fonctions.Find(id);
            if (fonction == null)
            {
                return HttpNotFound();
            }
            return View(fonction);
        }

        // POST: /Fonction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fonction fonction = db.Fonctions.Find(id);
            db.Fonctions.Remove(fonction);
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
