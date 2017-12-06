using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Personal_Inventory_Management.DataModels;
using Personal_Inventory_Management.Models;
using Microsoft.AspNet.Identity;

namespace Personal_Inventory_Management.Controllers
{
    public class ItemHeadersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemHeaders
        public ActionResult Index()
        {
            return View(db.ItemHeader.ToList());
        }

        // GET: ItemHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemHeader itemHeader = db.ItemHeader.Find(id);
            if (itemHeader == null)
            {
                return HttpNotFound();
            }
            return View(itemHeader);
        }

        // GET: ItemHeaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemName,ItemDescription,DateAcquired,Note")] CreateItemHeader model)
        {
            
            if (ModelState.IsValid)
            {
                var itemHeader = new ItemHeader
                {
                    ItemName = model.ItemName,
                    ItemDescription = model.ItemDescription,
                    DateAcquired = model.DateAcquired,
                    Note = model.ItemName,
                    User = db.Users.Find(User.Identity.GetUserId())
                };

                db.ItemHeader.Add(itemHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: ItemHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemHeader itemHeader = db.ItemHeader.Find(id);
            if (itemHeader == null)
            {
                return HttpNotFound();
            }
            return View(itemHeader);
        }

        // POST: ItemHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemHeaderId,ItemName,ItemDescription,DateAcquired,Note")] ItemHeader itemHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemHeader);
        }

        // GET: ItemHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemHeader itemHeader = db.ItemHeader.Find(id);
            if (itemHeader == null)
            {
                return HttpNotFound();
            }
            return View(itemHeader);
        }

        // POST: ItemHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemHeader itemHeader = db.ItemHeader.Find(id);
            db.ItemHeader.Remove(itemHeader);
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
