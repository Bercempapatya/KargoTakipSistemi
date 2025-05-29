using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakipSistemi
{
   public abstract class Kargo //Abstract çünkü genel kullanılacak ortak isimler burada olacak diğer sınıflar miras alacaktır
    {
        // Tüm ortak olacakları bu sınıfa yazıyoruz
        public string KargoTakipNumarası { get; set; }
        public string AliciAdi { get; set; }
        public Durum GonderiDurumu { get; set; } //Tüm Kargoların durum bilgisi olur o yüzden diğer sınıflarda da kullanmalıyız

        //Şimdi de tüm kargolarda olması gerekir ama her kargo tiipi içinde farklıdır o yüzden sadece gövdesi oluşturuyoruz
        public abstract void GonderiBilgisiYazdir();//Yani her kargo tipinde bu metot içeriği farklı olacak 


    }
}
