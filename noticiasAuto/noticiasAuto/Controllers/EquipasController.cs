using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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
        public async Task<ActionResult> Create([Bind(Include = "IdEquipa,Nome,DataFundacao,Logo,Fundador,Nacionalidade")] Equipas equipas, HttpPostedFileBase fileUploadFotografia)
        {

            // determinar o ID do novo Agente
            int novoID = 0;
            // *****************************************
            // proteger a geração de um novo ID
            // *****************************************
            // determinar o nº de tipo de pratos na tabela
            if (db.Equipas.Count() == 0)
            {
                novoID = 1;
            }
            else
            {
                novoID = db.Equipas.Max(a => a.IdEquipa) + 1;
            }
            // atribuir o ID ao novo agente
            equipas.IdEquipa = novoID;
            // ***************************************************
            // outra hipótese possível seria utilizar o
            // try { }
            // catch(Exception) { }
            // ***************************************************

            // var. auxiliar
            string nomeFotografia = "equipas" + novoID + ".jpg";
            string caminhoParaFotografia = Path.Combine(Server.MapPath("~/Imagens/"), nomeFotografia); // indica onde a imagem será guardada

            // verificar se chega efetivamente um ficheiro ao servidor
            if (fileUploadFotografia != null)
            {
                // guardar o nome da imagem na BD
                equipas.Logo = nomeFotografia;
            }
            else
            {
                // não há imagem...
                ModelState.AddModelError("", "Não foi fornecida uma imagem..."); // gera MSG de erro
                return View(equipas); // reenvia os dados do 'Agente' para a View
            }

            if (ModelState.IsValid)
            {
                // guardar a imagem no disco rígido
                fileUploadFotografia.SaveAs(caminhoParaFotografia);
                db.Equipas.Add(equipas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(equipas);
        }


        // GET: Equipas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipas equipas = await db.Equipas.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "IdEquipa,Nome,DataFundacao,Logo,Fundador,Nacionalidade")] Equipas equipas, HttpPostedFileBase uploadFoto)

        {
            // vars. auxiliares
            string novoNome = "";
            string nomeAntigo = "";

            if (ModelState.IsValid)
            {
                try
                {              /// se foi fornecida uma nova imagem,
                               /// preparam-se os dados para efetuar a alteração
                    if (uploadFoto != null)
                    {
                        /// antes de se fazer alguma coisa, preserva-se o nome antigo da imagem,
                        /// para depois a remover do disco rígido do servidor
                        nomeAntigo = equipas.Logo;
                        /// para o novo nome do ficheiro, vamos adicionar o termo gerado pelo timestamp
                        /// devidamente formatado, mais
                        /// A extensão do ficheiro é obtida automaticamente em vez de ser escrita de forma explícita
                        novoNome = "equipa" + equipas.IdEquipa + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + Path.GetExtension(uploadFoto.FileName).ToLower(); ;
                        /// atualizar os dados do Agente com o novo nome
                        equipas.Logo = novoNome;
                        /// guardar a nova imagem no disco rígido
                        uploadFoto.SaveAs(Path.Combine(Server.MapPath("~/Imagens/"), novoNome));
                    }

                    // guardar os dados do Agente
                    db.Entry(equipas).State = EntityState.Modified;
                    // Commit
                    db.SaveChanges();

                    /// caso tenha sido fornecida uma nova imagem há necessidade de remover 
                    /// a antiga
                    if (uploadFoto != null)
                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/images/"), nomeAntigo));


                    // enviar os dados para a página inicial
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    // caso haja um erro deve ser enviada uma mensagem para o utilizador
                    //ModelState.AddModelError("", string.Format("Ocorreu um erro com a edição dos dados do tipo de Prato {0}", equipas.Nome));
                    return RedirectToAction("Index");
                }
            }
            return View(equipas);
        }




        // POST: Equipas/Delete/5


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Equipas equipa = db.Equipas.Find(id);
            if (equipa == null)
            {
                return HttpNotFound();
            }
            return View(equipa);
        }

        // POST: Equipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //procurar a Equipa
            Equipas equipas = db.Equipas.Find(id);

            try
            {
                //remover da memória
                db.Equipas.Remove(equipas);
                //commit na BD
                db.SaveChanges();
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Imagens/"), equipas.Logo));
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                //gerar uma mensagem de erro, a ser aprentada ao utilizador
                ModelState.AddModelError("", string.Format("Não foi possível remover a Equipa, porque existem notícias associadas a ela.", id));
                //reenviar os dados para a View
            }
            return View(equipas);

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
