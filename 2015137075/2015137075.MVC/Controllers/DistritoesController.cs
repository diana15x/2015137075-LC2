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
    public class DistritoesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        //private _2015137075DbContext db = new _2015137075DbContext();

        public DistritoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        public DistritoesController()
        {

        }

        // GET: Distritoes
        public ActionResult Index()
        {
            //var distritos = db.Distritos.Include(d => d.Provincia);
            // return View(distritos.ToList());
            return View(_UnityOfWork.Distritos.GetAll());
        }

        // GET: Distritoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Distrito distrito = db.Distritos.Find(id);
            Distrito distrito = _UnityOfWork.Distritos.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // GET: Distritoes/Create
        public ActionResult Create()
        {
            //ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "Nombre");
            return View();
        }

        // POST: Distritoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistritoId,Nombre,ProvinciaId")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                //db.Distritos.Add(distrito);
                _UnityOfWork.Distritos.Add(distrito);

                //db.SaveChanges();

                return RedirectToAction("Index");
            }

            //ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "Nombre", distrito.ProvinciaId);
            return View(distrito);
        }

        // GET: Distritoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Distrito distrito = db.Distritos.Find(id);
            Distrito distrito = _UnityOfWork.Distritos.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
           // ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "Nombre", distrito.ProvinciaId);
            return View(distrito);
        }

        // POST: Distritoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistritoId,Nombre,ProvinciaId")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(distrito).State = EntityState.Modified;
                _UnityOfWork.StateModified(distrito);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "Nombre", distrito.ProvinciaId);
            return View(distrito);
        }

        // GET: Distritoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Distrito distrito = db.Distritos.Find(id);
            Distrito distrito = _UnityOfWork.Distritos.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: Distritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Distrito distrito = db.Distritos.Find(id);
            Distrito distrito = _UnityOfWork.Distritos.Get(id);
            // db.Distritos.Remove(distrito);
            _UnityOfWork.Distritos.Delete(distrito);

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
