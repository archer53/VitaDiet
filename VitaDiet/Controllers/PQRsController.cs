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
    public class PQRsController : Controller
    {
        private VITADIETEntities db = new VITADIETEntities();

        // GET: PQRs
        public ActionResult Index()
        {
            return View(db.PQR.ToList());
        }

        // GET: PQRs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PQR pQR = db.PQR.Find(id);
            if (pQR == null)
            {
                return HttpNotFound();
            }
            return View(pQR);
        }

        // GET: PQRs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PQRs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE_PACIENTE,CALIFICACION")] PQR pQR)
        {
            if (ModelState.IsValid)
            {
                db.PQR.Add(pQR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pQR);
        }

        // GET: PQRs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PQR pQR = db.PQR.Find(id);
            if (pQR == null)
            {
                return HttpNotFound();
            }
            return View(pQR);
        }

        // POST: PQRs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE_PACIENTE,CALIFICACION")] PQR pQR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pQR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pQR);
        }

        // GET: PQRs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PQR pQR = db.PQR.Find(id);
            if (pQR == null)
            {
                return HttpNotFound();
            }
            return View(pQR);
        }

        // POST: PQRs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PQR pQR = db.PQR.Find(id);
            db.PQR.Remove(pQR);
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
