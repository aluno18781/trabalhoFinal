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
    public class ComentariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comentarios
        public ActionResult Index()
        {
            var comentarios = db.Comentarios.Include(c => c.Noticia).Include(c => c.Utilizador);
            return View(comentarios.ToList());
        }

        // GET: Comentarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Noticias");
            }
            Comentarios comentarios = db.Comentarios.Find(id);
            if (comentarios == null)
            {
                return HttpNotFound();
            }
            return View(comentarios);
        }

        // GET: Comentarios/Create
        public ActionResult Create()
        {
            ViewBag.NoticiaFK = new SelectList(db.Noticias, "IdNoticia", "Título");
            ViewBag.UserFK = new SelectList(db.utilizadores, "IdUser", "Nome");
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idComentario,Conteudo")] Comentarios comentarios, int noticiaID)
        {


            comentarios.UserFK = getUser();
            comentarios.NoticiaFK = noticiaID;


            if (ModelState.IsValid)
            {
                db.Comentarios.Add(comentarios);
                db.SaveChanges();
                return RedirectToAction("Details", "Noticias", new { id = comentarios.NoticiaFK });
            }

            ViewBag.NoticiaFK = new SelectList(db.Noticias, "idNoticia", "Titulo", comentarios.NoticiaFK);
            ViewBag.UserFK = new SelectList(db.utilizadores, "idUser", "Nome", comentarios.UserFK);
            return View(comentarios);
        }

        public int getUser()
        {

            var userID = db.utilizadores.Where(u => u.Email.Equals(User.Identity.Name));
            var aux = 0;

            foreach (var item in userID)
            {
                aux = item.IdUser;
            }
            return aux;
        }

        // GET: Comentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Noticias");
            }
            Comentarios comentarios = db.Comentarios.Find(id);
            if (comentarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.NoticiaFK = new SelectList(db.Noticias, "IdNoticia", "Título", comentarios.NoticiaFK);
            ViewBag.UserFK = new SelectList(db.utilizadores, "IdUser", "Nome", comentarios.UserFK);
            return View(comentarios);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComentario,Conteudo")] Comentarios comentarios, int noticiaID)
        {
            comentarios.UserFK = getUser();
            comentarios.NoticiaFK = noticiaID;

            if (ModelState.IsValid)
            {
                db.Entry(comentarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Noticias", new { id = comentarios.NoticiaFK });
            }
            ViewBag.NoticiaFK = new SelectList(db.Noticias, "idNoticia", "Titulo", comentarios.NoticiaFK);
            ViewBag.UserFK = new SelectList(db.utilizadores, "idUser", "Nome", comentarios.UserFK);
            return View(comentarios);
        }

        // GET: Comentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Noticias");
            }
            Comentarios comentarios = db.Comentarios.Find(id);
            if (comentarios == null)
            {
                return HttpNotFound();
            }
            return View(comentarios);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentarios comentarios = db.Comentarios.Find(id);
            db.Comentarios.Remove(comentarios);
            db.SaveChanges();
            return RedirectToAction("Details", "Noticias", new { id = comentarios.NoticiaFK });
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