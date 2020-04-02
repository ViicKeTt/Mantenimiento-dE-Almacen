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
    public class Tipos_de_ClientesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Tipos_de_Clientes
        public ActionResult Index()
        {
            return View(db.Tipos_de_Clientes.ToList());
        }

        // GET: Tipos_de_Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_de_Clientes tipos_de_Clientes = db.Tipos_de_Clientes.Find(id);
            if (tipos_de_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(tipos_de_Clientes);
        }

        // GET: Tipos_de_Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipos_de_Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] Tipos_de_Clientes tipos_de_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Tipos_de_Clientes.Add(tipos_de_Clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipos_de_Clientes);
        }

        // GET: Tipos_de_Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_de_Clientes tipos_de_Clientes = db.Tipos_de_Clientes.Find(id);
            if (tipos_de_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(tipos_de_Clientes);
        }

        // POST: Tipos_de_Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Tipos_de_Clientes tipos_de_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipos_de_Clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipos_de_Clientes);
        }

        // GET: Tipos_de_Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_de_Clientes tipos_de_Clientes = db.Tipos_de_Clientes.Find(id);
            if (tipos_de_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(tipos_de_Clientes);
        }

        // POST: Tipos_de_Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipos_de_Clientes tipos_de_Clientes = db.Tipos_de_Clientes.Find(id);
            db.Tipos_de_Clientes.Remove(tipos_de_Clientes);
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
