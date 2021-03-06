﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreSite.Models.Entities;
using MusicStoreSite.Models.Contexts;
using MusicStoreSite.Infrastructure;

namespace MusicStoreSite.Areas.Panel.Controllers
{
    [AdminAuthorizationAttribute(Users = "admin")]
    public class GenresController : Controller
    {
        private MusicStoreContext db = new MusicStoreContext();

        //
        // GET: /Panel/Genres/

        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }

        //
        // GET: /Panel/Genres/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Panel/Genres/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        //
        // GET: /Panel/Genres/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // POST: /Panel/Genres/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        //
        // GET: /Panel/Genres/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // POST: /Panel/Genres/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Genre genre = db.Genres.Find(id);
                db.Genres.Remove(genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}