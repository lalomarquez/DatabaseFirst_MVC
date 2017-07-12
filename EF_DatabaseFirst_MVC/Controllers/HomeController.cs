using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EF_DatabaseFirst_MVC.Models;

namespace EF_DatabaseFirst_MVC.Controllers
{
    public class HomeController : Controller
    {
        private connDatabaseFirstEF db = new connDatabaseFirstEF();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.TBL_Usuarios.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Usuarios tBL_Usuarios = db.TBL_Usuarios.Find(id);
            if (tBL_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Usuarios);
        }
        
        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Usuario,Contrasena,Correo,Genero,Activo")] TBL_Usuarios tBL_Usuarios)
        {
            if (ModelState.IsValid)
            {
                //Convert.ToInt16(tBL_Usuarios.Activo);
                db.TBL_Usuarios.Add(tBL_Usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_Usuarios);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Usuarios tBL_Usuarios = db.TBL_Usuarios.Find(id);
            if (tBL_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Usuarios);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Usuario,Contrasena,Correo,Genero,Activo")] TBL_Usuarios tBL_Usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_Usuarios);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Usuarios tBL_Usuarios = db.TBL_Usuarios.Find(id);
            if (tBL_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Usuarios);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Usuarios tBL_Usuarios = db.TBL_Usuarios.Find(id);
            db.TBL_Usuarios.Remove(tBL_Usuarios);
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
