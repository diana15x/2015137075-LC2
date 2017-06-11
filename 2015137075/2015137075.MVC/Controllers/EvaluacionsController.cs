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
    public class EvaluacionsController : Controller
    {
        private _2015137075DbContext db = new _2015137075DbContext();

        // GET: Evaluacions
        public ActionResult Index()
        {
            var evaluaciones = db.Evaluaciones.Include(e => e.Cliente).Include(e => e.LineaTelefonica).Include(e => e.Plan).Include(e => e.Trabajador);
            return View(evaluaciones.ToList());
        }

        // GET: Evaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluaciones.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: Evaluacions/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre");
            ViewBag.LineaTelefonicaId = new SelectList(db.LineasTelefonica, "LineaTelefonicaId", "Nombre");
            ViewBag.PlanId = new SelectList(db.Planes, "PlanId", "Nombre");
            ViewBag.TrabajadorId = new SelectList(db.Trabajadores, "TrabajadorId", "Nombre");
            return View();
        }

        // POST: Evaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EvaluacionId,Nombre,LineaTelefonicaId,PlanId,TrabajadorId,ClienteId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Evaluaciones.Add(evaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", evaluacion.ClienteId);
            ViewBag.LineaTelefonicaId = new SelectList(db.LineasTelefonica, "LineaTelefonicaId", "Nombre", evaluacion.LineaTelefonicaId);
            ViewBag.PlanId = new SelectList(db.Planes, "PlanId", "Nombre", evaluacion.PlanId);
            ViewBag.TrabajadorId = new SelectList(db.Trabajadores, "TrabajadorId", "Nombre", evaluacion.TrabajadorId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluaciones.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", evaluacion.ClienteId);
            ViewBag.LineaTelefonicaId = new SelectList(db.LineasTelefonica, "LineaTelefonicaId", "Nombre", evaluacion.LineaTelefonicaId);
            ViewBag.PlanId = new SelectList(db.Planes, "PlanId", "Nombre", evaluacion.PlanId);
            ViewBag.TrabajadorId = new SelectList(db.Trabajadores, "TrabajadorId", "Nombre", evaluacion.TrabajadorId);
            return View(evaluacion);
        }

        // POST: Evaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvaluacionId,Nombre,LineaTelefonicaId,PlanId,TrabajadorId,ClienteId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", evaluacion.ClienteId);
            ViewBag.LineaTelefonicaId = new SelectList(db.LineasTelefonica, "LineaTelefonicaId", "Nombre", evaluacion.LineaTelefonicaId);
            ViewBag.PlanId = new SelectList(db.Planes, "PlanId", "Nombre", evaluacion.PlanId);
            ViewBag.TrabajadorId = new SelectList(db.Trabajadores, "TrabajadorId", "Nombre", evaluacion.TrabajadorId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluaciones.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluacion evaluacion = db.Evaluaciones.Find(id);
            db.Evaluaciones.Remove(evaluacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                unityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
