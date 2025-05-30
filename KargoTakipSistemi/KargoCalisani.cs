using System;
using System.IO;
namespace KargoTakipSistemi
{
    public class KargoCalisani
    {
        public string kullaniciAdi { get; set; } //Kargo çalışanının kullanıcı adı
        public string sifre { get; set; } //Kargo çalışanının şifresi
        FileInfo kargoDosyasi = new FileInfo("kargolar.txt"); //Kargo bilgilerini tutacağımız dosya




        List<Kargo> kargolar = new List<Kargo>(); //Kargo listesi oluşturuyoruz.
        List<Kargo> YurtİciKargolar = new List<Kargo>(); //Yurt içi kargo listesi
        List<Kargo> YurtDisiKargolar = new List<Kargo>(); //Yurt dışı kargo listesi

        public void KargoEkle(Kargo Yenikargo)
        {
            Yenikargo.KodOlustur();//Kargo takip numarasını oluşturuyoruz.
            Yenikargo.GonderiDurumu = Durum.Hazirlaniyor; //Kargonun başlangıç durumu "Hazırlanıyor" olarak ayarlanıyor.
            kargolar.Add(Yenikargo);
            if (Yenikargo is YurtIciKargo) //Eğer kargo yurtiçi ise yurtiçi kargo listesine ekliyoruz.
            {
                YurtİciKargolar.Add(Yenikargo);
            }
            else if (Yenikargo is YurtDisiKargo) //Eğer kargo yurtdışı ise yurtdışı kargo listesine ekliyoruz.
            {
                YurtDisiKargolar.Add(Yenikargo);
            }
            using (StreamWriter sw = new StreamWriter("kargolar.txt", true)) //Kargo bilgilerini dosyaya ekliyoruz.
            {
                sw.WriteLine(Yenikargo.kargoTakipNumarasi + "," + Yenikargo.AliciAdi + "," + Yenikargo.GondericiAdi + "," + Yenikargo.Adres + "," + Yenikargo.GonderiDurumu);

            }
        }

        public void KargoDurumGuncelle(string kargoTakipNumarasi)
        {
            for (int i = 0; i < kargolar.length; i++)
            {
                if (kargolar[i].kargoTakipNumarasi == kargoTakipNumarasi) //Kargo takip numarasına göre kargoyu buluyoruz.
                {
                    Durum durum = kargolar[i].GonderiDurumu;  //Kargonun durumunu durum değişkenine atıyoruz.
                    switch (durum) //Duruma göre kargonun durumunu güncelliyoruz.
                    {
                        case Durum.Hazirlaniyor:
                            kargolar[i].DurumGuncelle(Durum.Yolda);
                            break;
                        case Durum.Yolda:
                            kargolar[i].DurumGuncelle(Durum.TeslimEdildi);
                            break;
                        case Durum.TeslimEdildi:
                            break;
                        default:
                            break;  } 
                }
            }
        }




        }
    }

