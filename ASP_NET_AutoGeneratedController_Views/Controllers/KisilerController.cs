﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_NET_AutoGeneratedController_Views;

namespace ASP_NET_AutoGeneratedController_Views.Controllers
{
    public class KisilerController : Controller
    {
        private TDBEF_CodefirstEntities db = new TDBEF_CodefirstEntities();

        // GET: Kisiler
        public ActionResult Index()
        {
            return View(db.Kisiler.ToList());
        }

        // GET: Kisiler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kisiler kisiler = db.Kisiler.Find(id);
            if (kisiler == null)
            {
                return HttpNotFound();
            }
            return View(kisiler);
        }

        // GET: Kisiler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kisiler/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ad,Soyad,Yas,Mail")] Kisiler kisiler)
        {
            if (ModelState.IsValid)
            {
                db.Kisiler.Add(kisiler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kisiler);
        }

        // GET: Kisiler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kisiler kisiler = db.Kisiler.Find(id);
            if (kisiler == null)
            {
                return HttpNotFound();
            }
            return View(kisiler);
        }

        // POST: Kisiler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ad,Soyad,Yas,Mail")] Kisiler kisiler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kisiler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kisiler);
        }

        // GET: Kisiler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kisiler kisiler = db.Kisiler.Find(id);
            if (kisiler == null)
            {
                return HttpNotFound();
            }
            return View(kisiler);
        }

        // POST: Kisiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kisiler kisiler = db.Kisiler.Find(id);
            db.Kisiler.Remove(kisiler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
