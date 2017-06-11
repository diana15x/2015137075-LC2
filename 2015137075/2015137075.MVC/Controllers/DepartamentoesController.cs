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
    public class DepartamentoesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        //private _2015137075DbContext db = new _2015137075DbContext();
        public DepartamentoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        public DepartamentoesController()
        {

        }

        // GET: Departamentoes
        public ActionResult Index()
        {
            //return View(db.Departamentos.ToList());
            return View(_UnityOfWork.Departamentos.GetAll());
        }

        // GET: Departamentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ///Departamento departamento = db.Departamentos.Find(id);
            Departamento departamento = _UnityOfWork.Departamentos.Get(id);

            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // GET: Departamentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamentoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartamentoId,Nombre")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                //db.Departamentos.Add(departamento);
                _UnityOfWork.Departamentos.Add(departamento);

                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamento);
        }

        // GET: Departamentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Departamento departamento = db.Departamentos.Find(id);

            Departamento departamento = _UnityOfWork.Departamentos.Get(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamentoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartamentoId,Nombre")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(departamento).State = EntityState.Modified;
                _UnityOfWork.StateModified(departamento);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamento);
        }

        // GET: Departamentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Departamento departamento = db.Departamentos.Find(id);
            Departamento departamento = _UnityOfWork.Departamentos.Get(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Departamento departamento = db.Departamentos.Find(id);
            Departamento departamento = _UnityOfWork.Departamentos.Get(id);
            //db.Departamentos.Remove(departamento);
            _UnityOfWork.Departamentos.Delete(departamento);
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
