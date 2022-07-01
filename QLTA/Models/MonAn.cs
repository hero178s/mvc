using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLTA.Models
{
    public class MonAn
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Tên món ăn")]
        public string TenMA { get; set; }

        [Display(Name = "NguoiNau")]
        public string NguoiNau { get; set; }

        [Display(Name = "Hinh")]
        public string Hinh { get; set; }

        [Display(Name = "Giờ")]
        public DateTime Gio { get; set; }

        [Display(Name = "Giá")]
        public string Gia { get; set; }

        [Display(Name = "Số lượng")]
        public string SoLuong { get; set; }




        [ForeignKey("LoaiThucAn")]
        public int MaTL { get; set; }
        public LoaiThucAn LoaiThucAn { get; set; }
    }
}