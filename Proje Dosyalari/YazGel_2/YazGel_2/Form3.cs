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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Yenile();
            Yenile2();

        }
        MySqlConnection conn = new MySqlConnection("SERVER=LOCALHOST ;DATABASE=yazlab_db ;UID=root ;PASSWORD=123456 ;");

        private void Yenile()
        {
            
            string selectQuery = "SELECT hoca_ad_soyad, ders_kod_ad FROM ders_programi";
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, conn))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                
                dataGridView1.DataSource = dataTable;
            }
        }
        void hocaListele()
        {
            try
            {
                conn.Open();
                string sorgu = "SELECT CONCAT(ad_hoca, ' ', soyad_hoca) AS HocaAdSoyad FROM hocalar";
                MySqlCommand cmd = new MySqlCommand(sorgu, conn);
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comboBox1.DisplayMember = "HocaAdSoyad";
                    comboBox1.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        void dersListele()
        {
            try
            {
                conn.Open();
                string sorgu = "SELECT CONCAT(ders_kodu, ' ', ders_ad) AS DersKodAd FROM dersler";
                MySqlCommand cmd = new MySqlCommand(sorgu, conn);
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comboBox2.DisplayMember = "DersKodAd";
                    comboBox2.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        void hocaListele2()
        {
            try
            {
                conn.Open();
                string sorgu = "SELECT CONCAT(ad_hoca, ' ', soyad_hoca) AS HocaAdSoyad FROM hocalar";
                MySqlCommand cmd = new MySqlCommand(sorgu, conn);
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comboBox3.DisplayMember = "HocaAdSoyad";
                    comboBox3.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
        void dersListele2()
        {
            try
            {
                conn.Open();
                string sorgu = "SELECT CONCAT(ders_kodu, ' ', ders_ad) AS DersKodAd FROM dersler_2";
                MySqlCommand cmd = new MySqlCommand(sorgu, conn);
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comboBox4.DisplayMember = "DersKodAd";
                    comboBox4.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void Yenile2()
        {
            
            string selectQuery = "SELECT hoca_ad_soyad, ders_kod_ad FROM ders_programi2";
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, conn))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

               
                dataGridView2.DataSource = dataTable;
            }
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {
            hocaListele();
            hocaListele2();
            dersListele();
            dersListele2();

        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string selectedHocaAdSoyad = comboBox1.Text;
                string selectedDersKodAd = comboBox2.Text;

                
                string checkQuery = "SELECT COUNT(*) FROM ders_programi WHERE hoca_ad_soyad=@hoca_ad_soyad AND ders_kod_ad=@ders_kod_ad";
                using (MySqlCommand cmdCheck = new MySqlCommand(checkQuery, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@hoca_ad_soyad", selectedHocaAdSoyad);
                    cmdCheck.Parameters.AddWithValue("@ders_kod_ad", selectedDersKodAd);

                    int existingRecords = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (existingRecords > 0)
                    {
                        
                        MessageBox.Show("Bu hoca ve ders zaten kayıtlı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                       
                        string insertQuery = "INSERT INTO ders_programi (hoca_ad_soyad, ders_kod_ad) VALUES (@hoca_ad_soyad, @ders_kod_ad)";
                        using (MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@hoca_ad_soyad", selectedHocaAdSoyad);
                            cmdInsert.Parameters.AddWithValue("@ders_kod_ad", selectedDersKodAd);

                            cmdInsert.ExecuteNonQuery();
                        }

                        
                        Yenile();

                        
                        MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Hata: " + ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
               
                conn.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string selectedHocaAdSoyad = dataGridView1.SelectedRows[0].Cells["hoca_ad_soyad"].Value.ToString();
                    string selectedDersKodAd = dataGridView1.SelectedRows[0].Cells["ders_kod_ad"].Value.ToString();

                    string query = "DELETE FROM ders_programi WHERE hoca_ad_soyad=@hoca_ad_soyad AND ders_kod_ad=@ders_kod_ad";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@hoca_ad_soyad", selectedHocaAdSoyad);
                    cmd.Parameters.AddWithValue("@ders_kod_ad", selectedDersKodAd);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Kayıt silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Yenile(); 
                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçin.","Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında bir hata oluştu: "+ ex.Message,"Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string selectedHocaAdSoyad = comboBox3.Text;
                string selectedDersKodAd = comboBox4.Text;

                
                string checkQuery = "SELECT COUNT(*) FROM ders_programi2 WHERE hoca_ad_soyad=@hoca_ad_soyad AND ders_kod_ad=@ders_kod_ad";
                using (MySqlCommand cmdCheck = new MySqlCommand(checkQuery, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@hoca_ad_soyad", selectedHocaAdSoyad);
                    cmdCheck.Parameters.AddWithValue("@ders_kod_ad", selectedDersKodAd);

                    int existingRecords = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (existingRecords > 0)
                    {
                       
                        MessageBox.Show("Bu hoca ve ders zaten kayıtlı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                       
                        string insertQuery = "INSERT INTO ders_programi2 (hoca_ad_soyad, ders_kod_ad) VALUES (@hoca_ad_soyad, @ders_kod_ad)";
                        using (MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@hoca_ad_soyad", selectedHocaAdSoyad);
                            cmdInsert.Parameters.AddWithValue("@ders_kod_ad", selectedDersKodAd);

                            cmdInsert.ExecuteNonQuery();
                        }

                        
                        Yenile2();

                        
                        MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Hata: " + ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView2.SelectedRows.Count > 0)
                {
                    string selectedHocaAdSoyad = dataGridView2.SelectedRows[0].Cells["hoca_ad_soyad"].Value.ToString();
                    string selectedDersKodAd = dataGridView2.SelectedRows[0].Cells["ders_kod_ad"].Value.ToString();

                    string query = "DELETE FROM ders_programi2 WHERE hoca_ad_soyad=@hoca_ad_soyad AND ders_kod_ad=@ders_kod_ad";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@hoca_ad_soyad", selectedHocaAdSoyad);
                    cmd.Parameters.AddWithValue("@ders_kod_ad", selectedDersKodAd);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Kayıt silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Yenile2();
                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
            
        }
    }

