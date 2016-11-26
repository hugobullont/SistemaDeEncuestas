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
    public class DocumentosDigitalesController : Controller
    {
        private EncuestasUPCEntities db = new EncuestasUPCEntities();

        // GET: DocumentosDigitales
        public ActionResult Index()
        {
            var documentosDigitales = db.DocumentosDigitales.Include(d => d.TipoDocumentoDigital);
            return View(documentosDigitales.ToList());
        }

        // GET: DocumentosDigitales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentosDigitale documentosDigitale = db.DocumentosDigitales.Find(id);
            if (documentosDigitale == null)
            {
                return HttpNotFound();
            }
            return View(documentosDigitale);
        }

        // GET: DocumentosDigitales/Create
        public ActionResult Create()
        {
            ViewBag.TipoId = new SelectList(db.TipoDocumentoDigitals, "id", "NombreTipoDoc");
            return View();
        }

        // POST: DocumentosDigitales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TipoId,Descripcion")] DocumentosDigitale documentosDigitale)
        {
            if (ModelState.IsValid)
            {
                db.DocumentosDigitales.Add(documentosDigitale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoId = new SelectList(db.TipoDocumentoDigitals, "id", "NombreTipoDoc", documentosDigitale.TipoId);
            return View(documentosDigitale);
        }

        // GET: DocumentosDigitales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentosDigitale documentosDigitale = db.DocumentosDigitales.Find(id);
            if (documentosDigitale == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoId = new SelectList(db.TipoDocumentoDigitals, "id", "NombreTipoDoc", documentosDigitale.TipoId);
            return View(documentosDigitale);
        }

        // POST: DocumentosDigitales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TipoId,Descripcion")] DocumentosDigitale documentosDigitale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentosDigitale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoId = new SelectList(db.TipoDocumentoDigitals, "id", "NombreTipoDoc", documentosDigitale.TipoId);
            return View(documentosDigitale);
        }

        // GET: DocumentosDigitales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentosDigitale documentosDigitale = db.DocumentosDigitales.Find(id);
            if (documentosDigitale == null)
            {
                return HttpNotFound();
            }
            return View(documentosDigitale);
        }

        // POST: DocumentosDigitales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentosDigitale documentosDigitale = db.DocumentosDigitales.Find(id);
            db.DocumentosDigitales.Remove(documentosDigitale);
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
