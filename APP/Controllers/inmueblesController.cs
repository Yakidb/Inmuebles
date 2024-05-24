using APP.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP.Controllers
{
    public class inmueblesController : Controller
    {
        private InmueblesDbContext context_Z = new InmueblesDbContext();

        public ActionResult Index()
        {
            return View(context_Z.Inmuebles.ToList());
        }

        public ActionResult Details(int id)
        {
            var inmueble = context_Z.Inmuebles.Find(id);
            if (inmueble == null)
            {
                return HttpNotFound();
            }
            return View(inmueble);
        }
    }
}