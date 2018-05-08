using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLCTTHTH.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;


namespace WebQLCTTHTH.Controllers
{
    public class BGKController : Controller
    {
        QLCTTHTHDataContext db = new QLCTTHTHDataContext();
        // GET: TS
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChuDe(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;

            return View(db.ChuDes.ToList().OrderBy(n => n.MaCD).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaCD == id);
            ViewBag.MaCD = cd.MaCD;
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cd);
        }

        public ActionResult Delete(int id)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaCD == id);
            ViewBag.MaCD = cd.MaCD;
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cd);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaCD == id);
            ViewBag.MaTS = cd.MaCD;
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ChuDes.DeleteOnSubmit(cd);
            db.SubmitChanges();
            return RedirectToAction("BGK");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaCD == id);
            ViewBag.MaCD = cd.MaCD;
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cd);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ChuDe cd)
        {

            var c = db.ChuDes.SingleOrDefault(n => n.MaCD == cd.MaCD);

            if (ModelState.IsValid)
            {
                c.MaCD = cd.MaCD;
                c.TenCD = cd.TenCD;
                
                db.SubmitChanges();
            }
            return RedirectToAction("BGK");
        }

        /*==================BaiHat=======================*/

        public ActionResult BaiHat(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;

            return View(db.BaiHats.ToList().OrderBy(n => n.MaBH).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult CreateBH()
        {
            return View();
        }

        public ActionResult DetailsBH(int id)
        {
            BaiHat bh = db.BaiHats.SingleOrDefault(n => n.MaBH == id);
            ViewBag.MaBH = bh.MaBH;
            if (bh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(bh);
        }

        public ActionResult DeleteBH(int id)
        {
            BaiHat bh = db.BaiHats.SingleOrDefault(n => n.MaBH == id);
            ViewBag.MaBH = bh.MaBH;
            if (bh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(bh);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteBHConfirm(int id)
        {
            BaiHat bh = db.BaiHats.SingleOrDefault(n => n.MaBH == id);
            ViewBag.MaBH = bh.MaBH;
            if (bh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.BaiHats.DeleteOnSubmit(bh);
            db.SubmitChanges();
            return RedirectToAction("BGK");
        }

        [HttpGet]
        public ActionResult EditBH(int id)
        {
            BaiHat bh = db.BaiHats.SingleOrDefault(n => n.MaBH == id);
            ViewBag.MaBH = bh.MaBH;
            if (bh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(bh);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditBH(BaiHat bh)
        {

            var b = db.BaiHats.SingleOrDefault(n => n.MaBH == bh.MaBH);

            if (ModelState.IsValid)
            {
                b.MaBH = bh.MaBH;
                b.TenBH = bh.TenBH;
                b.Nhac = bh.Nhac;
                b.Loi = bh.Loi;
                b.Ma_CD = bh.Ma_CD;

                db.SubmitChanges();
            }
            return RedirectToAction("BGK");
        }

    }
}