using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakipSistemi
{
    //Bu somut sınıflara ihtiyacımız vardır çünkü gerçek kargo tipleri olmak zorundadır.
    //Ve bunlar soyut sınıftan miras alırlar çünkü ortak kullanılanları kullanmaları gerekir
    public class YurtDisiKargo : Kargo
    {
        public override void GonderiBilgisiYazdir() //Override çünkü abstracttan miras aldı 
        {
            //Artık burada KargoTakipNumarası,AliciAdi,GonderiDurumu bilgilerini direkt kullanabiliyoruz çünkü miras alındı.
            //Ayrıca bu bilgiler yurtdışı içinde kullandığımızdan dolayı abstract olarak aldık .
            Console.WriteLine("Yurtdışı Kargo Bilgileri :");
            Console.WriteLine("Yurtdışı Kargo Takip Numarası : " + KargoTakipNumarasi);
            Console.WriteLine("Gönderici Adı : " + GondericiAdi);
            Console.WriteLine("Yurtdışı Kargo Alıcı Adı : " + AliciAdi);
            Console.WriteLine("Yurtdışı Kargonun Son Durumu : " + GonderiDurumu);
            Console.WriteLine("Yurtdışı Kargo Adresi : " + Adres);
            Console.WriteLine(ucretHesapla() + " TL olarak hesaplanmıştır."); //Kargo ücretini yazdırır.    
            
        }

        public override int ucretHesapla()
        { int yurtDisiKargoUcreti = 1000; //Yurt dışı kargo ücreti sabit olarak 100 TL olarak belirlenmiştir.
            return 1000;
            
        }
        public override void teslimSuresiHesapla()
        {
            //Yurt dışı kargo teslim süresi 7-14 gün arasında değişir.
            Random random = new Random();
            int Tahminigun = random.Next(7, 15); //7 ile 14 gün arasında rastgele bir sayı üretir.
            Console.WriteLine("Yurt dışı kargo teslim süresi:{0} gün.",Tahminigun);
        }
        public override string KodOlustur()
        {
            Random r = new Random();
            //Yurt dışı kargo takip numarası 11 karakterden oluşur ve başında "YD" bulunur.
            KargoTakipNumarasi = "YD" + r.Next(100000000, 999999999).ToString(); //9 haneli rastgele bir sayı üretir ve başına "YD" ekler.
        }
    }
}
