using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakipSistemi
{
    //Bu somut sınıflara ihtiyacımız vardır çünkü gerçek kargo tipleri olmak zorundadır.
    //Ve bunlar soyut sınıftan miras alırlar çünkü ortak kullanılanları kullanmaları gerekir
   public class YurtIciKargo :Kargo
    {
        public override void GonderiBilgisiYazdir() //Override çünkü abstracttan miras aldı 
        {
            //Artık burada KargoTakipNumarası,AliciAdi,GonderiDurumu bilgilerini direkt kullanabiliyoruz çünkü miras alındı.
            //Ayrıca bu bilgiler yurtiçi içinde kullandığımızdan dolayı abstract olarak aldık .
            Console.WriteLine("Yurtiçi Kargo Bilgileri :");
            Console.WriteLine("Yurtiçi Kargo Takip Numarası : "+KargoTakipNumarasi);
            Console.WriteLine("Yurtiçi Kargo Alıcı Adı : " +AliciAdi);
            Console.WriteLine("Gönderici Adı : " + GondericiAdi);
            Console.WriteLine("Yurtiçi Kargonun Son Durumu : "+GonderiDurumu);
            Console.WriteLine("Yurtiçi Kargo Adresi : " + Adres);
        }

        public override void teslimSuresiHesapla()
        {
            Random random = new Random();
            int Tahminigun = random.Next(1, 7); //1 ile 7 gün arasında rastgele bir sayı üretir.
            Console.WriteLine("Yurtiçi kargo teslim süresi: {0} gün.", Tahminigun);
        }
        public override int ucretHesapla()
        {
            int yurtIciKargoUcreti = 200; //Yurt içi kargo ücreti sabit olarak 200 TL olarak belirlenmiştir.
            return yurtIciKargoUcreti;
        }
        public override string KodOlustur()
        {
            Random r = new Random();
            //Yurt içi kargo takip numarası 11 karakterden oluşur ve başında "YI" bulunur.
            KargoTakipNumarasi = "YI" + r.Next(100000000, 999999999).ToString(); //9 haneli rastgele bir sayı üretir ve başına "YI" ekler.
        }
    }
