namespace QLHangHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HangHoa")]
    public partial class HangHoa
    {
        [Key]
        [DisplayName("Mã hàng")]
        public int MaHang { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên hàng")]
        public string TenHang { get; set; }
       
        [DisplayName("Thuế")]
        public int Thue { get; set; }
        [DisplayName("Giá nhập")]

        public double Gianhap { get; set; }
        [DisplayName("Giá bán")]

        public double Giaban { get; set; }

        [DisplayName("Thể loại")]

        [Required]
        [StringLength(30)]
        public string Theloai { get; set; }
        [DisplayName("Số lượng hiện tại")]

        public int? Soluonghientai { get; set; }
    }
}
