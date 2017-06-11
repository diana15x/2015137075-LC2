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
using _2015137075.ENT.IRepositories;

namespace _2015137075.MVC.Controllers
{
    public class DireccionsController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        //private _2015137075DbContext db = new _2015137075DbContext();

        public DireccionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        public DireccionsController()
        {

        }

        // GET: Direccions
        public ActionResult Index()
        {
            //var direcciones = db.Direcciones.Include(d => d.Distrito);
            //return View(direcciones.ToList());
            return View(_UnityOfWork.Direccions.GetAll());
        }

        // GET: Direccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Direccion direccion = db.Direcciones.Find(id);
            Direccion direccion = _UnityOfWork.Direccions.Get(id);


            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direccions/Create
        public ActionResult Create()
        {
            //ViewBag.DistritoId = new SelectList(db.Distritos, "DistritoId", "Nombre");
            return View();
        }

        // POST: Direccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DireccionId,Descripcion,DistritoId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                //db.Direcciones.Add(direccion);
                _UnityOfWork.Direccions.Add(direccion);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.DistritoId = new SelectList(db.Distritos, "DistritoId", "Nombre", direccion.DistritoId);
            return View(direccion);
        }

        // GET: Direccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Direccion direccion = db.Direcciones.Find(id);
            Direccion direccion = _UnityOfWork.Direccions.Get(id);

            if (direccion == null)
            {
                return HttpNotFound();
            }
            //ViewBag.DistritoId = new SelectList(db.Distritos, "DistritoId", "Nombre", direccion.DistritoId);
            return View(direccion);
        }

        // POST: Direccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DireccionId,Descripcion,DistritoId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(direccion).State = EntityState.Modified;
                _UnityOfWork.StateModified(direccion);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.DistritoId = new SelectList(db.Distritos, "DistritoId", "Nombre", direccion.DistritoId);
            return View(direccion);
        }

        // GET: Direccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Direccion direccion = db.Direcciones.Find(id);

            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Direccion direccion = db.Direcciones.Find(id);
            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            //db.Direcciones.Remove(direccion);
            _UnityOfWork.Direccions.Delete(direccion);
            


            //db.SaveChanges();
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
