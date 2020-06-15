using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WalletFinal.Models;

namespace WalletFinal.Controllers
{
    public class WalletController : Controller
    {
        private BSE163111Entities1 db = new BSE163111Entities1();

        // GET: Wallet
        public ActionResult Index()
        {
            return View(db.WalletBSE163111.ToList());
        }

        // GET: Wallet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalletBSE163111 walletBSE163111 = db.WalletBSE163111.Find(id);
            if (walletBSE163111 == null)
            {
                return HttpNotFound();
            }
            return View(walletBSE163111);
        }

        // GET: Wallet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wallet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WalletBSE163111 cvm)
        {
            WalletBSE163111 cat = new WalletBSE163111();
            cat.WaleedName = cvm.WaleedName;
            cat.Description = cvm.Description;
            cat.Amount = cvm.Amount;
            db.WalletBSE163111.Add(cat);
            db.SaveChanges();
            return View();
        }

        // POST: Wallet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WalletId,WaleedName,Description,Amount")] WalletBSE163111 walletBSE163111)
        {
            if (ModelState.IsValid)
            {
                db.Entry(walletBSE163111).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(walletBSE163111);
        }

        // GET: Wallet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalletBSE163111 walletBSE163111 = db.WalletBSE163111.Find(id);
            if (walletBSE163111 == null)
            {
                return HttpNotFound();
            }
            return View(walletBSE163111);
        }

        // POST: Wallet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WalletBSE163111 walletBSE163111 = db.WalletBSE163111.Find(id);
            db.WalletBSE163111.Remove(walletBSE163111);
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
