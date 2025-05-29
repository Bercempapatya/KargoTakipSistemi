using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakipSistemi
{
   public abstract class Kargo :IGonderiTakip //Abstract çünkü genel kullanılacak ortak isimler burada olacak diğer sınıflar miras alacaktır
    {
        // Tüm ortak olacakları bu sınıfa yazıyoruz
        public string KargoTakipNumarasi { get; set; }
        public string AliciAdi { get; set; }
        public Durum GonderiDurumu { get; set; } //Tüm Kargoların durum bilgisi olur o yüzden diğer sınıflarda da kullanmalıyız
        public void DurumGuncelle(Durum yeniDurum){ GonderiDurumu=yeniDurum;};
        public abstract void teslimSuresiHesapla(); //Buradan türetilecek kargoların yurt içi-dışı olma durumuna bağlı teslim suresi hesaplanır.
        public abstract void ucretHesapla(); //Kargonun yurt içi-dışı olmak üzere farklı ücretleri bu metotla hesaplanacaktır.

        //Şimdi de tüm kargolarda olması gerekir ama her kargo tiipi içinde farklıdır o yüzden sadece gövdesi oluşturuyoruz
        public abstract void GonderiBilgisiYazdir();//Yani her kargo tipinde bu metot içeriği farklı olacak 


    }
}
