using QLHangHoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLHangHoa.Controllers.api
{
    public class HangHoaController : ApiController
    {
        DBContext db = new DBContext();
        [Route("api/hanghoas/gethanghoa")]
        public IQueryable<HangHoa> GetHangHoas()
        {
            return db.HangHoas;
        }

        [Route("api/hanghoas/gethanghoabyma")]
        public HangHoa GetHangHoasByMa(int MaHang)
        {
            return db.HangHoas.Find(MaHang);
        }

        [Route("api/hanghoas/{tenHangHoa}")]
        //trả về 1 danh sách
        public IQueryable<HangHoa> GetHangHoaByName(String tenHangHoa)
        {
            return db.HangHoas.Where(x=>x.TenHang.ToLower().Contains(tenHangHoa.ToLower()));
        }

        [Route("hanghoas/loai")]
        public IQueryable<HangHoa> GetHangHoaByLoai(String Theloai)
        {
            return db.HangHoas.Where(x => x.Theloai.ToLower().Contains(Theloai.ToLower()));
        }

        [Route("hanghoas/giaban")]
        public IQueryable<HangHoa> GetHangHoaByGiaBan(int X, int Y)
        {
            return db.HangHoas.Where(x => x.Giaban >= X && x.Giaban <= Y);
        }
        [Route("hanghoas/soluongcon")]
        public IQueryable<HangHoa> GetSoLuongSapHet()
        {
            return db.HangHoas.Where(x => x.Soluonghientai < 5);
        }

        [Route("api/hanghoas/post")]
        public int Post([FromBody] HangHoa hangHoa)
        {
            var check = db.HangHoas.FirstOrDefault(x => x.TenHang == hangHoa.TenHang);
            if (check == null)
            {
                db.HangHoas.Add(hangHoa);
                return db.SaveChanges();

            }
            else
            {
                return -1;
            }
        }
        [Route("api/hanghoas/put")]
        public int Put([FromBody] HangHoa hangHoa)
        {
            db.HangHoas.Add(hangHoa);
            db.Entry(hangHoa).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();

        }

        [Route("api/hanghoas/delete")]
        public int Delete(int MaHang)
        {
            var model = db.HangHoas.Find(MaHang);
            db.HangHoas.Remove(model);
            return db.SaveChanges();
        }
    }
}
