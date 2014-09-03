﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MusicStoreSite.Models.Contexts;
using MusicStoreSite.Models.Entities;

namespace MusicStoreSite.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        private MusicStoreContext musicStoreContext = new MusicStoreContext();

        public ActionResult AddToDb()
        {
            var tempProduct = new Product { Artist = "Bla", Genre = "Metal", Price = 9.99M, Title = "Badum" };
            musicStoreContext.Products.Add(tempProduct);
            tempProduct = new Product { Artist = "Blaasd", Genre = "Metal", Price = 19.99M, Title = "Basm" };
            musicStoreContext.Products.Add(tempProduct);
            tempProduct = new Product { Artist = "Blasda", Genre = "Metal", Price = 29.99M, Title = "Bagdhdum" };
            musicStoreContext.Products.Add(tempProduct);
            tempProduct = new Product { Artist = "Blasfa", Genre = "Metal", Price = 39.99M, Title = "Badhfdum" };
            musicStoreContext.Products.Add(tempProduct);
            tempProduct = new Product { Artist = "Bla234asd", Genre = "Metal", Price = 19.99M, Title = "B345asm" };
            musicStoreContext.Products.Add(tempProduct);
            tempProduct = new Product { Artist = "Blasdasda", Genre = "Metal", Price = 29.99M, Title = "Bagdh345dum" };
            musicStoreContext.Products.Add(tempProduct);
            tempProduct = new Product { Artist = "Blasfsdfa", Genre = "Metal", Price = 39.99M, Title = "Badhf345dum" };
            musicStoreContext.Products.Add(tempProduct);
            musicStoreContext.SaveChanges();
            return View("Browse");
        }

        public ViewResult Index()
        {
            var newProducts = musicStoreContext.Products.OrderBy(x => x.AddedAt).Take(5).AsEnumerable();
            return View(newProducts);
        }

        public ActionResult ProductDetails(int id = 0)
        {
            Product selectedProduct = musicStoreContext.Products.Where(product => product.ProductId == id).FirstOrDefault();

            return View(selectedProduct);
        }

        public ActionResult Browse(string category = "")
        {
            var browseResults = musicStoreContext.Products.Where(x => x.Genre == category).ToList();

            return View(browseResults);
        }
    }
}
