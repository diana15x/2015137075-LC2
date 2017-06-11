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
    public class ContratoesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        //private _2015137075DbContext db = new _2015137075DbContext();
        public ContratoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        public ContratoesController()
        {

        }

        // GET: Contratoes
        public ActionResult Index()
        {
            //return View(db.Contratos.ToList());
            return View(_UnityOfWork.Contratos.GetAll());
        }

        // GET: Contratoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Contrato contrato = db.Contratos.Find(id);
            Contrato contrato = _UnityOfWork.Contratos.Get(id);

            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contratoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contratoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContratoId,Nombre")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                //db.Contratos.Add(contrato);
                _UnityOfWork.Contratos.Add(contrato);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Contrato contrato = db.Contratos.Find(id);
            Contrato contrato = _UnityOfWork.Contratos.Get(id);

            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContratoId,Nombre")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(contrato).State = EntityState.Modified;
                _UnityOfWork.StateModified(contrato);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Contrato contrato = db.Contratos.Find(id);
            Contrato contrato = _UnityOfWork.Contratos.Get(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Contrato contrato = db.Contratos.Find(id);
            Contrato contrato = _UnityOfWork.Contratos.Get(id);
            //db.Contratos.Remove(contrato);
            _UnityOfWork.Contratos.Delete(contrato);
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
