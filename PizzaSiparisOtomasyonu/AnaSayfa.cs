using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaSiparisOtomasyonu
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }
        public string Ekstralar;

        //Projede istenilen metot
        public int SiparisTutariHesapla(int PizzaBoyu, int PizzaAdeti, int Icecek, int IcecekAdeti, int Ekstra)
        {         
            return PizzaBoyu * PizzaAdeti + Icecek * IcecekAdeti + Ekstra;
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            listView2.Visible = false;

            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;

            //Pizzanın büyüklüğünü seçmemizi sağlar
            
            comboBox1.Items.Add("Küçük Boy - 20₺");
            comboBox1.Items.Add("Orta Boy - 25₺");
            comboBox1.Items.Add("Büyük Boy - 30₺");

            //İçecek kısmı için seçmemizi sağlar
            
            comboBox2.Items.Add("Kutu Coca Cola - 5₺");
            comboBox2.Items.Add("Kutu Fanta - 5₺");
            comboBox2.Items.Add("Kutu Ice Tea - 5₺");
            comboBox2.Items.Add("Ayran(250 ml) - 4₺");
            comboBox2.Items.Add("Ayran(400 ml) - 5₺");
            comboBox2.Items.Add("Ayran(1 lt) - 10₺");
            comboBox2.Items.Add("1 Litre Coca Cola - 12₺");
            comboBox2.Items.Add("1 Litre Fanta - 12₺");
            comboBox2.Items.Add("1 Litre Ice Tea - 12₺");




            //listview için başlıklar
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Adı Soyadı", 126);
            listView1.Columns.Add("Telefon", 150);
            listView1.Columns.Add("Adres", 170);
            listView1.Columns.Add("Pizza Boyu ve Adet", 140);
            listView1.Columns.Add("İçecek Boyu ve Adet", 130);
            listView1.Columns.Add("Ekstralar", 100);
            listView1.Columns.Add("Toplam Tutar", 100);
            listView1.Columns.Add("Sipariş Tarihi", 110);
            timer1.Enabled = true;

            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.Columns.Add("Adı Soyadı", 126);
            listView2.Columns.Add("Telefon", 150);
            listView2.Columns.Add("Adres", 170);
            listView2.Columns.Add("Pizza Boyu ve Adet", 140);
            listView2.Columns.Add("İçecek Boyu ve Adet", 130);
            listView2.Columns.Add("Ekstralar", 100);
            listView2.Columns.Add("Toplam Tutar", 100);
            listView2.Columns.Add("Sipariş Tarihi", 110);



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToLongTimeString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            int comboboxPizzaBoyu;
            int comboboxIcecek;
            int EkstraToplamTutar = 0;
            string AdSoyad;
            string TelefonNo;
            string Adres;           
            string PizzaBoyuAdet;
            string IcecekAdet;
            int Tutar;
            string tarih = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            

            //ekstraların fiyatını belirler
            if (checkBox1.Checked == true)
                EkstraToplamTutar += 3;

            if (checkBox2.Checked == true)
                EkstraToplamTutar += 3;

            if (checkBox3.Checked == true)
                EkstraToplamTutar += 3;

            if (checkBox4.Checked == true)
                EkstraToplamTutar += 3;

            if (checkBox5.Checked == true)
                EkstraToplamTutar += 3;

            if (checkBox6.Checked == true)
                EkstraToplamTutar += 3;


            
            if (textBox1.Text=="" || textBox2.Text == "" ||maskedTextBox1.Text == "")
            {
                MessageBox.Show("Lütfen Müşteri Bilgilerini Doldurunuz!!");
                return;
            }

            if (comboBox1.SelectedIndex ==-1)
            {
                MessageBox.Show("Lütfen Pizzanın Boyutunu Seçiniz!!");
                return;

            }

           
            //hangi pizza seçilecek onu belirler
            if (comboBox1.SelectedItem.ToString() == "Küçük Boy - 20₺")
                comboboxPizzaBoyu = 20;

            else if (comboBox1.SelectedItem.ToString() == "Orta Boy - 25₺")
                comboboxPizzaBoyu = 25;

            else
                comboboxPizzaBoyu = 30;




            //içecek seçilmemişse içeceğe 0 atar seçilmişse içeceği belirleyip fiyatını comboboxaIcecek'e çeker
            if (comboBox2.SelectedIndex == -1)
            {
                comboboxIcecek = 0;
            }
            else
            {
                if (comboBox2.SelectedItem.ToString() == "Kutu Coca Cola - 5₺" || comboBox2.SelectedItem.ToString() == "Kutu Fanta - 5₺" || comboBox2.SelectedItem.ToString() == "Kutu Ice Tea - 5₺" || comboBox2.SelectedItem.ToString() == "Ayran(400 ml) - 5₺")
                    comboboxIcecek = 5;

                else if (comboBox2.SelectedItem.ToString() == "Ayran(250 ml) - 4₺")
                    comboboxIcecek = 4;

                else if (comboBox2.SelectedItem.ToString() == "Ayran(1 lt) - 10₺")
                    comboboxIcecek = 10;

                else if (comboBox2.SelectedItem.ToString() == "1 Litre Coca Cola - 12₺" || comboBox2.SelectedItem.ToString() == "1 Litre Fanta - 12₺")
                    comboboxIcecek = 12;
                else
                    comboboxIcecek = 12;
            }



           
            


            //metotu çağırıp tutara aktarır
            Tutar = SiparisTutariHesapla(comboboxPizzaBoyu, Convert.ToInt16(numericUpDown1.Value), comboboxIcecek, Convert.ToInt16(numericUpDown2.Value), EkstraToplamTutar);
            MessageBox.Show("Toplam Ödenmesi Gereken Tutar: " + Tutar + "₺");
            listView2.Visible = false;
            listView1.Visible = true;

            //textboxları listviewe aktarmak için ilgili yerlere aktarma işlemi 
            AdSoyad = textBox1.Text;
            TelefonNo = maskedTextBox1.Text;
            Adres = textBox2.Text;
            PizzaBoyuAdet = comboBox1.Text;
            IcecekAdet = comboBox2.Text;
            if(EkstraToplamTutar !=0)
                Ekstralar = Ekstralar.Substring(0, Ekstralar.Length - 1);

            

            //listview aktarma işlemi
            string[] ListViewAktarma = { AdSoyad , TelefonNo , Adres , PizzaBoyuAdet , IcecekAdet , Ekstralar , Convert.ToString(Tutar) + "₺"  , tarih };
            listView1.Items.Add(new ListViewItem(ListViewAktarma));


        }

        //listview için ekstralar kısmına aktarmak için tek tek bütün checkboxları kontrol eder
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                Ekstralar = Ekstralar + checkBox1.Text + ",";           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                Ekstralar = Ekstralar + checkBox2.Text + ",";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
                Ekstralar = Ekstralar + checkBox3.Text + ",";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
                Ekstralar = Ekstralar + checkBox4.Text + ",";
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
                Ekstralar = Ekstralar + checkBox5.Text + ",";
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
                Ekstralar = Ekstralar + checkBox6.Text + ",";
        }



        //temizle tuşuna basınca her şeyi temizler
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            maskedTextBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedItem = null;          
            comboBox2.SelectedItem = null;          
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            listView1.Visible = false;
            listView2.Visible = true;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //yapılan tüm siparişleri getirir
        private void button3_Click(object sender, EventArgs e)
        {
            listView2.Visible = false;
            listView1.Visible = true;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
