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
    public class ArticleController : Controller
    {
        private database db = new database();

        // GET: /Article/
        public ActionResult Index()
        {

            if (Session["matricule"] != null)
            {

                if (Session["fonction"].ToString() == "magasinier")
                {
                    var articles = db.Articles.Include(a => a.famille);
                    return View(articles.ToList());
        
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

        // GET: /Article/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }


            return View(article);
        }

        // GET: /Article/Create
        public ActionResult Create()
        {
            ViewBag.FamilleID = new SelectList(db.Familles, "Id", "nom_famille");
            return View();
        }

        // POST: /Article/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,nom_article,reference,quantite,observation,FamilleID")] Article article)
        {
            string ch = Guid.NewGuid().ToString();
            string x = ch.Substring(0, 8);
            article.reference = "REFA-" + x.ToString();


            
            
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FamilleID = new SelectList(db.Familles, "Id", "nom_famille", article.FamilleID);
            return View(article);
        }

        // GET: /Article/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilleID = new SelectList(db.Familles, "Id", "nom_famille", article.FamilleID);
            return View(article);
        }

        // POST: /Article/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,nom_article,reference,quantite,observation,FamilleID")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FamilleID = new SelectList(db.Familles, "Id", "nom_famille", article.FamilleID);
            return View(article);
        }

        // GET: /Article/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: /Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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


        // GET: /AddQte/AddQte/5
        public ActionResult AddQte(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilleID = new SelectList(db.Familles, "Id", "nom_famille", article.FamilleID);
            return View(article);
        }

        // POST: /AddQte/EAddQte/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQte([Bind(Include = "Id,nom_article,reference,quantite,observation,FamilleID")] Article article)
        {

            Article art2 = new Article();
            art2 = db.Articles.Find(article.Id);
            art2.quantite = art2.quantite + article.quantite;


            if (ModelState.IsValid)
            {
                db.Entry(art2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FamilleID = new SelectList(db.Familles, "Id", "nom_famille", article.FamilleID);
            return View(article);
        }

    
    }
}
