using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLTA.Models
{
    public class LoaiThucAn
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên thể loại")]
        public string TenTL { get; set; }

        public ICollection<MonAn> MonAns { get; set; }
    }
}