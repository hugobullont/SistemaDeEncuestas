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
    public class IndicadoresController : Controller
    {
        private EncuestasUPCEntities db = new EncuestasUPCEntities();

        // GET: Indicadores
        public ActionResult Index()
        {
            return View(db.Indicadores.ToList());
        }

        // GET: Indicadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicadore indicadore = db.Indicadores.Find(id);
            if (indicadore == null)
            {
                return HttpNotFound();
            }
            return View(indicadore);
        }

        // GET: Indicadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indicadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,valorIndicador")] Indicadore indicadore)
        {
            if (ModelState.IsValid)
            {
                db.Indicadores.Add(indicadore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(indicadore);
        }

        // GET: Indicadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicadore indicadore = db.Indicadores.Find(id);
            if (indicadore == null)
            {
                return HttpNotFound();
            }
            return View(indicadore);
        }

        // POST: Indicadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,valorIndicador")] Indicadore indicadore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indicadore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(indicadore);
        }

        // GET: Indicadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicadore indicadore = db.Indicadores.Find(id);
            if (indicadore == null)
            {
                return HttpNotFound();
            }
            return View(indicadore);
        }

        // POST: Indicadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Indicadore indicadore = db.Indicadores.Find(id);
            db.Indicadores.Remove(indicadore);
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
