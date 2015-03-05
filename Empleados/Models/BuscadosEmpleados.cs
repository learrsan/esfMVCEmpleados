using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;

namespace Empleados.Models
{
    public class BuscadorEmpleados
    {

        EmpleadosEntities db = new EmpleadosEntities();

        public List<Empleados> GetPorApellidos(String apellidos)
        {
            var datos = from o in db.Empleados
                        where o.apellidos == apellidos
                        select o;

            return datos.ToList();
        }


        public List<Empleados> GetPorApellidosLambda(String apellidos)
        {

            var datos = db.Empleados.Where(o => o.apellidos == apellidos && o.nombre == "Luis");
            return datos.ToList();
        }
    }
}