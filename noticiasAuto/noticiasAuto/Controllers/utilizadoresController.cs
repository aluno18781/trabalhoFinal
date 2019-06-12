using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using noticiasAuto.Models;

namespace noticiasAuto.Controllers
{
    public class utilizadoresController : Controller
    {
        private NoticiasDB db = new NoticiasDB();

        // GET: utilizadores
        public ActionResult Index()
        {
            return View(db.Utilizadores.ToList());
        }

        // GET: utilizadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utilizadores utilizadores = db.Utilizadores.Find(id);
            if (utilizadores == null)
            {
                return HttpNotFound();
            }
            return View(utilizadores);
        }

        // GET: utilizadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: utilizadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUser,Nome,Email")] utilizadores utilizadores)
        {
            if (ModelState.IsValid)
            {
                db.Utilizadores.Add(utilizadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilizadores);
        }

        // GET: utilizadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utilizadores utilizadores = db.Utilizadores.Find(id);
            if (utilizadores == null)
            {
                return HttpNotFound();
            }
            return View(utilizadores);
        }

        // POST: utilizadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUser,Nome,Email")] utilizadores utilizadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilizadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utilizadores);
        }

        // GET: utilizadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utilizadores utilizadores = db.Utilizadores.Find(id);
            if (utilizadores == null)
            {
                return HttpNotFound();
            }
            return View(utilizadores);
        }

        // POST: utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            utilizadores utilizadores = db.Utilizadores.Find(id);
            db.Utilizadores.Remove(utilizadores);
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
