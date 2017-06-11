using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2015137075.ENT;
using _2015137075.PER;

namespace _2015137075.MVC.Controllers
{
    public class LineaTelefonicasController : Controller
    {
        private _2015137075DbContext db = new _2015137075DbContext();

        // GET: LineaTelefonicas
        public ActionResult Index()
        {
            return View(db.LineasTelefonica.ToList());
        }

        // GET: LineaTelefonicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica lineaTelefonica = db.LineasTelefonica.Find(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LineaTelefonicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LineaTelefonicaId,Nombre")] LineaTelefonica lineaTelefonica)
        {
            if (ModelState.IsValid)
            {
                db.LineasTelefonica.Add(lineaTelefonica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica lineaTelefonica = db.LineasTelefonica.Find(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineaTelefonica);
        }

        // POST: LineaTelefonicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LineaTelefonicaId,Nombre")] LineaTelefonica lineaTelefonica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineaTelefonica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica lineaTelefonica = db.LineasTelefonica.Find(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineaTelefonica);
        }

        // POST: LineaTelefonicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LineaTelefonica lineaTelefonica = db.LineasTelefonica.Find(id);
            db.LineasTelefonica.Remove(lineaTelefonica);
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
