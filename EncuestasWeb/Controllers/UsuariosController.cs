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
    public class UsuariosController : Controller
    {
        private EncuestasUPCEntities db = new EncuestasUPCEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Grupo);
            return View(usuarios.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Id,codigo,Nombre,GrupoId,ApellidoPaterno,ApellidoMaterno,contraseña")] Usuario usuario)
        {
            Usuario user = GetUserByUsername(usuario.codigo);
            if (user==null)
            {
                return HttpNotFound();
            }
            if (user.contraseña == usuario.contraseña)
            {
                switch(user.Grupo.nombreGrupo)
                {
                    case "Analista":
                        return RedirectToAction("Home/Analista", new { Id = user.Id });
                    case "Administrador":
                        return RedirectToAction("Home/Administrador", new { Id = user.Id });
                    case "Alumno":
                        return RedirectToAction("Home/Alumno", new { Id = user.Id });
                    case "Docente":
                        return RedirectToAction("Home/Docente", new { Id = user.Id });
                    case "Administrativo":
                        return RedirectToAction("Home/Administrativo", new { Id = user.Id });
                }
                          
                
            }
            return HttpNotFound();
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        
        public Usuario GetUserByUsername(string userName)
        {
            Usuario usuario = (from u in db.Usuarios
                               where u.codigo == userName
                               select u).FirstOrDefault();
            return usuario;
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.GrupoId = new SelectList(db.Grupoes, "id", "nombreGrupo");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,codigo,Nombre,GrupoId,ApellidoPaterno,ApellidoMaterno,contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GrupoId = new SelectList(db.Grupoes, "id", "nombreGrupo", usuario.GrupoId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrupoId = new SelectList(db.Grupoes, "id", "nombreGrupo", usuario.GrupoId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,codigo,Nombre,GrupoId,ApellidoPaterno,ApellidoMaterno,contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrupoId = new SelectList(db.Grupoes, "id", "nombreGrupo", usuario.GrupoId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
