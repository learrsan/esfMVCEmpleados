using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Empleados.Models;

namespace Empleados.Controllers
{
    public class CentrosController : Controller
    {
        EmpleadosEntities db = new EmpleadosEntities();
        // GET: Centros
        public ActionResult Index()
        {

            return View(db.Centros);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();

        }

    }

}