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
    public partial class anaForm: Form
    {
        public anaForm()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            FormCalisan formCalisan = new FormCalisan(); //Kargo çalışanı formunu oluşturuyoruz
            formCalisan.Show(); //Kargo çalışanı formunu gösteriyoruz
            this.Hide(); //Ana formu gizliyoruz

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMusteri formMusteri = new FormMusteri(); //Müşteri formunu oluşturuyoruz
            formMusteri.Show(); //Müşteri formunu gösteriyoruz
            this.Hide(); //Ana formu gizliyoruz
        }

        private void anaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
