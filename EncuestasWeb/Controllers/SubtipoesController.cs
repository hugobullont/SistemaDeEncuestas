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
    public class SubtipoesController : Controller
    {
        private EncuestasUPCEntities db = new EncuestasUPCEntities();

        // GET: Subtipoes
        public ActionResult Index()
        {
            var subtipoes = db.Subtipoes.Include(s => s.Tipos);
            return View(subtipoes.ToList());
        }

        // GET: Subtipoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subtipo subtipo = db.Subtipoes.Find(id);
            if (subtipo == null)
            {
                return HttpNotFound();
            }
            return View(subtipo);
        }

        // GET: Subtipoes/Create
        public ActionResult Create()
        {
            ViewBag.TipoId = new SelectList(db.Tipos, "id", "NombreTipo");
            return View();
        }

        // POST: Subtipoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NombreSubtipo,TipoId")] Subtipo subtipo)
        {
            if (ModelState.IsValid)
            {
                db.Subtipoes.Add(subtipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoId = new SelectList(db.Tipos, "id", "NombreTipo", subtipo.TipoId);
            return View(subtipo);
        }

        // GET: Subtipoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subtipo subtipo = db.Subtipoes.Find(id);
            if (subtipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoId = new SelectList(db.Tipos, "id", "NombreTipo", subtipo.TipoId);
            return View(subtipo);
        }

        // POST: Subtipoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NombreSubtipo,TipoId")] Subtipo subtipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subtipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoId = new SelectList(db.Tipos, "id", "NombreTipo", subtipo.TipoId);
            return View(subtipo);
        }

        // GET: Subtipoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subtipo subtipo = db.Subtipoes.Find(id);
            if (subtipo == null)
            {
                return HttpNotFound();
            }
            return View(subtipo);
        }

        // POST: Subtipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subtipo subtipo = db.Subtipoes.Find(id);
            db.Subtipoes.Remove(subtipo);
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
