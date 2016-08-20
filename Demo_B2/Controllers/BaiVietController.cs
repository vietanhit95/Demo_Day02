using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_B2.Models;

namespace Demo_B2.Controllers
{
    public class BaiVietController : Controller
    {
        //
        // GET: /BaiViet/
        public ActionResult Index()
        {
            using (Entities eT = new Entities())
            {
                List<BaiViet> lstBaiViet = eT.BaiViets.ToList();
                return View(lstBaiViet);
            }
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(FormCollection f)
        {
            string tenBaiviet = f["ten"].ToString();
            string loaiBaiviet = f["loai"].ToString();
            string tieuDe = f["tieude"].ToString();
            string noiDung = f["noidung"].ToString();
            using (Entities eT = new Entities())
            {
                BaiViet bv = new BaiViet();
                bv.TenBaiViet = tenBaiviet;
                bv.LoaiBaiViet = loaiBaiviet;
                bv.TieuDe = tieuDe;
                bv.NoiDungChiTiet = noiDung;

                eT.BaiViets.Add(bv);
                eT.SaveChanges();

                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (Entities eT = new Entities())
            {
                BaiViet bV = eT.BaiViets.FirstOrDefault(k => k.ID == id);
                return View(bV);
            }
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f, int id)
        {
            using (Entities eT = new Entities())
            {
                string tenBaiviet = f["ten"].ToString();
                string loaiBaiviet = f["loai"].ToString();
                string tieuDe = f["tieude"].ToString();
                string noiDung = f["noidung"].ToString();
                BaiViet bv = eT.BaiViets.FirstOrDefault(k => k.ID == id);
                bv.TenBaiViet = tenBaiviet.Trim();
                bv.LoaiBaiViet = loaiBaiviet.Trim();
                bv.TieuDe = tieuDe.Trim();
                bv.NoiDungChiTiet = noiDung.Trim(); ;
                eT.SaveChanges(); ;
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int id)
        {
            using (Entities eT = new Entities())
            {
                BaiViet bV = eT.BaiViets.FirstOrDefault(k => k.ID == id);
                eT.BaiViets.Remove(bV);
                eT.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}