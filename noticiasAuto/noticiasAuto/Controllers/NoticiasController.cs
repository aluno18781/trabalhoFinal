using System;
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
    public class NoticiasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Noticias
        public ActionResult Index()
        {
            var noticias = db.Noticias.Include(n => n.Utilizadores);
            return View(noticias.ToList());
        }

        // GET: Noticias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Noticias");
            }
            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return RedirectToAction("Index", "Noticias");
            }
            return View(noticias);
        }

        // GET: Noticias/Create
        public ActionResult Create()
        {
            ViewBag.UserFK = new SelectList(db.utilizadores, "IdUser", "Nome");
            ViewBag.equipasList = db.Equipas.ToList();
            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idNoticia,Titulo,Fotografia,Conteudo")] Noticias noticias, HttpPostedFileBase fileUploadLogo, FormCollection formCollection)
        {
            ViewBag.equipasList = db.Equipas.ToList();
            if (formCollection["equipaID"] == null)
            {
                ViewBag.equipasList = db.Equipas.ToList();
                ModelState.AddModelError("", "Tem de selecionar pelo menos 1 equipa");
                return View(noticias);
            }

            //array que vai returnar todas as equipas (para as seleccionar na view atravez das checkbox)
            string[] equipasID = formCollection["equipaID"].Split(',');
            var l = new List<int> { };
            foreach (string item in equipasID)
            {
                int i = int.Parse(item);
                l.Add(i);
            }

            noticias.UserFK = getUser();


            //determinar o ID da nova Noticia
            int novoID = 0;
            
            //determinar o nº de Noticias na tabela
            if (db.Noticias.Count() == 0)
            {
                novoID = 1;
            }
            else
            {
                novoID = db.Noticias.Max(a => a.IdNoticia) + 1;
            }

            //Atribuir o ID da nova equipa
            noticias.IdNoticia = novoID;

            string nomeFotografia = "Equipa" + noticias.IdNoticia + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".jpg";
            string caminhoParaFotografia = Path.Combine(Server.MapPath("~/Imagens/"), nomeFotografia);

            //verificar se chega efectivamente um ficheiro ao servidor
            if ((fileUploadLogo != null) && (fileUploadLogo.ContentType.ToString() == "image/jpeg"))
            {

                //guardar o nome da imagem na BD
                noticias.Fotografia = nomeFotografia;

            }
            else
            {
                //não há imagem
                ModelState.AddModelError("", "Não foi fornecida uma imagem ou o ficheiro inserido não é JPG...");
                return View(noticias); //reenvia os dados da 'Noticia' para a view
            }


            //ModelState.IsValid --> confronta os dados fornecidos com o modelo
            //se não respeitar as regras do modelo, rejeita os dados
            if (ModelState.IsValid)
            {
                //try {

                noticias.ListaDeEquipas = db.Equipas.Where(e => l.Contains(e.IdEquipa)).ToList();
                //adiciona na estrutura de dados, na memória do servidor, o objecto Noticia
                db.Noticias.Add(noticias);
                //faz "commit" na BD
                db.SaveChanges();

                //guardar a imagem no disco rigido
                fileUploadLogo.SaveAs(caminhoParaFotografia);

                //redireciona o utilizador para a página de início
                return RedirectToAction("Index");
                
            }

            return View(noticias);
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

        // GET: Noticias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Noticias");
            }
            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserFK = new SelectList(db.utilizadores, "IdUser", "Nome", noticias.UserFK);
            ViewBag.equipasList = db.Equipas.ToList();
            return View(noticias);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase fileUploadLogo, FormCollection formCollection)
        {

            ViewBag.equipasList = db.Equipas.ToList();

            //vai buscar ao form collection os atributos referidos
            Noticias noticias = new Noticias();
            noticias = db.Noticias.Find(Int32.Parse(formCollection["IdNoticia"])); ;
            noticias.Titulo = formCollection["Titulo"];
            noticias.Fotografia = formCollection["Fotografia"];
            noticias.Conteudo = formCollection["Conteudo"];

            //se no formCollection não haver equipas dá erro
            if (formCollection["equipaID"] == null)
            {
                ViewBag.equipasList = db.Equipas.ToList();
                ModelState.AddModelError("", "Tem de selecionar pelo menos 1 equipa");
                return View(noticias);
            }


            //criar um array com as equipas todas separadas por ,
            string[] equipasID = formCollection["equipaID"].Split(',');
            ICollection<Equipas> l = new List<Equipas> { };

            //Insere os ids das equipas na lista
            foreach (Equipas item in db.Equipas.ToList())
            {
                if (equipasID.Contains(item.IdEquipa.ToString()))
                {
                    l.Add(item);
                    if (!item.ListaDeNoticias.Contains(noticias))
                    {
                        item.ListaDeNoticias.Add(noticias);
                    }
                }
                else
                {
                    item.ListaDeNoticias.Remove(noticias);
                }
            }



            string nomeFotografia = "Noticia_" + noticias.IdNoticia + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".jpg";
            string oldName = noticias.Fotografia;
            //indica onde a imagem será guardada
            string caminhoParaFotografia = Path.Combine(Server.MapPath("~/Imagens/"), nomeFotografia); 


            //verificar se chega efetivamente um ficheiro ao servidor
            if ((fileUploadLogo != null) && (fileUploadLogo.ContentType.ToString() == "image/jpeg"))
            {
                //guardar o nome da imagem na BD
                noticias.Fotografia = nomeFotografia;
            }
            else
            {
                //não há imagem
                noticias.Fotografia = formCollection["Fotografia"];
            }


            if (ModelState.IsValid)
            {
                //atualiza os dados da noticia, na estrutura de dados em memória

                noticias.ListaDeEquipas = l;
                db.Entry(noticias).State = EntityState.Modified;
                db.SaveChanges();

                if (fileUploadLogo != null)
                {
                    //guardar o nome da imagem na BD
                    fileUploadLogo.SaveAs(caminhoParaFotografia);
                    System.IO.File.Delete(Path.Combine(Server.MapPath("~/Imagens/"), oldName));
                }
                ViewBag.UserFK = new SelectList(db.utilizadores, "IdUser", "Nome", noticias.UserFK);
                return RedirectToAction("Index");
            }
            return View(noticias);
        }

        // GET: Noticias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index", "Noticias");

            }
            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return HttpNotFound();
            }
            return View(noticias);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //procurar a Notícia
            Noticias noticias = db.Noticias.Find(id);

            try
            {
                //remover da memória
                db.Noticias.Remove(noticias);
                //commit na BD
                db.SaveChanges();
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Imagens/"), noticias.Fotografia));
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                //gerar uma mensagem de erro, a ser aprentada ao utilizador
                ViewBag.UserFK = new SelectList(db.utilizadores, "IdUser", "Nome", noticias.UserFK);
                ModelState.AddModelError("", string.Format("Não foi possível remover a Notícia...", id));
                //reenviar os dados para a View
            }
            return View(noticias);



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
