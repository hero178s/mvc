using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLTA.Models
{
    public class GioHang
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Tên món ăn")]
        public string TenMA { get; set; }

        [Display(Name = "Hinh")]
        public string Hinh { get; set; }

        [Display(Name = "Giá")]
        public int Gia { get; set; }

        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        [Display(Name = "Thành tiền")]
        public decimal ThanhTien
        {
            get { return SoLuong * Gia; }
        }

        //[ForeignKey("LoaiThucAn")]
        //public int Id { get; set; }
        //public Id Id { get; set; }
        //public giohang(int mamon)

        //{
        //    this.id = mamon;
        //    monan monan = data.monans.single(m => m.mamon == mamon);
        //    gia = decimal.parse(mon.gia.tostring());
        //    isoluong = 1;

        //}

        //[ForeignKey("LoaiThucAn")]
        //public int MaTL { get; set; }
        //public LoaiThucAn LoaiThucAn { get; set; }
    }
}