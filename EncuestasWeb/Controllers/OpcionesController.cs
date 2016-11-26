using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EncuestasWeb.Models;

namespace EncuestasWeb.Controllers
{
    public class OpcionesController : Controller
    {
        private EncuestasUPCEntities db = new EncuestasUPCEntities();

        // GET: Opciones
        public ActionResult Index()
        {
            var opciones = db.Opciones.Include(o => o.Pregunta);
            return View(opciones.ToList());
        }

        // GET: Opciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcione opcione = db.Opciones.Find(id);
            if (opcione == null)
            {
                return HttpNotFound();
            }
            return View(opcione);
        }

        // GET: Opciones/Create
        public ActionResult Create()
        {
            ViewBag.IdPregunta = new SelectList(db.Preguntas, "id", "Descripcion");
            return View();
        }

        // POST: Opciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valor,IdPregunta")] Opcione opcione)
        {
            if (ModelState.IsValid)
            {
                db.Opciones.Add(opcione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPregunta = new SelectList(db.Preguntas, "id", "Descripcion", opcione.IdPregunta);
            return View(opcione);
        }

        // GET: Opciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcione opcione = db.Opciones.Find(id);
            if (opcione == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPregunta = new SelectList(db.Preguntas, "id", "Descripcion", opcione.IdPregunta);
            return View(opcione);
        }

        // POST: Opciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valor,IdPregunta")] Opcione opcione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opcione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPregunta = new SelectList(db.Preguntas, "id", "Descripcion", opcione.IdPregunta);
            return View(opcione);
        }

        // GET: Opciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcione opcione = db.Opciones.Find(id);
            if (opcione == null)
            {
                return HttpNotFound();
            }
            return View(opcione);
        }

        // POST: Opciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opcione opcione = db.Opciones.Find(id);
            db.Opciones.Remove(opcione);
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
