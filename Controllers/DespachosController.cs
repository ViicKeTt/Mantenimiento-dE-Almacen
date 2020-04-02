using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Final.Models;

namespace Proyecto_Final.Controllers
{
    public class DespachosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Despachos
        public ActionResult Index()
        {
            return View(db.Despachos.ToList());
        }

        // GET: Despachos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despachos despachos = db.Despachos.Find(id);
            if (despachos == null)
            {
                return HttpNotFound();
            }
            return View(despachos);
        }

        // GET: Despachos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Despachos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Tipo_de_accion,Cliente,contacto,Detalle_de_productos")] Despachos despachos)
        {
            if (ModelState.IsValid)
            {
                db.Despachos.Add(despachos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(despachos);
        }

        // GET: Despachos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despachos despachos = db.Despachos.Find(id);
            if (despachos == null)
            {
                return HttpNotFound();
            }
            return View(despachos);
        }

        // POST: Despachos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Tipo_de_accion,Cliente,contacto,Detalle_de_productos")] Despachos despachos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(despachos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(despachos);
        }

        // GET: Despachos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despachos despachos = db.Despachos.Find(id);
            if (despachos == null)
            {
                return HttpNotFound();
            }
            return View(despachos);
        }

        // POST: Despachos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Despachos despachos = db.Despachos.Find(id);
            db.Despachos.Remove(despachos);
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
