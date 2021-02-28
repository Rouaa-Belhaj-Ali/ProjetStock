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
    public class FamilleController : Controller
    {
        private database db = new database();

        // GET: /Famille/
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

        // GET: /Famille/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Famille famille = db.Familles.Find(id);
            if (famille == null)
            {
                return HttpNotFound();
            }
            return View(famille);
        }

        // GET: /Famille/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Famille/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,nom_famille")] Famille famille)
        {
            if (ModelState.IsValid)
            {
                db.Familles.Add(famille);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(famille);
        }

        // GET: /Famille/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Famille famille = db.Familles.Find(id);
            if (famille == null)
            {
                return HttpNotFound();
            }
            return View(famille);
        }

        // POST: /Famille/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,nom_famille")] Famille famille)
        {
            if (ModelState.IsValid)
            {
                db.Entry(famille).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(famille);
        }

        // GET: /Famille/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Famille famille = db.Familles.Find(id);
            if (famille == null)
            {
                return HttpNotFound();
            }
            return View(famille);
        }

        // POST: /Famille/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Famille famille = db.Familles.Find(id);
            db.Familles.Remove(famille);
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
