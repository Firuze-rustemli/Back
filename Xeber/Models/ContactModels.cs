using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xeber.Models;

namespace Xeber.Models
{


    public class ContactModels
    {
        [Required(ErrorMessage = "Ad/Soyad gereklidir!!!")] 
        public string fullname { get; set; }
        [Required(ErrorMessage = "Email gereklidir!!!")]
        public string email { get; set; }
        [Required(ErrorMessage = "Boş Olmaz!!!")]
        [MaxLength(500, ErrorMessage = "500 karateri geçmeyin")]
        public string text { get; set; }

        // Eger Kayıt Edilecekse ve mail gönderene geri dönüş olacaksa
        //public DateTime Tarih { get; set; }
    }
}