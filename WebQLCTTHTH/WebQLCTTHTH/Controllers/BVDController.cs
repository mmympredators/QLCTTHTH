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

    public class BVDController : Controller
    {
        QLCTTHTHDataContext db = new QLCTTHTHDataContext();
        // GET: BVD
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NTT(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;

            return View(db.NhaTaiTros.ToList().OrderBy(n => n.MaNTT).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult NTTCreate()
        {
            return View();
        }

        public ActionResult NTTDetails(int id)
        {
            NhaTaiTro ntt = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == id);
            ViewBag.MaNTT = ntt.MaNTT;
            if (ntt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ntt);
        }

        public ActionResult NTTDelete(int id)
        {
            NhaTaiTro ntt = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == id);
            ViewBag.MaNTT = ntt.MaNTT;
            if (ntt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ntt);
        }

        [HttpPost, ActionName("NTTDelete")]
        public ActionResult NTTDeleteConfirm(int id)
        {
            NhaTaiTro ntt = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == id);
            ViewBag.MaNTT = ntt.MaNTT;
            if (ntt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NhaTaiTros.DeleteOnSubmit(ntt);
            db.SubmitChanges();
            return RedirectToAction("NTT");
        }

        [HttpGet]
        public ActionResult NTTEdit(int id)
        {
            NhaTaiTro ntt = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == id);
            ViewBag.MaNTT = ntt.MaNTT;
            if (ntt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ntt);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NTTEdit(NhaTaiTro ntt)
        {

            var t = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == ntt.MaNTT);

            if (ModelState.IsValid)
            {
                t.MaNTT = ntt.MaNTT;
                t.TenNTT = ntt.TenNTT;
                t.DiaChiNTT = ntt.DiaChiNTT;
                t.EmailNTT = ntt.EmailNTT;
                db.SubmitChanges();
            }
            return RedirectToAction("NTT");
        }

        /*===========Chi Tiet Dot Thi=============*/

        
        //public ActionResult CTDT(int? page)
        //{
        //    int pageNumber = (page ?? 1);
        //    int pageSize = 7;

        //    return View(db.CTTTDTs.ToList().OrderBy(n => n.MaNTT).ToPagedList(pageNumber, pageSize));
        //}

        //[HttpGet]
        //public ActionResult NTTCreate()
        //{
        //    return View();
        //}

        //public ActionResult NTTDetails(int id)
        //{
        //    NhaTaiTro ntt = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == id);
        //    ViewBag.MaNTT = ntt.MaNTT;
        //    if (ntt == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    return View(ntt);
        //}

        //public ActionResult NTTDelete(int id)
        //{
        //    NhaTaiTro ntt = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == id);
        //    ViewBag.MaNTT = ntt.MaNTT;
        //    if (ntt == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    return View(ntt);
        //}

        //[HttpPost, ActionName("NTTDelete")]
        //public ActionResult NTTDeleteConfirm(int id)
        //{
        //    NhaTaiTro ntt = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == id);
        //    ViewBag.MaNTT = ntt.MaNTT;
        //    if (ntt == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    db.NhaTaiTros.DeleteOnSubmit(ntt);
        //    db.SubmitChanges();
        //    return RedirectToAction("NTT");
        //}

        //[HttpGet]
        //public ActionResult NTTEdit(int id)
        //{
        //    NhaTaiTro ntt = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == id);
        //    ViewBag.MaNTT = ntt.MaNTT;
        //    if (ntt == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    return View(ntt);
        //}

        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult NTTEdit(NhaTaiTro ntt)
        //{

        //    var t = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == ntt.MaNTT);

        //    if (ModelState.IsValid)
        //    {
        //        t.MaNTT = ntt.MaNTT;
        //        t.TenNTT = ntt.TenNTT;
        //        t.DiaChiNTT = ntt.DiaChiNTT;
        //        t.EmailNTT = ntt.EmailNTT;
        //        db.SubmitChanges();
        //    }
        //    return RedirectToAction("NTT");
        //}
    }
}