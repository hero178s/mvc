using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLTA.Models
{
    public class TinTuc
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [Display(Name = "Tác giả")]
        public string TacGia { get; set; }

        [Display(Name = "Hinh")]
        public string Hinh { get; set; }

        [Display(Name = "Giờ đăng")]
        public DateTime GioDang { get; set; }

        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
    }
}