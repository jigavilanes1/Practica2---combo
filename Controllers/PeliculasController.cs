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
    public class PeliculasController : Controller
    {
        // GET: Peliculas
        public ActionResult Index()
        {
            List<PeliculasTableViewModel> lst = null;

            using (db_cineEntities db = new db_cineEntities())
            {
                lst = (from p in db.tbl_peliculas
                       join g in db.tbl_genero on p.idgenero equals g.id
                       select new PeliculasTableViewModel
                       {
                           Id = p.id,
                           Titulo = p.titulo,
                           Duracion = (decimal)p.duracion,
                           Genero = g.nombre
                       }).ToList();
            }
            return View(lst);
        }

        public void cargarGboxGeneros()
        {
            List<SelectListItem> lstGeneros = null;

            using (db_cineEntities db = new db_cineEntities())
            {
                lstGeneros = (from g in db.tbl_genero
                              select new SelectListItem
                              {
                                  Value = g.id.ToString(),
                                  Text = g.nombre.ToString()
                              }).ToList();
            }
            ViewBag.lstGeneros = lstGeneros;
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            cargarGboxGeneros();
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(PeliculasViewModel model)
        {
            if (!ModelState.IsValid)
            {
                cargarGboxGeneros();
                return View(model);
            }
            using (db_cineEntities db = new db_cineEntities())
            {
                tbl_peliculas oPeliculas = new tbl_peliculas();

                oPeliculas.titulo = model.Titulo;
                oPeliculas.duracion = model.Duracion;
                oPeliculas.idgenero = model.IdGenero;

                db.tbl_peliculas.Add(oPeliculas);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Peliculas/"));
        }

        public ActionResult Editar(int id)
        {
            cargarGboxGeneros();
            EditarPeliculasViewModel model = new EditarPeliculasViewModel();

            using (db_cineEntities db = new db_cineEntities())
            {
                var oPeliculas = db.tbl_peliculas.Find(id);

                model.Id = oPeliculas.id;
                model.Titulo = oPeliculas.titulo;
                model.Duracion = (decimal)oPeliculas.duracion;
                model.IdGenero = (int)oPeliculas.idgenero;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EditarPeliculasViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (db_cineEntities db = new db_cineEntities())
            {
                var oPeliculas = db.tbl_peliculas.Find(model.Id);
                oPeliculas.titulo = model.Titulo;
                oPeliculas.duracion = model.Duracion;
                oPeliculas.idgenero = model.IdGenero;
                db.Entry(oPeliculas).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Peliculas/"));
        }

        public ActionResult Eliminar(int id)
        {
            using (db_cineEntities db = new db_cineEntities())
            {
                var oPeliculas = db.tbl_peliculas.Find(id);

                db.tbl_peliculas.Remove(oPeliculas);
                db.SaveChanges();

            }
            return Redirect(Url.Content("~/Peliculas/"));
        }
    }
}