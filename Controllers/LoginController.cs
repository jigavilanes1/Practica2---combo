using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica2.Models;
using Practica2.Models.ViewModels;

namespace Practica2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new db_cineEntities())
            {
                var list = from u in db.tbl_usuarios
                           where u.usuario == model.usuario &&
                           u.clave == model.clave &&
                           u.estado == 1
                           select u;

                if (list.Count() > 0)
                {
                    Session["Usuario"] = list.First();
                }
            }
            return Redirect(Url.Content("~/Home/"));
        }

    }
}