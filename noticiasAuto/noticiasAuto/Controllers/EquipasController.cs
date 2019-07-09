﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using noticiasAuto.Models;

namespace noticiasAuto.Controllers
{
    public class EquipasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Equipas
        public ActionResult Index()
        {
            return View(db.Equipas.ToList());
        }

        // GET: Equipas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipas equipas = db.Equipas.Find(id);
            if (equipas == null)
            {
                return HttpNotFound();
            }
            return View(equipas);
        }

        // GET: Equipas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEquipa,Nome,DataFundacao,Logo,Fundador,Nacionalidade")] Equipas equipas)
        {
            if (ModelState.IsValid)
            {
                db.Equipas.Add(equipas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipas);
        }

        // GET: Equipas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Noticias");
            }
            Equipas equipas = db.Equipas.Find(id);
            if (equipas == null)
            {
                return HttpNotFound();
            }
            return View(equipas);
        }

        // POST: Equipas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEquipa,Nome,Presidente,Treinador,Nacionalidade,Cidade,Logo,DataFundacao")] Equipas equipa, HttpPostedFileBase fileUploadLogo, string DataFundacao)
        {

            DateTime dataFund = DateTime.Parse(DataFundacao);
            equipa.DataFundacao = dataFund;


            string nomeLogo = "Equipa" + equipa.IdEquipa + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".jpg";
            string oldName = equipa.Logo;
            string caminhoParaLogo = Path.Combine(Server.MapPath("~/Imagens/"), nomeLogo); //indica onde a imagem será guardada


            //verificar se chega efetivamente um ficheiro ao servidor
            if ((fileUploadLogo != null) && (fileUploadLogo.ContentType.ToString() == "image/jpeg"))
            {
                //guardar o nome da imagem na BD
                equipa.Logo = nomeLogo;
            }
            else
            {
                //não há imagem
                ModelState.AddModelError("", "Não foi fornecida uma imagem ou o ficheiro inserido não é JPG...");
                return View(equipa); //reenvia os dados da 'Equipa' para a view
            }


            if (ModelState.IsValid)
            {
                //atualiza os dados da equipa, na estrutura de dados em memória
                db.Entry(equipa).State = EntityState.Modified;
                db.SaveChanges();

                if (fileUploadLogo != null)
                {
                    //guardar o nome da imagem na BD
                    fileUploadLogo.SaveAs(caminhoParaLogo);
                    System.IO.File.Delete(Path.Combine(Server.MapPath("~/Imagens/"), oldName));
                }

                return RedirectToAction("Index");
            }
            return View(equipa);
        }

        // GET: Equipas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipas equipas = db.Equipas.Find(id);
            if (equipas == null)
            {
                return HttpNotFound();
            }
            return View(equipas);
        }

        // POST: Equipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //procurar a Equipa
            Equipas equipa = db.Equipas.Find(id);

            try
            {
                //remover da memória
                db.Equipas.Remove(equipa);
                //commit na BD
                db.SaveChanges();
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Imagens/"), equipa.Logo));
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                //gerar uma mensagem de erro, a ser aprentada ao utilizador
                ModelState.AddModelError("", string.Format("Não foi possível remover a Equipa, porque existem notícias associadas a ela.", id));
                //reenviar os dados para a View
            }
            return View(equipa);

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
