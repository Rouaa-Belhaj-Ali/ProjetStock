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
    public class EmployeeController : Controller
    {
        private database db = new database();

        // GET: /Employee/
        public ActionResult Index()
        {
            if (Session["matricule"] != null)
            {

                if (Session["fonction"].ToString() == "magasinier")
                {

                    var employees = db.Employees.Include(e => e.fonction);
                    return View(employees.ToList());

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

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            ViewBag.FonctionID = new SelectList(db.Fonctions, "Id", "nom_fonction");
            return View();
        }

        // POST: /Employee/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,matricule,nom,prenom,email,identifiant,motdepasse,FonctionID")] Employee employee)
        {

            string ch = Guid.NewGuid().ToString();
            string x = ch.Substring(0, 8);
            employee.matricule = "MATE-" + x.ToString();

            
            
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FonctionID = new SelectList(db.Fonctions, "Id", "nom_fonction", employee.FonctionID);
            return View(employee);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.FonctionID = new SelectList(db.Fonctions, "Id", "nom_fonction", employee.FonctionID);
            return View(employee);
        }

        // POST: /Employee/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,matricule,nom,prenom,email,identifiant,motdepasse,FonctionID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FonctionID = new SelectList(db.Fonctions, "Id", "nom_fonction", employee.FonctionID);
            return View(employee);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
