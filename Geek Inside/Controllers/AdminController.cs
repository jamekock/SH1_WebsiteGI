using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Geek_Inside.Models;


namespace Geek_Inside.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var data = new AdminModel().Consulta();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AdminModel model)
        {
            new AdminModel().Insertar(model);
            return RedirectToAction("", "");
        }

        public ActionResult Delete(int id)
        {
            new AdminModel().Eliminar(id);
            return RedirectToAction("","");
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            var data = new AdminModel().Consulta(id);
            return View(data);
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(AdminModel model)
        {
            new AdminModel().Actualizar(model);
            return RedirectToAction("", "");
        }
    }
}