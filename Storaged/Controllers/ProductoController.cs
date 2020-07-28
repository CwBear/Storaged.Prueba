using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storaged.Models;
using Storaged.Models.ViewModels;

namespace Storaged.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ListProductoViewModel> lst;
            using (patronEntities db = new patronEntities())
            {
                lst = (from d in db.Producto
                           select new ListProductoViewModel
                           {
                               Id = d.id,
                               Nombre = d.nombre,
                               Cantidad = d.cantidad,
                               Precio = d.precio
                           }).ToList();
            }
                return View(lst);
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(ProductoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(patronEntities db = new patronEntities())
                    {
                        var oProducto = new Producto();
                        oProducto.id = ContadorRegistros();
                        oProducto.nombre = model.Nombre;
                        oProducto.cantidad = model.Cantidad;
                        oProducto.precio = model.Precio;

                        db.Producto.Add(oProducto);
                        db.SaveChanges();
                    }
                    return Redirect("~/Producto/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            ProductoViewModel model = new ProductoViewModel();
            using(patronEntities db = new patronEntities())
            {
                var oProducto = db.Producto.Find(Id);
                model.Nombre = oProducto.nombre;
                model.Cantidad = oProducto.cantidad;
                model.Precio = oProducto.precio;
                model.Id = oProducto.id;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Editar(ProductoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (patronEntities db = new patronEntities())
                    {
                        var oProducto = db.Producto.Find(model.Id);
                        oProducto.nombre = model.Nombre;
                        oProducto.cantidad = model.Cantidad;
                        oProducto.precio = model.Precio;

                        db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Producto/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Eliminar(int Id)
        {

            using (patronEntities db = new patronEntities())
            {
                var oProducto = db.Producto.Find(Id);
                db.Producto.Remove(oProducto);
                db.SaveChanges();
            }
            return Redirect("~/Producto/");
        }
        private int ContadorRegistros()
        {
            using (patronEntities bd = new patronEntities())
            {
                int LastRecord = (from c in bd.Producto orderby c.id descending select c.id).Count();
                return LastRecord;
            }
        }
    }
}