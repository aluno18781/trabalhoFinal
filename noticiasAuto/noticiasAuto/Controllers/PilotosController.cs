using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using noticiasAuto.Models;

namespace noticiasAuto.Controllers
{
    public class PilotosController : Controller
    {
        private NoticiasDB db = new NoticiasDB();

        // GET: Pilotos
        public ActionResult Index()
        {
            var pilotos = db.Pilotos.Include(p => p.Equipa);
            return View(pilotos.ToList());
        }

        // GET: Pilotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilotos pilotos = db.Pilotos.Find(id);
            if (pilotos == null)
            {
                return HttpNotFound();
            }
            return View(pilotos);
        }

        // GET: Pilotos/Create
        public ActionResult Create()
        {
            ViewBag.EquipaFK = new SelectList(db.Equipas, "IdEquipa", "Nome");
            return View();
        }

        // POST: Pilotos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPiloto,Nome,DataNascimento,Nacionalidade,Fotografia,EquipaFK")] Pilotos pilotos, string DataNascimento, HttpPostedFileBase fileUploadLogo)
        {
            string nomeFoto = "Piloto" + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".jpg";
            string pathFoto = Path.Combine(Server.MapPath("~/Imagens/"), nomeFoto);

            //caso chegue efectivamente um ficheiro ao servidor
            if ((fileUploadLogo != null) && (fileUploadLogo.ContentType.ToString() == "image/jpeg"))
            {
                //guardar na BD
                pilotos.Fotografia = nomeFoto;
            }
            else
            {
                // não há imagem...
                ModelState.AddModelError("", "Não foi fornecida uma imagem ou o ficheiro inserido não é JPG...");
                return View(pilotos);
            }

            DateTime dataNasci = DateTime.Parse(DataNascimento);
            pilotos.DataNascimento = dataNasci;

            if (ModelState.IsValid)
            {
                db.Pilotos.Add(pilotos);
                db.SaveChanges();

                fileUploadLogo.SaveAs(pathFoto);

                return RedirectToAction("Details", "Equipas", new { id = pilotos.EquipaFK });

            }

            ViewBag.EquipaFK = new SelectList(db.Equipas, "IdEquipa", "Nome", pilotos.EquipaFK);
            return View(pilotos);
        }

        // GET: Pilotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Equipas");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilotos pilotos = db.Pilotos.Find(id);
            if (pilotos == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipaFK = new SelectList(db.Equipas, "IdEquipa", "Nome", pilotos.EquipaFK);
            return View(pilotos);
        }

        // POST: Pilotos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPiloto,EquipaFK,Nome,DataNascimento,Nacionalidade,Fotografia")] Pilotos pilotos, string DataNascimento, HttpPostedFileBase fileUploadLogo, string fileUploadLogoAntigo)
        {
            ViewBag.EquipaFK = new SelectList(db.Equipas, "idEquipa", "Nome", pilotos.EquipaFK);

            DateTime dataNasci = DateTime.Parse(DataNascimento);
            pilotos.DataNascimento = dataNasci;


            string nomeFotografia = "Piloto" + pilotos.IdPiloto + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".jpg";
            string oldName = fileUploadLogoAntigo;
            string caminhoParaLogo = Path.Combine(Server.MapPath("~/Imagens/"), nomeFotografia);



            //verificar se chega efetivamente um ficheiro ao servidor
            if ((fileUploadLogo != null) && (fileUploadLogo.ContentType.ToString() == "image/jpeg"))
            {
                //guardar o nome da imagem na BD
                pilotos.Fotografia = nomeFotografia;
            }
            else
            {
                pilotos.Fotografia = oldName;
                // não há imagem...
                ModelState.AddModelError("", "Não foi fornecida uma imagem ou o ficheiro inserido não é JPG...");

                return View(pilotos);
            }


            if (ModelState.IsValid)
            {
                db.Entry(pilotos).State = EntityState.Modified;
                db.SaveChanges();
            }
            if (fileUploadLogo != null)
            {
                //guardar o nome da imagem na BD
                fileUploadLogo.SaveAs(caminhoParaLogo);
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Imagens/"), oldName));
            }



            ViewBag.EquipaFK = new SelectList(db.Equipas, "idEquipa", "Nome", pilotos.EquipaFK);
            return RedirectToAction("Details", "Equipas", new { id = pilotos.EquipaFK });
        }

        // GET: Pilotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilotos pilotos = db.Pilotos.Find(id);
            if (pilotos == null)
            {
                return HttpNotFound();
            }
            return View(pilotos);
        }

        // POST: Pilotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pilotos pilotos = db.Pilotos.Find(id);
            db.Pilotos.Remove(pilotos);
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
