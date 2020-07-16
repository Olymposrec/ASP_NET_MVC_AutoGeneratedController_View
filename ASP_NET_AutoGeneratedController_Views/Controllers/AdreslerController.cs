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
    public class AdreslerController : Controller
    {
        private TDBEF_CodefirstEntities db = new TDBEF_CodefirstEntities();

        // GET: Adresler
        public ActionResult Index()
        {
            var adresler = db.Adresler.Include(a => a.Kisiler);
            return View(adresler.ToList());
        }

        // GET: Adresler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresler adresler = db.Adresler.Find(id);
            if (adresler == null)
            {
                return HttpNotFound();
            }
            return View(adresler);
        }

        // GET: Adresler/Create
        public ActionResult Create()
        {
            ViewBag.kisi_ID = new SelectList(db.Kisiler, "ID", "Ad");
            return View();
        }

        // POST: Adresler/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AdresTanim,kisi_ID")] Adresler adresler)
        {
            if (ModelState.IsValid)
            {
                db.Adresler.Add(adresler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kisi_ID = new SelectList(db.Kisiler, "ID", "Ad", adresler.kisi_ID);
            return View(adresler);
        }

        // GET: Adresler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresler adresler = db.Adresler.Find(id);
            if (adresler == null)
            {
                return HttpNotFound();
            }
            ViewBag.kisi_ID = new SelectList(db.Kisiler, "ID", "Ad", adresler.kisi_ID);
            return View(adresler);
        }

        // POST: Adresler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AdresTanim,kisi_ID")] Adresler adresler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kisi_ID = new SelectList(db.Kisiler, "ID", "Ad", adresler.kisi_ID);
            return View(adresler);
        }

        // GET: Adresler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresler adresler = db.Adresler.Find(id);
            if (adresler == null)
            {
                return HttpNotFound();
            }
            return View(adresler);
        }

        // POST: Adresler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adresler adresler = db.Adresler.Find(id);
            db.Adresler.Remove(adresler);
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
