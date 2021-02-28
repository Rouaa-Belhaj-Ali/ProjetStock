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
    public class MvtarticleController : Controller
    {
        private database db = new database();

        // GET: /Mvtarticle/
        public ActionResult Index()
        {
           
            if (Session["matricule"] != null)
            {

                if (Session["fonction"].ToString() == "magasinier")
                {
                    var mvtarticles = db.Mvtarticles.Include(m => m.article).Include(m => m.employee).Include(m => m.machine).Include(m => m.operation);
                    return View(mvtarticles.ToList());
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

        // GET: /Mvtarticle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mvtarticle mvtarticle = db.Mvtarticles.Find(id);
            if (mvtarticle == null)
            {
                return HttpNotFound();
            }
            return View(mvtarticle);
        }

        // GET: /Mvtarticle/Create
        public ActionResult Create()
        {
            ViewBag.ArticleID = new SelectList(db.Articles, "Id", "nom_article");
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "matricule");
            ViewBag.MachineID = new SelectList(db.Machines, "Id", "nom_machine");
            ViewBag.OperationID = new SelectList(db.Operations, "Id", "nom_operation");
            return View();
        }

        // POST: /Mvtarticle/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,reference,date,observation,OperationID,ArticleID,quantite,MachineID,EmployeeID")] Mvtarticle mvtarticle)
        {
            if (ModelState.IsValid)
            {
                db.Mvtarticles.Add(mvtarticle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleID = new SelectList(db.Articles, "Id", "nom_article", mvtarticle.ArticleID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "matricule", mvtarticle.EmployeeID);
            ViewBag.MachineID = new SelectList(db.Machines, "Id", "nom_machine", mvtarticle.MachineID);
            ViewBag.OperationID = new SelectList(db.Operations, "Id", "nom_operation", mvtarticle.OperationID);
            return View(mvtarticle);
        }

        // GET: /Mvtarticle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mvtarticle mvtarticle = db.Mvtarticles.Find(id);
            if (mvtarticle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "Id", "nom_article", mvtarticle.ArticleID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "matricule", mvtarticle.EmployeeID);
            ViewBag.MachineID = new SelectList(db.Machines, "Id", "nom_machine", mvtarticle.MachineID);
            ViewBag.OperationID = new SelectList(db.Operations, "Id", "nom_operation", mvtarticle.OperationID);
            return View(mvtarticle);
        }

        // POST: /Mvtarticle/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,reference,date,observation,OperationID,ArticleID,quantite,MachineID,EmployeeID")] Mvtarticle mvtarticle)
        {

            //génération automatique de matricule
            string ch = Guid.NewGuid().ToString();
            string x = ch.Substring(0, 8);
            mvtarticle.reference = "REFM-" + x.ToString();

            //MAJ Quantité Article en cas de retour d'article/ 1-> Retour article

            Article art = new Article();
            art = db.Articles.Find(mvtarticle.ArticleID);
            if (mvtarticle.OperationID == 1)
            {
                art.quantite = art.quantite + mvtarticle.quantite;
            }
            db.Entry(art).State = EntityState.Modified;
            db.SaveChanges();

            //MAJ Quantité Article en cas de sortir article

            Article art2 = new Article();
            art2 = db.Articles.Find(mvtarticle.ArticleID);
            if (art2.quantite >= mvtarticle.quantite)
            {
                if (mvtarticle.OperationID == 2)
                {
                    art2.quantite = art.quantite - mvtarticle.quantite;
                }
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Quantité article " + art2.nom_article + " non disponible!'); window.location.href = '/Mvtarticle/Create/'; </script> ");
            }

            db.Entry(art2).State = EntityState.Modified;
            db.SaveChanges();


            if (ModelState.IsValid)
            {
                db.Entry(mvtarticle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "Id", "nom_article", mvtarticle.ArticleID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "matricule", mvtarticle.EmployeeID);
            ViewBag.MachineID = new SelectList(db.Machines, "Id", "nom_machine", mvtarticle.MachineID);
            ViewBag.OperationID = new SelectList(db.Operations, "Id", "nom_operation", mvtarticle.OperationID);
            return View(mvtarticle);
        }

        // GET: /Mvtarticle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mvtarticle mvtarticle = db.Mvtarticles.Find(id);
            if (mvtarticle == null)
            {
                return HttpNotFound();
            }
            return View(mvtarticle);
        }

        // POST: /Mvtarticle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mvtarticle mvtarticle = db.Mvtarticles.Find(id);
            db.Mvtarticles.Remove(mvtarticle);
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
