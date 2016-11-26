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
    public class PreguntasXEncuestasController : Controller
    {
        private EncuestasUPCEntities db = new EncuestasUPCEntities();

        // GET: PreguntasXEncuestas
        public ActionResult Index()
        {
            var preguntasXEncuestas = db.PreguntasXEncuestas.Include(p => p.Encuesta).Include(p => p.Pregunta);
            return View(preguntasXEncuestas.ToList());
        }

        // GET: PreguntasXEncuestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreguntasXEncuesta preguntasXEncuesta = db.PreguntasXEncuestas.Find(id);
            if (preguntasXEncuesta == null)
            {
                return HttpNotFound();
            }
            return View(preguntasXEncuesta);
        }

        // GET: PreguntasXEncuestas/Create
        public ActionResult Create()
        {
            ViewBag.EncuestaId = new SelectList(db.Encuestas, "id", "id");
            ViewBag.PreguntasId = new SelectList(db.Preguntas, "id", "Descripcion");
            return View();
        }

        // POST: PreguntasXEncuestas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,EncuestaId,PreguntasId")] PreguntasXEncuesta preguntasXEncuesta)
        {
            if (ModelState.IsValid)
            {
                db.PreguntasXEncuestas.Add(preguntasXEncuesta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EncuestaId = new SelectList(db.Encuestas, "id", "id", preguntasXEncuesta.EncuestaId);
            ViewBag.PreguntasId = new SelectList(db.Preguntas, "id", "Descripcion", preguntasXEncuesta.PreguntasId);
            return View(preguntasXEncuesta);
        }

        // GET: PreguntasXEncuestas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreguntasXEncuesta preguntasXEncuesta = db.PreguntasXEncuestas.Find(id);
            if (preguntasXEncuesta == null)
            {
                return HttpNotFound();
            }
            ViewBag.EncuestaId = new SelectList(db.Encuestas, "id", "id", preguntasXEncuesta.EncuestaId);
            ViewBag.PreguntasId = new SelectList(db.Preguntas, "id", "Descripcion", preguntasXEncuesta.PreguntasId);
            return View(preguntasXEncuesta);
        }

        // POST: PreguntasXEncuestas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,EncuestaId,PreguntasId")] PreguntasXEncuesta preguntasXEncuesta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preguntasXEncuesta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EncuestaId = new SelectList(db.Encuestas, "id", "id", preguntasXEncuesta.EncuestaId);
            ViewBag.PreguntasId = new SelectList(db.Preguntas, "id", "Descripcion", preguntasXEncuesta.PreguntasId);
            return View(preguntasXEncuesta);
        }

        // GET: PreguntasXEncuestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreguntasXEncuesta preguntasXEncuesta = db.PreguntasXEncuestas.Find(id);
            if (preguntasXEncuesta == null)
            {
                return HttpNotFound();
            }
            return View(preguntasXEncuesta);
        }

        // POST: PreguntasXEncuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreguntasXEncuesta preguntasXEncuesta = db.PreguntasXEncuestas.Find(id);
            db.PreguntasXEncuestas.Remove(preguntasXEncuesta);
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
