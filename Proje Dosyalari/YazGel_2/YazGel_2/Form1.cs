using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace YazGel_2
{
    public partial class Form1 : Form
    {

        
        MySqlConnection conn = new MySqlConnection("SERVER=LOCALHOST ;DATABASE=yazlab_db ;UID=root ;PASSWORD=123456 ;");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            viewGridData1();
            viewGridData2();
            viewGridData3();
        }

        void viewGridData1()
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from hocalar", conn);

                DataSet ds = new DataSet();

                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }

            catch (Exception x)
            {
                MessageBox.Show(x + "");
            }
        }

        void viewGridData2()
        {
            try
            {
                MySqlDataAdapter da2 = new MySqlDataAdapter("select * from dersler", conn);

                DataSet ds2 = new DataSet();

                da2.Fill(ds2);

                dataGridView2.DataSource = ds2.Tables[0];
            }

            catch (Exception x)
            {
                MessageBox.Show(x + "");
            }
        }
        void viewGridData3()
        {
            try
            {
                MySqlDataAdapter da3 = new MySqlDataAdapter("select * from dersler_2", conn);

                DataSet ds3 = new DataSet();

                da3.Fill(ds3);

                dataGridView3.DataSource = ds3.Tables[0];
            }

            catch (Exception x)
            {
                MessageBox.Show(x + "");
            }


        }
        void clearText1()
        {
            ad.Text = "";
            soyad.Text = "";
            brans.Text = "";
        }

        void clearText2()
        {
            kod.Text = "";
            dersAd.Text = "";
            kredi.Text = "";
        }
        void clearText3()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (ad.Text!="" && soyad.Text!="" && brans.Text!= "")
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(" insert into hocalar(ad_hoca, soyad_hoca, brans_hoca) values('" + ad.Text + "','" + soyad.Text + "','" + brans.Text + "')", conn);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    MessageBox.Show("Kayıt Başarıyla Eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    viewGridData1();

                    clearText1();
                }
                else
                {
                    MessageBox.Show("Lütfen boş yerleri doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

            catch (Exception x)
            {
                MessageBox.Show(x + "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (kod.Text != "" && dersAd.Text != "" && kredi.Text != "")
                {
                    MySqlDataAdapter da2 = new MySqlDataAdapter(" insert into dersler(ders_kodu, ders_ad, ders_kredi) values('" + kod.Text + "','" + dersAd.Text + "','" + kredi.Text + "')", conn);

                    DataSet ds2 = new DataSet();

                    da2.Fill(ds2);

                    MessageBox.Show("Kayıt Başarıyla Eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    viewGridData2();

                    clearText2();   
                }
                else
                {
                    MessageBox.Show("Lütfen boş yerleri doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

            catch (Exception x)
            {
                MessageBox.Show(x + "");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = " delete from hocalar where id_hoca= " + dataGridView1.SelectedRows[0].Cells[0].Value + " ";

                MySqlDataAdapter da = new MySqlDataAdapter(delete, conn);

                DataSet ds = new DataSet();

                da.Fill(ds);

                MessageBox.Show("Kayıt Başarıyla Silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                viewGridData1();

                clearText1();
            }

            catch (Exception x)
            {
                MessageBox.Show(x + "");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = " delete from dersler where id_ders= " + dataGridView2.SelectedRows[0].Cells[0].Value + " ";

                MySqlDataAdapter da2 = new MySqlDataAdapter(delete, conn);

                DataSet ds2 = new DataSet();

                da2.Fill(ds2);

                MessageBox.Show("Kayıt Başarıyla Silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                viewGridData2();

                clearText2();
            }

            catch (Exception x)
            {
                MessageBox.Show(x + "");
            }
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dersSeçimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    MySqlDataAdapter da3 = new MySqlDataAdapter(" insert into dersler_2(ders_kodu, ders_ad, ders_kredi) values('" + textBox3.Text + "','" + textBox2.Text + "','" + textBox1.Text + "')", conn);

                    DataSet ds3 = new DataSet();

                    da3.Fill(ds3);

                    MessageBox.Show("Kayıt Başarıyla Eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    viewGridData3();

                    clearText3();
                }
                else
                {
                    MessageBox.Show("Lütfen boş yerleri doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception x)
            {
                MessageBox.Show(x + "");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = " delete from dersler_2 where id_ders_2= " + dataGridView3.SelectedRows[0].Cells[0].Value + " ";

                MySqlDataAdapter da3 = new MySqlDataAdapter(delete, conn);

                DataSet ds3 = new DataSet();

                da3.Fill(ds3);

                MessageBox.Show("Kayıt Başarıyla Silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                viewGridData3();

                clearText3();
            }

            catch (Exception x)
            {
                MessageBox.Show(x + "");
            }
        }

        
    }
}
