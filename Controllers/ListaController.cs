using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PraticandoMVC.Models;
using PraticandoMVC.Models.ViewModel;

namespace PraticandoMVC.Controllers
{
    public class ListaController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Lista
        public ActionResult Index()
        {
            //var listas = db.Listas.Include(l => l.Usuario);
            //return View(listas.ToList());

            ListaViewModel listaModel = new ListaViewModel();
            listaModel.Introducao = "Bem vindo!";
            listaModel.Listas = db.Listas.Include(l => l.Usuario).Include(l => l.Tarefas).ToList();

            return View(listaModel);
        }

        // GET: Lista/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Listas.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            return View(lista);
        }

        // GET: Lista/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Email");
            return View();
        }

        // POST: Lista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListaId,Nome,Ativa,UsuarioId")] Lista lista)
        {
            if (ModelState.IsValid)
            {
                db.Listas.Add(lista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Email", lista.UsuarioId);
            return View(lista);
        }

        // GET: Lista/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Listas.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Email", lista.UsuarioId);
            return View(lista);
        }

        // POST: Lista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListaId,Nome,Ativa,UsuarioId")] Lista lista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Email", lista.UsuarioId);
            return View(lista);
        }

        // GET: Lista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Listas.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            return View(lista);
        }

        // POST: Lista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lista lista = db.Listas.Find(id);
            db.Listas.Remove(lista);
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
