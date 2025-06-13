using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KargoTakipSistemi
{
    public partial class FormCalisan : Form
    {
        public FormCalisan()
        {
            InitializeComponent();
        }
        List<KargoCalisani> Calisanlar = KargoCalisani.CalisanGetir();  //Kargo çalışanlarını getiriyoruz
        bool girisYapildi = false; //Giriş yapılıp yapılmadığını kontrol etmek için bir değişken tanımlıyoruz

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text; //Kullanıcı adını alıyoruz
            string sifre = textBox2.Text; //Şifreyi alıyoruz
            if(string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre)) //Eğer kullanıcı adı veya şifre boşsa
            {
                MessageBox.Show("Lütfen kullanıcı adınızı ve şifrenizi giriniz!"); //Uyarı mesajı gösteriyoruz
                return; //Fonksiyondan çıkıyoruz
            }


            foreach (var calisan in Calisanlar )
            {
                if (calisan.kullaniciAdi == kullaniciAdi && calisan.sifre == sifre) //Kullanıcı adı ve şifre eşleşiyorsa
                {
                    girisYapildi = true;
                    break; //Döngüden çıkıyoruz
                }
               

            }
            if (girisYapildi) //Eğer giriş yapıldıysa
            {

                FormIslemler formIslem = new FormIslemler(); //Yeni bir işlem formu oluşturuyoruz
                formIslem.Show(); //İşlem formunu gösteriyoruz
                this.Hide(); //Mevcut formu gizliyoruz

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı!");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anaForm anaForm = new anaForm(); //Ana form nesnesi oluşturuyoruz
            anaForm.Show(); //Ana formu gösteriyoruz
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
