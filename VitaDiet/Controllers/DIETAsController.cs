using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VitaDiet.Models;

namespace VitaDiet.Controllers
{
    public class DIETAsController : Controller
    {
        private VITADIETEntities db = new VITADIETEntities();

        // GET: DIETAs
        public ActionResult Index()
        {
            return View(db.DIETA.ToList());
        }

        // GET: DIETAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIETA dIETA = db.DIETA.Find(id);
            if (dIETA == null)
            {
                return HttpNotFound();
            }
            return View(dIETA);
        }

        // GET: DIETAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DIETAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,CEDULA_PACIENTE,COMIDA,DOMICILIO")] DIETA dIETA)
        {
            if (ModelState.IsValid)
            {
                db.DIETA.Add(dIETA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dIETA);
        }

        // GET: DIETAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIETA dIETA = db.DIETA.Find(id);
            if (dIETA == null)
            {
                return HttpNotFound();
            }
            return View(dIETA);
        }

        // POST: DIETAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,CEDULA_PACIENTE,COMIDA,DOMICILIO")] DIETA dIETA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIETA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dIETA);
        }

        // GET: DIETAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIETA dIETA = db.DIETA.Find(id);
            if (dIETA == null)
            {
                return HttpNotFound();
            }
            return View(dIETA);
        }

        // POST: DIETAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DIETA dIETA = db.DIETA.Find(id);
            db.DIETA.Remove(dIETA);
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
