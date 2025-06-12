using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KargoTakipSistemi
{
    public partial class FormIslemler : Form
    {
        public FormIslemler()
        {
            InitializeComponent();
        }

        KargoCalisani kcc = new KargoCalisani(); //Kargo çalışanı nesnesini oluşturuyoruz




        private void FormIslem_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Yurt İçi"); //Kargo türlerini combobox'a ekliyoruz
            comboBox1.Items.Add("Yurt Dışı");
            kcc.KargolariDosyadanOku();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = kcc.kargolar;
            dataGridView1.Refresh();//Kargo çalışanının kargo listesini dataGridView'a bağlıyoruz


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kargo yeniKargo;
            if (comboBox1.SelectedIndex == 0)
                yeniKargo = new YurtIciKargo(); //Yurt içi kargo seçildiyse yeni bir YurtIciKargo nesnesi oluşturuyoruz
            else if (comboBox1.SelectedIndex == 1)
                yeniKargo = new YurtDisiKargo(); //Yurt dışı kargo seçildiyse yeni bir YurtDisiKargo nesnesi oluşturuyoruz
            else
            {
                MessageBox.Show("Lütfen bir kargo türü seçin!"); //Eğer kargo türü seçilmemişse uyarı mesajı gösteriyoruz
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            yeniKargo.AliciAdi = textBox1.Text; //Alıcı adını textbox'tan alıyoruz
            yeniKargo.GondericiAdi = textBox2.Text; //Gönderici adını textbox'tan alıyoruz
            yeniKargo.Adres = textBox3.Text; //Adres bilgisini textbox'tan alıyoruz
            kcc.KargoEkle(yeniKargo); //Yeni kargoyu kargo çalışanı nesnesine ekliyoruz
            MessageBox.Show("Kargo başarıyla oluşturuldu.Kargo Takip Numarası : " + yeniKargo.KargoTakipNumarasi);
            dataGridView1.DataSource = null; //DataGridView'ın veri kaynağını temizliyoruz
            dataGridView1.DataSource = kcc.kargolar; //Kargo listesini tekrar dataGridView'a bağlıyoruz


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string takipNo = textBox4.Text.Trim(); //Takip numarasını textbox'tan alıyoruz
            if (string.IsNullOrEmpty(takipNo))
            {
                MessageBox.Show("Lütfen takip numarasını giriniz.");
                return;
            }
            Kargo bulunanKargo = kcc.kargolar.FirstOrDefault(k => k.KargoTakipNumarasi == takipNo); //Kargo listesinden takip numarasına göre kargoyu buluyoruz
            if (bulunanKargo != null)
            {
                MessageBox.Show("Alıcı Adı: " + bulunanKargo.AliciAdi + "\n" + "Kargonun Durumu: " + bulunanKargo.GonderiDurumu.ToString()+ "\n"+
                    "Tahmini Teslim Günü: " +bulunanKargo.TeslimSuresi + "\n" + "Ücret: " +bulunanKargo.Ucret);
            }
            else
            {
                MessageBox.Show("Kargo bulunamadı. Lütfen geçerli bir takip numarası giriniz."); //Eğer kargo bulunamazsa uyarı mesajı gösteriyoruz
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string takipNo = textBox4.Text.Trim(); //Takip numarasını textbox'tan alıyoruz
            if (string.IsNullOrEmpty(takipNo))
            {
                MessageBox.Show("Lütfen takip numarasını giriniz.");
                return;
            }
            Kargo bulunanKargo = kcc.kargolar.FirstOrDefault(k => k.KargoTakipNumarasi == takipNo); //Kargo listesinden takip numarasına göre kargoyu buluyoruz
            if (bulunanKargo != null)
            {
                kcc.KargoDurumGuncelle(takipNo); //Kargo durumunu güncelliyoruz
                dataGridView1.DataSource = null; //DataGridView'ın veri kaynağını temizliyoruz
                dataGridView1.DataSource = kcc.kargolar; //Kargo listesini tekrar dataGridView'a bağlıyoruz
                MessageBox.Show("Kargo durumu güncellendi.Yeni Durum : "+bulunanKargo.GonderiDurumu.ToString()); //Başarılı mesajı gösteriyoruz

            }
            else
            {
                MessageBox.Show("Kargo bulunamadı. Lütfen geçerli bir takip numarası giriniz."); //Eğer kargo bulunamazsa uyarı mesajı gösteriyoruz
            }

        }

        private void FormIslemler_FormClosed(object sender, FormClosedEventArgs e)
        {
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            anaForm anaForm = new anaForm(); //Ana form nesnesi oluşturuyoruz
            anaForm.Show(); //Ana formu gösteriyoruz
            this.Close();
        }
    }
}

