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
    public class EncuestasController : Controller
    {
        private EncuestasUPCEntities db = new EncuestasUPCEntities();

        // GET: Encuestas
        public ActionResult Index()
        {
            var encuestas = db.Encuestas.Include(e => e.DocumentosDigitale).Include(e => e.Grupo).Include(e => e.Indicadore).Include(e => e.Subtipo);
            return View(encuestas.ToList());
        }

        // GET: Encuestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encuesta encuesta = db.Encuestas.Find(id);
            if (encuesta == null)
            {
                return HttpNotFound();
            }
            return View(encuesta);
        }

        // GET: Encuestas/Create
        public ActionResult Create()
        {
            ViewBag.DocumentosDigId = new SelectList(db.DocumentosDigitales, "id", "Descripcion");
            ViewBag.GrupoId = new SelectList(db.Grupoes, "id", "nombreGrupo");
            ViewBag.IndicadorId = new SelectList(db.Indicadores, "id", "valorIndicador");
            ViewBag.SubtipoId = new SelectList(db.Subtipoes, "id", "NombreSubtipo");
            return View();
        }

        // POST: Encuestas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,GrupoId,IndicadorId,DocumentosDigId,SubtipoId")] Encuesta encuesta)
        {
            if (ModelState.IsValid)
            {
                db.Encuestas.Add(encuesta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocumentosDigId = new SelectList(db.DocumentosDigitales, "id", "Descripcion", encuesta.DocumentosDigId);
            ViewBag.GrupoId = new SelectList(db.Grupoes, "id", "nombreGrupo", encuesta.GrupoId);
            ViewBag.IndicadorId = new SelectList(db.Indicadores, "id", "valorIndicador", encuesta.IndicadorId);
            ViewBag.SubtipoId = new SelectList(db.Subtipoes, "id", "NombreSubtipo", encuesta.SubtipoId);
            return View(encuesta);
        }

        // GET: Encuestas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encuesta encuesta = db.Encuestas.Find(id);
            if (encuesta == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentosDigId = new SelectList(db.DocumentosDigitales, "id", "Descripcion", encuesta.DocumentosDigId);
            ViewBag.GrupoId = new SelectList(db.Grupoes, "id", "nombreGrupo", encuesta.GrupoId);
            ViewBag.IndicadorId = new SelectList(db.Indicadores, "id", "valorIndicador", encuesta.IndicadorId);
            ViewBag.SubtipoId = new SelectList(db.Subtipoes, "id", "NombreSubtipo", encuesta.SubtipoId);
            return View(encuesta);
        }

        // POST: Encuestas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,GrupoId,IndicadorId,DocumentosDigId,SubtipoId")] Encuesta encuesta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encuesta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocumentosDigId = new SelectList(db.DocumentosDigitales, "id", "Descripcion", encuesta.DocumentosDigId);
            ViewBag.GrupoId = new SelectList(db.Grupoes, "id", "nombreGrupo", encuesta.GrupoId);
            ViewBag.IndicadorId = new SelectList(db.Indicadores, "id", "valorIndicador", encuesta.IndicadorId);
            ViewBag.SubtipoId = new SelectList(db.Subtipoes, "id", "NombreSubtipo", encuesta.SubtipoId);
            return View(encuesta);
        }

        // GET: Encuestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encuesta encuesta = db.Encuestas.Find(id);
            if (encuesta == null)
            {
                return HttpNotFound();
            }
            return View(encuesta);
        }

        // POST: Encuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encuesta encuesta = db.Encuestas.Find(id);
            db.Encuestas.Remove(encuesta);
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
