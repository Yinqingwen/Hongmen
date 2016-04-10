using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homgmen.Models;

namespace Homgmen.Areas.Setting.Controllers
{
    public class iPadController : Controller
    {
        private OldSot db = new OldSot();

        // GET: Setting/iPad
        public ActionResult Index()
        {
            return View(db.Iddes.Where(item => item.完成度 == "2").ToList());
        }

        // GET: Setting/iPad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idde idde = db.Iddes.Find(id);
            if (idde == null)
            {
                return HttpNotFound();
            }
            return View(idde);
        }

        // GET: Setting/iPad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setting/iPad/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,设备号,业务员,收货网点,始发城市,责任人")] Idde idde)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(idde.设备号) && !string.IsNullOrWhiteSpace(idde.设备号))
                    idde.设备号 = idde.设备号.ToString().Trim();
                if (!string.IsNullOrEmpty(idde.始发城市) && !string.IsNullOrWhiteSpace(idde.始发城市))
                    idde.始发城市 = idde.始发城市.ToString().Trim();
                if (!string.IsNullOrEmpty(idde.收货网点) && !string.IsNullOrWhiteSpace(idde.收货网点))
                    idde.收货网点 = idde.收货网点.ToString().Trim();
                if (!string.IsNullOrEmpty(idde.业务员) && !string.IsNullOrWhiteSpace(idde.业务员))
                    idde.业务员 = idde.业务员.ToString().Trim();
                if (!string.IsNullOrEmpty(idde.责任人) && !string.IsNullOrWhiteSpace(idde.责任人))
                    idde.责任人 = idde.责任人.ToString().Trim();
                idde.完成度 = "2";

                db.Iddes.Add(idde);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(idde);
        }

        // GET: Setting/iPad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idde idde = db.Iddes.Find(id);
            if (idde == null)
            {
                return HttpNotFound();
            }
            return View(idde);
        }

        // POST: Setting/iPad/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,设备号,业务员,收货网点,始发城市,责任人")] Idde idde)
        {
            if (ModelState.IsValid)
            {
                if ( !string.IsNullOrEmpty(idde.设备号 ) && !string.IsNullOrWhiteSpace(idde.设备号) )
                    idde.设备号 = idde.设备号.ToString().Trim();
                if ( !string.IsNullOrEmpty(idde.始发城市 ) && !string.IsNullOrWhiteSpace(idde.始发城市) )
                    idde.始发城市 = idde.始发城市.ToString().Trim();
                if ( !string.IsNullOrEmpty(idde.收货网点 ) && !string.IsNullOrWhiteSpace(idde.收货网点) )
                    idde.收货网点 = idde.收货网点.ToString().Trim();
                if ( !string.IsNullOrEmpty(idde.业务员 ) && !string.IsNullOrWhiteSpace(idde.业务员) )
                    idde.业务员 = idde.业务员.ToString().Trim();
                if ( !string.IsNullOrEmpty(idde.责任人) && !string.IsNullOrWhiteSpace(idde.责任人) )
                    idde.责任人 = idde.责任人.ToString().Trim();
                idde.完成度 = "2";

                db.Entry(idde).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idde);
        }

        // GET: Setting/iPad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idde idde = db.Iddes.Find(id);
            if (idde == null)
            {
                return HttpNotFound();
            }
            return View(idde);
        }

        // POST: Setting/iPad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Idde idde = db.Iddes.Find(id);
            db.Iddes.Remove(idde);
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
