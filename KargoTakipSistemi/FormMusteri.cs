using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KargoTakipSistemi
{
    public partial class FormMusteri: Form
    {
        
        public FormMusteri()
        {
            InitializeComponent();
          
        }


       





        private void FormMusteri_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string takipNo = textBox1.Text; //Kargo takip numarasını alıyoruz
            if (string.IsNullOrEmpty(takipNo))
            {
                MessageBox.Show("Lütfen takip numarasını giriniz.");

                return;
            }
            using(StreamReader sr=new StreamReader("kargolar.txt"))
            {
                string satir;
                bool bulundu = false; //Kargo bulunup bulunmadığını kontrol etmek için bir değişken
                while ((satir = sr.ReadLine()) != null) //Dosyadan satır satır okuyoruz
                {
                    string[] parcalar = satir.Split(','); //Satırı virgülle ayırıyoruz
                    if (parcalar[0] == takipNo) //Eğer takip numarası eşleşiyorsa
                    {
                       label9.Text=parcalar[1]; //Alıcı adını label9'a yazıyoruz
                        label10.Text = parcalar[2]; //Gönderici adını label10'a yazıyoruz
                        label12.Text = parcalar[4]; //Adres bilgisini label11'e yazıyoruz
                         label13.Text = parcalar[5]; //Durumu label12'ye yazıyoruz
                        label14.Text = parcalar[6]; //Tahmini teslim süresini label13'e yazıyoruz
                        label15.Text = parcalar[7]+" TL"; //Ücreti label14'e yazıyoruz
                        bulundu = true; //Kargo bulundu olarak işaretliyoruz
                        break; //Döngüden çıkıyoruz
                    }
                }
                if (!bulundu) //Eğer kargo bulunamadıysa
                {
                    MessageBox.Show("Kargo bulunamadı. Lütfen takip numarasını kontrol ediniz.");
                }
            }


        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            anaForm anaForm = new anaForm(); //Ana form nesnesi oluşturuyoruz
            anaForm.Show(); //Ana formu gösteriyoruz
            this.Close();
        }
    }
}
