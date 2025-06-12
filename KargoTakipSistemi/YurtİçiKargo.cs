using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakipSistemi
{
    //Bu somut sınıflara ihtiyacımız vardır çünkü gerçek kargo tipleri olmak zorundadır.
    //Ve bunlar soyut sınıftan miras alırlar çünkü ortak kullanılanları kullanmaları gerekir
    public class YurtIciKargo : Kargo
    {
       

        public override string teslimSuresiHesapla()
        {
            Random random = new Random();
            int Tahminigun = random.Next(1, 7); //1 ile 7 gün arasında rastgele bir sayı üretir.
            return Tahminigun.ToString() + " gün"; //Tahmini teslim süresini gün olarak döndürür.

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
            return KargoTakipNumarasi; //Oluşturulan takip numarasını döndürür.
        }
    }
}
