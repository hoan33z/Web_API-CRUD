using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData
{
    public class NhanVien
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [StringLength(30,ErrorMessage ="Tên dài quá")]
        public String Ten { get; set; }
        [Required]
        [Range(18,50,ErrorMessage ="Bạn ko đủ tuổi")]
        public int Tuoi { get; set; }
        [Required]
        public int Role { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(5000000,30000000,ErrorMessage ="Bèo Bọt")]
        public int Luong { get; set; }
        [Required]
        public bool TrangThai { get; set; }
    }

}
