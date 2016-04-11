using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homgmen.Areas.Setting.Models;
using Homgmen.Models;

namespace Homgmen.Areas.Setting.Controllers
{
    public class SitesController : Controller
    {
        private OldSot db = new OldSot();

        // GET: Setting/Sites
        public ActionResult Index()
        {
            return View(db.Citytels.Where(item => item.完成度 == "2").ToList());
        }

        // GET: Setting/Sites/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citytel citytel = db.Citytels.Find(id);
            if (citytel == null)
            {
                return HttpNotFound();
            }
            return View(citytel);
        }

        // GET: Setting/Sites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setting/Sites/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,城市,编号,电话,保证金,完成度")] Citytel citytel)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(citytel.城市) && !string.IsNullOrWhiteSpace(citytel.城市))
                    citytel.城市 = citytel.城市.Trim();
                if (!string.IsNullOrEmpty(citytel.编号) && !string.IsNullOrWhiteSpace(citytel.编号))
                    citytel.编号 = citytel.编号.Trim();
                if (!string.IsNullOrEmpty(citytel.电话) && !string.IsNullOrWhiteSpace(citytel.电话))
                    citytel.电话 = citytel.电话.Trim();
                if (string.IsNullOrEmpty(citytel.保证金.ToString().Trim()) && string.IsNullOrWhiteSpace(citytel.保证金.ToString().Trim()))
                    citytel.保证金 = Convert.ToInt64(0.0);
                citytel.完成度 = "2";

                db.Citytels.Add(citytel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(citytel);
        }

        // GET: Setting/Sites/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citytel citytel = db.Citytels.Find(id);
            if (citytel == null)
            {
                return HttpNotFound();
            }
            return View(citytel);
        }

        // POST: Setting/Sites/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,城市,编号,电话,保证金")] Citytel citytel)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(citytel.城市) && !string.IsNullOrWhiteSpace(citytel.城市))
                    citytel.城市 = citytel.城市.Trim();
                if (!string.IsNullOrEmpty(citytel.编号) && !string.IsNullOrWhiteSpace(citytel.编号))
                    citytel.编号 = citytel.编号.Trim();
                if (!string.IsNullOrEmpty(citytel.电话) && !string.IsNullOrWhiteSpace(citytel.电话))
                    citytel.电话 = citytel.电话.Trim();
                if (string.IsNullOrEmpty(citytel.保证金.ToString().Trim()) && string.IsNullOrWhiteSpace(citytel.保证金.ToString().Trim()))
                    citytel.保证金 = Convert.ToInt64(0.0);
                citytel.完成度 = "2";

                db.Entry(citytel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(citytel);
        }

        // GET: Setting/Sites/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citytel citytel = db.Citytels.Find(id);
            if (citytel == null)
            {
                return HttpNotFound();
            }
            return View(citytel);
        }

        // POST: Setting/Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Citytel citytel = db.Citytels.Find(id);
            db.Citytels.Remove(citytel);
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
