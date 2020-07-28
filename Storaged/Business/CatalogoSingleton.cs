using Storaged.Controllers;
using Storaged.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storaged.Business
{
    public class CatalogoSingleton
    {
        private static CatalogoSingleton instance = null;
        public List<Models.Producto> productos;



        public CatalogoSingleton()
        {
            using (Models.patronEntities db = new Models.patronEntities())
            {
                productos = (from d in db.Producto select d).ToList();
            }
        }

        public static CatalogoSingleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new CatalogoSingleton();
                return instance;
            }
        }
    }
}