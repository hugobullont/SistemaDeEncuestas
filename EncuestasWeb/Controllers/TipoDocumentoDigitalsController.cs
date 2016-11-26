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
    public class TipoDocumentoDigitalsController : Controller
    {
        private EncuestasUPCEntities db = new EncuestasUPCEntities();

        // GET: TipoDocumentoDigitals
        public ActionResult Index()
        {
            return View(db.TipoDocumentoDigitals.ToList());
        }

        // GET: TipoDocumentoDigitals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumentoDigital tipoDocumentoDigital = db.TipoDocumentoDigitals.Find(id);
            if (tipoDocumentoDigital == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumentoDigital);
        }

        // GET: TipoDocumentoDigitals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumentoDigitals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NombreTipoDoc")] TipoDocumentoDigital tipoDocumentoDigital)
        {
            if (ModelState.IsValid)
            {
                db.TipoDocumentoDigitals.Add(tipoDocumentoDigital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDocumentoDigital);
        }

        // GET: TipoDocumentoDigitals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumentoDigital tipoDocumentoDigital = db.TipoDocumentoDigitals.Find(id);
            if (tipoDocumentoDigital == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumentoDigital);
        }

        // POST: TipoDocumentoDigitals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NombreTipoDoc")] TipoDocumentoDigital tipoDocumentoDigital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDocumentoDigital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDocumentoDigital);
        }

        // GET: TipoDocumentoDigitals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumentoDigital tipoDocumentoDigital = db.TipoDocumentoDigitals.Find(id);
            if (tipoDocumentoDigital == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumentoDigital);
        }

        // POST: TipoDocumentoDigitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDocumentoDigital tipoDocumentoDigital = db.TipoDocumentoDigitals.Find(id);
            db.TipoDocumentoDigitals.Remove(tipoDocumentoDigital);
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
