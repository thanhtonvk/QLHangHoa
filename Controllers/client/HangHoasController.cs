using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLHangHoa.BUS;
using QLHangHoa.Models;

namespace QLHangHoa.Controllers.client
{
    public class HangHoasController : Controller
    {
        HangHoaBUS hangHoaBUS = new HangHoaBUS();

        // GET: HangHoas
        public ActionResult Index()
        {
            var model = hangHoaBUS.GetHangHoas();
            if (model.ToList().Count == 0)
            {
                ViewBag.ThongBao = "Không có dữ liệu";
            }
            return View(hangHoaBUS.GetHangHoas());
        }

        // GET: HangHoas/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = hangHoaBUS.GetHangHoaByID(id.Value);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // GET: HangHoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HangHoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHang,TenHang,Thue,Gianhap,Giaban,Theloai,Soluonghientai")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                int check = hangHoaBUS.Add(hangHoa);
                if (check == -1)
                {
                    ViewBag.ThongBao = "Tên hàng đã tồn tại";
                }
                else if (check == 0)
                {
                    ViewBag.ThongBao = "Thất bại";
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }

            return View(hangHoa);
        }

        // GET: HangHoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = hangHoaBUS.GetHangHoaByID(id.Value);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // POST: HangHoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHang,TenHang,Thue,Gianhap,Giaban,Theloai,Soluonghientai")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                int check = hangHoaBUS.Update(hangHoa);
                if (check == 0)
                {
                    ViewBag.ThongBao = "Thất bại";
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            return View(hangHoa);
        }

        // GET: HangHoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = hangHoaBUS.GetHangHoaByID(id.Value);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // POST: HangHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int check = hangHoaBUS.Delete(id);
            if (check == 0)
            {
                ViewBag.ThongBao = "Thất bại";
            }
            else
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetHangHoaByName(string tenHangHoa)
        {
            var model = hangHoaBUS.GetHangHoaByName(tenHangHoa);
            return View(model);
        }
        public ActionResult GetHangHoaByLoai(string loaiHangHoa)
        {
            var model = hangHoaBUS.GetHangHoaByLoai(loaiHangHoa);
            return View(model);
        }
        public ActionResult GetHangHoaTheoGia(int? X,int? Y)
        {
            var model = new List<HangHoa>();
            if (X == null || Y == null)
            {
                return View(model);
            }
            model = hangHoaBUS.GetHangHoaByGiaBan(X.Value,Y.Value).ToList();
            return View(model);
        }
        public ActionResult GetHangHoaSapHet()
        {
            var model = hangHoaBUS.GetSoLuongCon();
            return View(model);
        }


    }
}
