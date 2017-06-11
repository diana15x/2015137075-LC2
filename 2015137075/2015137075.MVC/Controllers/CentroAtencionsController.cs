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
using _2015137075.PER.Repositories;

namespace _2015137075.MVC.Controllers
{
    public class CentroAtencionsController : Controller
    {
        //private _2015137075DbContext db = new _2015137075DbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;
        // GET: CentroAtencions
        public ActionResult Index()
        {
            //var centroAtencions = db.CentroAtencions.Include(c => c.Direccion);
            //return View(centroAtencions.ToList());
            return View(unityOfWork.CentroAtencions.GetAll());
        }

        // GET: CentroAtencions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CentroAtencion centroAtencion = db.CentroAtencions.Find(id);
            CentroAtencion centroAtencion = unityOfWork.CentroAtencions.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Create
        public ActionResult Create()
        {
            //ViewBag.DireccionId = new SelectList(db.Direcciones, "DireccionId", "Descripcion");
            return View();
        }

        // POST: CentroAtencions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CentroAtencionId,Nombre,DireccionId")] CentroAtencion centroAtencion)
        {
            if (ModelState.IsValid)
            {
                //db.CentroAtencions.Add(centroAtencion);
                unityOfWork.CentroAtencions.Add(centroAtencion);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.DireccionId = new SelectList(db.Direcciones, "DireccionId", "Descripcion", centroAtencion.DireccionId);
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CentroAtencion centroAtencion = db.CentroAtencions.Find(id);
            CentroAtencion centroAtencion = unityOfWork.CentroAtencions.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
            //ViewBag.DireccionId = new SelectList(db.Direcciones, "DireccionId", "Descripcion", centroAtencion.DireccionId);
            return View(centroAtencion);
        }

        // POST: CentroAtencions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CentroAtencionId,Nombre,DireccionId")] CentroAtencion centroAtencion)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(centroAtencion).State = EntityState.Modified;
                unityOfWork.StateModified(centroAtencion);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.DireccionId = new SelectList(db.Direcciones, "DireccionId", "Descripcion", centroAtencion.DireccionId);
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CentroAtencion centroAtencion = db.CentroAtencions.Find(id);
            CentroAtencion centroAtencion = unityOfWork.CentroAtencions.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
            return View(centroAtencion);
        }

        // POST: CentroAtencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CentroAtencion centroAtencion = unityOfWork.CentroAtencions.Get(id);
            //db.CentroAtencions.Remove(centroAtencion);
            unityOfWork.CentroAtencions.Delete(centroAtencion);
            //db.SaveChanges();
            unityOfWork.SaveChanges();

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
