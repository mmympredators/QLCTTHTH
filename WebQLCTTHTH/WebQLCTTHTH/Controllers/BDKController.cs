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
    public class BDKController : Controller
    {
        QLCTTHTHDataContext db = new QLCTTHTHDataContext();
        // GET: BDK
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DT(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;

            return View(db.DotThis.ToList().OrderBy(n => n.LanThi).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult DTCreate()
        {
            return View();
        }

        public ActionResult DTDetails(int id)
        {
            DotThi dt = db.DotThis.SingleOrDefault(n => n.LanThi == id);
            ViewBag.LanThi = dt.LanThi;
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dt);
        }

        public ActionResult DTDelete(int id)
        {
            DotThi dt = db.DotThis.SingleOrDefault(n => n.LanThi == id);
            ViewBag.LanThi = dt.LanThi;
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dt);
        }

        [HttpPost, ActionName("DTDelete")]
        public ActionResult DTDeleteConfirm(int id)
        {
            DotThi dt = db.DotThis.SingleOrDefault(n => n.LanThi == id);
            ViewBag.LanThi = dt.LanThi;
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DotThis.DeleteOnSubmit(dt);
            db.SubmitChanges();
            return RedirectToAction("DT");
        }

        [HttpGet]
        public ActionResult DTEdit(int id)
        {
            DotThi dt = db.DotThis.SingleOrDefault(n => n.LanThi == id);
            ViewBag.LanThi = dt.LanThi;
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dt);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DTEdit(DotThi dt)
        {

            var d = db.DotThis.SingleOrDefault(n => n.LanThi == dt.LanThi);

            if (ModelState.IsValid)
            {
                d.LanThi = dt.LanThi;
                d.NamThi = dt.NamThi;
                d.NoiDung = dt.NoiDung;
                db.SubmitChanges();
            }
            return RedirectToAction("DT");
        }
        //// GET: Default/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Default/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Default/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Default/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Default/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Default/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        /*==================Giaithuong=====================*/

        public ActionResult GT(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;

            return View(db.GiaiThuongs.ToList().OrderBy(n => n.MaGT).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult GTCreate()
        {
            return View();
        }

        public ActionResult GTDetails(int id)
        {
            GiaiThuong gt = db.GiaiThuongs.SingleOrDefault(n => n.MaGT == id);
            ViewBag.MaGT = gt.MaGT;
            if (gt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(gt);
        }

        public ActionResult GTDelete(int id)
        {
            GiaiThuong gt = db.GiaiThuongs.SingleOrDefault(n => n.MaGT == id);
            ViewBag.MaGT = gt.MaGT;
            if (gt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(gt);
        }

        [HttpPost, ActionName("GTDelete")]
        public ActionResult GTDeleteConfirm(int id)
        {
            GiaiThuong gt = db.GiaiThuongs.SingleOrDefault(n => n.MaGT == id);
            ViewBag.MaGT = gt.MaGT;
            if (gt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.GiaiThuongs.DeleteOnSubmit(gt);
            db.SubmitChanges();
            return RedirectToAction("GT");
        }

        [HttpGet]
        public ActionResult GTEdit(int id)
        {
            GiaiThuong gt = db.GiaiThuongs.SingleOrDefault(n => n.MaGT == id);
            ViewBag.MaGT = gt.MaGT;
            if (gt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(gt);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GTEdit(GiaiThuong gt)
        {

            var g = db.GiaiThuongs.SingleOrDefault(n => n.MaGT == gt.MaGT);

            if (ModelState.IsValid)
            {
                g.MaGT = gt.MaGT;
                g.TenGiaiThuong = gt.TenGiaiThuong;
                g.SoTienThuong = gt.SoTienThuong;
                db.SubmitChanges();
            }
            return RedirectToAction("GT");
        }

        /*==================VongThi=====================*/

        public ActionResult VT(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;

            return View(db.VongThis.ToList().OrderBy(n => n.MaVT).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult VTCreate()
        {
            return View();
        }

        public ActionResult VTDetails(int id)
        {
            VongThi vt = db.VongThis.SingleOrDefault(n => n.MaVT == id);
            ViewBag.MaVT = vt.MaVT;
            if (vt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(vt);
        }

        public ActionResult VTDelete(int id)
        {
            VongThi vt = db.VongThis.SingleOrDefault(n => n.MaVT == id);
            ViewBag.MaVT = vt.MaVT;
            if (vt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(vt);
        }

        [HttpPost, ActionName("VTDelete")]
        public ActionResult VTDeleteConfirm(int id)
        {
            VongThi vt = db.VongThis.SingleOrDefault(n => n.MaVT == id);
            ViewBag.MaVT = vt.MaVT;
            if (vt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.VongThis.DeleteOnSubmit(vt);
            db.SubmitChanges();
            return RedirectToAction("VT");
        }

        [HttpGet]
        public ActionResult VTEdit(int id)
        {
            VongThi vt = db.VongThis.SingleOrDefault(n => n.MaVT == id);
            ViewBag.MaVT = vt.MaVT;
            if (vt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(vt);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult VTEdit(VongThi vt)
        {

            var v = db.VongThis.SingleOrDefault(n => n.MaVT == vt.MaVT);

            if (ModelState.IsValid)
            {
                v.MaVT = vt.MaVT;
                v.TenVT = vt.TenVT;
                
                db.SubmitChanges();
            }
            return RedirectToAction("VT");
        }
    }
}