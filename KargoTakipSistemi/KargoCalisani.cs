using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
namespace KargoTakipSistemi
{
    public class KargoCalisani
    {
        public string kullaniciAdi { get; set; } //Kargo çalışanının kullanıcı adı
        public string sifre { get; set; } //Kargo çalışanının şifresi

        public string kargoDosyasi= "kargolar.txt"; //Kargo bilgilerini tutan dosyanın adı
        public string kargoCalisaniDosyasi = "Çalışanlar.txt";//Kargo çalışanı bilgilerini tutan dosyanın adı




      public  List<Kargo> kargolar = new List<Kargo>(); //Kargo listesi oluşturuyoruz.
        List<Kargo> YurtİciKargolar = new List<Kargo>(); //Yurt içi kargo listesi
        List<Kargo> YurtDisiKargolar = new List<Kargo>(); //Yurt dışı kargo listesi
        
        public static List<KargoCalisani> CalisanGetir() { 
        List<KargoCalisani> liste=new List<KargoCalisani>();
            if (File.Exists("Çalışanlar.txt"))
            {
                using(StreamReader sr = new StreamReader("Çalışanlar.txt"))
                {
                    string satir;
                    while ((satir = sr.ReadLine()) != null)
                    {
                        string[] parcalar = satir.Split(';');
                        if (parcalar.Length == 2) //Eğer iki parça varsa
                        {
                            KargoCalisani calisan = new KargoCalisani
                            {
                                kullaniciAdi = parcalar[0],
                                sifre = parcalar[1]
                            };
                            liste.Add(calisan); //Çalışanı listeye ekliyoruz.
                        }
                    }

                }
            }
            return liste; //Çalışan listesini döndürüyoruz.

        }
       


        public void KargolariDosyadanOku()
        {
            kargolar.Clear(); //Önce kargo listesini temizliyoruz.

            if (File.Exists("kargolar.txt"))
            {
                using(StreamReader sr=new StreamReader("kargolar.txt"))
                {
                    string satir;
                    while ((satir = sr.ReadLine()) != null) //Dosyadan satır satır okuyoruz.
                    {
                        string[] parcalar = satir.Split(','); //Satırı virgülle ayırıyoruz.
                        if (parcalar.Length == 8) //Eğer 8 parça varsa
                        {
                            Kargo yeniKargo;
                            if (parcalar[3] == "YurtIci") //Eğer kargo yurtiçi ise
                            {
                                yeniKargo = new YurtIciKargo();
                            }
                            else //Eğer kargo yurtdışı ise
                            {
                                yeniKargo = new YurtDisiKargo();
                            }
                            yeniKargo.KargoTakipNumarasi = parcalar[0];
                            yeniKargo.AliciAdi = parcalar[1];
                            yeniKargo.GondericiAdi = parcalar[2];
                            yeniKargo.Adres = parcalar[4];
                            yeniKargo.GonderiDurumu = (Durum)Enum.Parse(typeof(Durum), parcalar[5]); //Durumu enum tipine çeviriyoruz.
                            yeniKargo.TeslimSuresi = parcalar[6]; //Tahmini teslim süresini alıyoruz.
                            yeniKargo.Ucret = int.Parse(parcalar[7]); //Ücreti int tipine çeviriyoruz.

                            kargolar.Add(yeniKargo); //Yeni kargoyu listeye ekliyoruz.
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Kargo dosyası bulunamadı. Lütfen kargolar.txt dosyasını oluşturun."); //Eğer dosya yoksa uyarı mesajı gösteriyoruz.
            }
        }

        
        


        public void KargoEkle(Kargo Yenikargo)
        {
            Yenikargo.KargoTakipNumarasi= Yenikargo.KodOlustur();//Kargo takip numarasını oluşturuyoruz.
            Yenikargo.GonderiDurumu = Durum.Hazirlaniyor; //Kargonun başlangıç durumu "Hazırlanıyor" olarak ayarlanıyor.
            Yenikargo.Ucret = Yenikargo.ucretHesapla(); //Kargonun ücretini hesaplıyoruz.
            Yenikargo.TeslimSuresi = Yenikargo.teslimSuresiHesapla(); //Kargonun tahmini teslim süresini hesaplıyoruz.

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
                sw.WriteLine(Yenikargo.KargoTakipNumarasi + "," + Yenikargo.AliciAdi + "," + Yenikargo.GondericiAdi + "," + (Yenikargo is YurtIciKargo ? "YurtIci" : "YurtDisi") +","+ Yenikargo.Adres + "," + Yenikargo.GonderiDurumu+
                    ","+Yenikargo.TeslimSuresi+","+Yenikargo.Ucret);

            }
        }

        public void KargoDurumGuncelle(string kargoTakipNumarasi)
        {
            for (int i = 0; i < kargolar.Count; i++)
            {
                if (kargolar[i].KargoTakipNumarasi == kargoTakipNumarasi) //Kargo takip numarasına göre kargoyu buluyoruz.
                {
                    Durum durum = kargolar[i].GonderiDurumu;  //Kargonun durumunu durum değişkenine atıyoruz.
                    switch (durum) //Duruma göre kargonun durumunu güncelliyoruz.
                    {
                        case Durum.Hazirlaniyor:
                            kargolar[i].DurumGuncelle(Durum.YolaCikti);
                            break;
                        case Durum.YolaCikti:
                            kargolar[i].DurumGuncelle(Durum.TeslimEdildi);
                            break;
                        case Durum.TeslimEdildi:
                            break;
                        default:
                            break;  }
                    KargolariDosyayaYaz();

                   
                }
            }
        }
        public void KargolariDosyayaYaz()
        {
            using (StreamWriter sw = new StreamWriter("kargolar.txt", false)) //Kargo bilgilerini dosyaya yazıyoruz.
            {
                foreach (var kargo in kargolar)
                {
                    sw.WriteLine(kargo.KargoTakipNumarasi + "," + kargo.AliciAdi + "," + kargo.GondericiAdi + "," + (kargo is YurtIciKargo ? "YurtIci" : "YurtDisi") + "," + kargo.Adres + "," + kargo.GonderiDurumu +
                        "," + kargo.TeslimSuresi + "," + kargo.Ucret);
                }
            }

        }


        }
    }

