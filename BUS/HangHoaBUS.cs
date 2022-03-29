using QLHangHoa.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace QLHangHoa.BUS
{
    public class HangHoaBUS
    {
        private string baseUrl = "https://localhost:44351/";
        public IEnumerable<HangHoa> GetHangHoas()
        {
            List<HangHoa> hangHoas = new List<HangHoa>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync("api/hanghoas/gethanghoa");
                response.Wait();
                var result = response.Result;
                //return về code 200 thì mới lấy dữ liệu
                if (result.IsSuccessStatusCode)
                {
                    hangHoas = result.Content.ReadAsAsync<List<HangHoa>>().Result;
                }

            }
            return hangHoas;
        }
        public HangHoa GetHangHoaByID(int id)
        {
            HangHoa hangHoa = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync($"api/hanghoas/gethanghoabyma?MaHang={id}");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    hangHoa = result.Content.ReadAsAsync<HangHoa>().Result;
                }
            }
            return hangHoa;
        }
        public IEnumerable<HangHoa> GetHangHoaByName(string tenHangHoa)
        {
            List<HangHoa> hangHoas = new List<HangHoa>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync($"api/hanghoas/{tenHangHoa}");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    hangHoas = result.Content.ReadAsAsync<List<HangHoa>>().Result;
                }

            }
            return hangHoas;
        }
        public IEnumerable<HangHoa> GetHangHoaByLoai(string Theloai)
        {
            List<HangHoa> hangHoas = new List<HangHoa>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync($"hanghoas/loai?Theloai={Theloai}");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    hangHoas = result.Content.ReadAsAsync<List<HangHoa>>().Result;
                }

            }
            return hangHoas;
        }
        public IEnumerable<HangHoa> GetHangHoaByGiaBan(int X, int Y)
        {
            List<HangHoa> hangHoas = new List<HangHoa>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync($"hanghoas/giaban?X={X}&Y={Y}");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    hangHoas = result.Content.ReadAsAsync<List<HangHoa>>().Result;
                }

            }
            return hangHoas;
        }
        public IEnumerable<HangHoa> GetSoLuongCon()
        {
            List<HangHoa> hangHoas = new List<HangHoa>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.GetAsync("hanghoas/soluongcon");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    hangHoas = result.Content.ReadAsAsync<List<HangHoa>>().Result;
                }

            }
            return hangHoas;
        }
        public int Add(HangHoa hangHoa)
        {
            int rs = -1;
            using(var client = new HttpClient())
            {
                client.BaseAddress= new Uri(baseUrl);
                var response = client.PostAsJsonAsync("api/hanghoas/post", hangHoa);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    rs = result.Content.ReadAsAsync<int>().Result;
                }
            }
            return rs;
        }
        public int Update(HangHoa hangHoa)
        {
            int rs = -1;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.PutAsJsonAsync("api/hanghoas/put", hangHoa);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    rs = result.Content.ReadAsAsync<int>().Result;
                }
            }
            return rs;
        }
        public int Delete(int MaHang)
        {
            int rs = -1;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.DeleteAsync($"api/hanghoas/delete?MaHang={MaHang}");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    rs = result.Content.ReadAsAsync<int>().Result;
                }
            }
            return rs;
        }
    }
}