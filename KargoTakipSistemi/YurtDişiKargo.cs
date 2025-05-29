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
            Console.WriteLine("Yurtdışı Kargo Alıcı Adı : " + AliciAdi);
            Console.WriteLine("Yurtdışı Kargonun Son Durumu : " + GonderiDurumu);
        }
    }
}
