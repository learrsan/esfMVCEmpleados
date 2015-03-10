using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Empleados.Models;

namespace Empleados.Controllers
{
    public class HomeController : Controller
    {
        private EmpleadosEntities db = new EmpleadosEntities();
         
        


        // GET: Home
        public ActionResult Index()
        {
            var db = new EmpleadosEntities();
            {

                return View(db.Empleados.ToList());
            }

        }

        
        
        public ActionResult Alta()
        {
            ViewBag.idcargos = new SelectList(db.Cargos, "id", "nombre");
            ViewBag.idcentros = new SelectList(db.Centros, "id", "nombre");

            return View(new Models.Empleados());
        }
        

        //public ActionResult Alta(Models.Empleados model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new EmpleadosEntities())
        //        {
        //            db.Empleados.Add(model);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return View(model);
        //}
        [HttpPost]
        public ActionResult Alta(Empleados.Models.Empleados model)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(model);
                foreach (var idcentros in model.Idcentro)
                {
                    var c = db.Centros.Find(idcentros);
                    model.Centros.Add(c);
                }
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Buscar()
        {
            var bus = Request.Form["busqueda"];
            var db = new EmpleadosEntities();
            var al = db.Empleados.Where(o => o.apellidos.Contains(bus));

            return View(al);

        }
    }
}