using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_B2.Models;

namespace Demo_B2.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/
        public ActionResult Index()
        {
            return View();
        }
        // GET: /Article/Load/
        public JsonResult Load()
        {
            using (Entities db = new Entities())
            {
                var lstarticle = db.BaiViets.Select(x => new
                {
                    Id = x.ID,
                    Ten = x.TenBaiViet,
                    Loai = x.LoaiBaiViet,
                    TieuDe = x.TieuDe,
                    noiDung = x.NoiDungChiTiet
                }).ToList();
                return Json(new { Article = lstarticle }, JsonRequestBehavior.AllowGet);
            }
        }
        // POST: //Article/EditArticle/
        public JsonResult EditArticle(int id, string ten, string loai, string tieude, string noidung)
        {
            using (Entities db = new Entities())
            {
                try
                {
                    BaiViet bv = db.BaiViets.SingleOrDefault(x => x.ID == id);
                    bv.TenBaiViet = ten;
                    bv.LoaiBaiViet = loai;
                    bv.TieuDe = tieude;
                    bv.NoiDungChiTiet = noidung;
                    db.SaveChanges();
                    return Json(new
                    {
                        Id = bv.ID,
                        Ten = bv.TenBaiViet,
                        Loai = bv.LoaiBaiViet,
                        TieuDe = bv.TieuDe,
                        Noidung = bv.NoiDungChiTiet
                    });
                }
                catch (Exception)
                {
                    return null;
                }

            }
        }

        //POST: //Article/DelArticle/
        public int DelArticle(int id)
        {
            using (Entities db = new Entities())
            {
                BaiViet bv = db.BaiViets.SingleOrDefault(k => k.ID == id);

                if (bv != null)
                {
                    db.BaiViets.Remove(bv);
                    db.SaveChanges();
                    return id;
                }
                else
                    return -1;
            }
        }

        //POST: //Article/Add/
        public JsonResult Add(string ten, string loai, string tieuDe, string noiDung)
        {
            using (Entities db = new Entities())
            {
                BaiViet bv = new BaiViet();

                bv.TenBaiViet = ten;
                bv.LoaiBaiViet = loai;
                bv.TieuDe = tieuDe;
                bv.NoiDungChiTiet = noiDung;

                db.BaiViets.Add(bv);
                db.SaveChanges();
                return Json(new
                {
                    Id = bv.ID,
                    TenBV = bv.TenBaiViet,
                    LoaiBV = bv.LoaiBaiViet,
                    TieuDe = bv.TieuDe,
                    Noidungchitiet = bv.NoiDungChiTiet
                });
            }
        }
    }
}