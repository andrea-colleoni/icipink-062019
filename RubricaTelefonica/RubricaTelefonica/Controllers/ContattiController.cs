using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RubricaTelefonica.Models;

namespace RubricaTelefonica.Controllers
{
    public class ContattiController : Controller
    {
        private rubricaEntities db = new rubricaEntities();

        // GET: Contatti
        public ActionResult Index()
        {
            var contatto = db.contatto.Include(c => c.categoria);
            return View(contatto.OrderBy(c => c.cognome).ToList());
        }

        // GET: Contatti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contatto contatto = db.contatto.Find(id);
            if (contatto == null)
            {
                return HttpNotFound();
            }
            return View(contatto);
        }

        // GET: Contatti/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.categoria, "id", "nome");
            return View();
        }

        // POST: Contatti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,cognome,telefono,email,indirizzo,foto,data_nascita,preferito,id_categoria")] contatto contatto)
        {
            if (ModelState.IsValid)
            {
                db.contatto.Add(contatto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.categoria, "id", "nome", contatto.id_categoria);
            return View(contatto);
        }

        // GET: Contatti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contatto contatto = db.contatto.Find(id);
            if (contatto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.categoria, "id", "nome", contatto.id_categoria);
            return View(contatto);
        }

        // POST: Contatti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,cognome,telefono,email,indirizzo,foto,data_nascita,preferito,id_categoria")] contatto contatto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contatto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.categoria, "id", "nome", contatto.id_categoria);
            return View(contatto);
        }

        // GET: Contatti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contatto contatto = db.contatto.Find(id);
            if (contatto == null)
            {
                return HttpNotFound();
            }
            return View(contatto);
        }

        // POST: Contatti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contatto contatto = db.contatto.Find(id);
            db.contatto.Remove(contatto);
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
