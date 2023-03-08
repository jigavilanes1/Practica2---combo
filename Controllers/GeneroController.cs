using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica2.Models;
using Practica2.Models.TableViewModels;
using Practica2.Models.ViewModels;

namespace Practica2.Controllers
{
    public class GeneroController : Controller
    {
        // GET: Genero
        public ActionResult Index()
        {
            List<GeneroTableViewModel> lst = null;

            using (db_cineEntities db = new db_cineEntities())
            {
                lst = (from d in db.tbl_genero
                       select new GeneroTableViewModel
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           Detalle = d.detalle
                       }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(GeneroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (db_cineEntities db = new db_cineEntities())
            {
                tbl_genero oGenero = new tbl_genero();

                oGenero.nombre = model.Nombre;
                oGenero.detalle = model.Detalle;

                db.tbl_genero.Add(oGenero);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Genero/"));
        }

        public ActionResult Editar(int id)
        {
            EditarGeneroViewModel model = new EditarGeneroViewModel();

            using (db_cineEntities db = new db_cineEntities())
            {
                var oGenero = db.tbl_genero.Find(id);

                model.Id = oGenero.id;
                model.Nombre = oGenero.nombre;
                model.Detalle = oGenero.detalle;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EditarGeneroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (db_cineEntities db = new db_cineEntities())
            {
                var oGenero = db.tbl_genero.Find(model.Id);
                oGenero.nombre = model.Nombre;
                oGenero.detalle = model.Detalle;
                db.Entry(oGenero).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Genero/"));
        }

        public ActionResult Eliminar(int id)
        {
            using (db_cineEntities db = new db_cineEntities())
            {
                var oGenero = db.tbl_genero.Find(id);

                db.tbl_genero.Remove(oGenero);
                db.SaveChanges();

            }
            return Redirect(Url.Content("~/Genero/"));
        }
    }
}