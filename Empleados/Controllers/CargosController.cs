using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Empleados.Models;

namespace Empleados.Controllers
{
    public class CargosController : Controller
    {
        EmpleadosEntities db = new EmpleadosEntities();
        // GET: Cursos
        public ActionResult Index()
        {

            return View(db.Cargos);
        }


        public ActionResult Alta()
        {
            return View(new Cargos());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Alta(Cargos model)
        {
            if (ModelState.IsValid)
            {
                db.Cargos.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Borrar(int id)
        {
            var model = db.Cargos.Find(id);

            try
            {
                db.Cargos.Remove(model);
                db.SaveChanges();
            }

            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int id)
        {
            var cursos = db.Cargos.Find(id);
            return View();
        }

        [HttpPost]
        public ActionResult Modificar(Cargos model)
        {
            if (ModelState.IsValid)
            {
                var m = db.Cargos.Find(model.id);
                m.nombre = model.nombre;
               

                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();

        }

    }

}