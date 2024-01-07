using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace YazGel_2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();


        }
        private void Form4_Load(object sender, EventArgs e)
        {
            tabloOlustur();
            tabloOlustur2();
            dersleriEkle();
            dersleriEkle2();
            otomatikBoyutlandir();
            otomatikBoyutlandir2();
           
        }
        
        private void otomatikBoyutlandir()
        {
            
            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -1; 
            }

            
            foreach (ListViewItem item in listView1.Items)
            {
                item.UseItemStyleForSubItems = false; 
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    
                    subItem.Text = subItem.Text; 
                }
            }
        }
        private void otomatikBoyutlandir2()
        {
            
            foreach (ColumnHeader column in listView2.Columns)
            {
                column.Width = -1; 
            }

            
            foreach (ListViewItem item in listView2.Items)
            {
                item.UseItemStyleForSubItems = false; 
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    
                    subItem.Text = subItem.Text; 
                }
            }
        }


        MySqlConnection conn = new MySqlConnection("SERVER=LOCALHOST ;DATABASE=yazlab_db ;UID=root ;PASSWORD=123456 ;");

        Dictionary<string, string> atananDersler = new Dictionary<string, string>();

        void tabloOlustur()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;

            
            listView1.Columns.Add("Saat/Gün", 100);
            listView1.Columns.Add("Pazartesi", 100);
            listView1.Columns.Add("Salı", 100);
            listView1.Columns.Add("Çarşamba", 100);
            listView1.Columns.Add("Perşembe", 100);
            listView1.Columns.Add("Cuma", 100);

            
            for (int saat = 8; saat <= 15; saat++)
            {
                string[] row = new string[6];
                row[0] = String.Format("{0:00}:00 - {1:00}:00", saat, saat + 1);

                row[1] = "";
                row[2] = "";
                row[3] = "";
                row[4] = "";
                row[5] = "";

                ListViewItem item = new ListViewItem(row);

                listView1.Items.Add(item);
            }
        }
        void tabloOlustur2()
        {
            listView2.View = View.Details;
            listView2.GridLines = true;

            
            listView2.Columns.Add("Saat/Gün", 100);
            listView2.Columns.Add("Pazartesi", 100);
            listView2.Columns.Add("Salı", 100);
            listView2.Columns.Add("Çarşamba", 100);
            listView2.Columns.Add("Perşembe", 100);
            listView2.Columns.Add("Cuma", 100);

           
            for (int saat = 8; saat <= 15; saat++)
            {
                string[] row = new string[6];
                row[0] = String.Format("{0:00}:00 - {1:00}:00", saat, saat + 1);

                row[1] = "";
                row[2] = "";
                row[3] = "";
                row[4] = "";
                row[5] = "";

                ListViewItem item = new ListViewItem(row);

                listView2.Items.Add(item);
            }
        }
        
        private List<string> siniflar = new List<string> { "1036", "1040", "1041", "1044" };

        private void dersleriEkle()
        {
            try
            {
                conn.Open();
                string query = "SELECT hoca_ad_soyad, ders_kod_ad FROM ders_programi";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                string saatGunKey = "";

                while (reader.Read())
                {
                    string hocaAdSoyad = reader["hoca_ad_soyad"].ToString();
                    string dersKodAd = reader["ders_kod_ad"].ToString();

                    
                    Random random = new Random();
                    int saat = random.Next(8, 16); 
                    int gun = random.Next(1, 6);   

                    saatGunKey = string.Format("{0:00}:00-{1}", saat, gun);

                    
                    while (atananDersler.ContainsKey(saatGunKey))
                    {
                        saat = random.Next(8, 16);
                        gun = random.Next(1, 6);
                        saatGunKey = string.Format("{0:00}:00-{1}", saat, gun);
                    }

                    
                    string sinif = siniflar[random.Next(siniflar.Count)];

                    atananDersler.Add(saatGunKey, string.Format("{0} - {1} ({2})", hocaAdSoyad, dersKodAd, sinif));

                    
                    listView1.Items[saat - 8].SubItems[gun].Text = string.Format("{0} - {1} ({2})", hocaAdSoyad, dersKodAd, sinif);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void dersleriEkle2()
        {
            try
            {
                conn.Open();
                string query = "SELECT hoca_ad_soyad, ders_kod_ad FROM ders_programi2";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                string saatGunKey = "";

                while (reader.Read())
                {
                    string hocaAdSoyad = reader["hoca_ad_soyad"].ToString();
                    string dersKodAd = reader["ders_kod_ad"].ToString();

                    
                    Random random = new Random();
                    int saat = random.Next(8, 16); 
                    int gun = random.Next(1, 6);   

                    saatGunKey = string.Format("{0:00}:00-{1}", saat, gun);

                    
                    while (atananDersler.ContainsKey(saatGunKey))
                    {
                        saat = random.Next(8, 16);
                        gun = random.Next(1, 6);
                        saatGunKey = string.Format("{0:00}:00-{1}", saat, gun);
                    }

                    
                    string sinif = siniflar[random.Next(siniflar.Count)];

                    atananDersler.Add(saatGunKey, string.Format("{0} - {1} ({2})", hocaAdSoyad, dersKodAd, sinif));

                    listView2.Items[saat - 8].SubItems[gun].Text = string.Format("{0} - {1} ({2})", hocaAdSoyad, dersKodAd, sinif);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void ExportListViewToExcel(ListView listView, string sheetName)
        {
            if (listView.Items.Count == 0)
            {
                MessageBox.Show("ListView boş. Veri yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Sheets[1];

                
                worksheet.Name = sheetName;

               
                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = listView.Columns[i].Text;
                }

            
                for (int i = 0; i < listView.Items.Count; i++)
                {
                    for (int j = 0; j < listView.Items[i].SubItems.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = listView.Items[i].SubItems[j].Text;
                    }
                }

                
                worksheet.UsedRange.Columns.AutoFit();

                excelApp.Visible = true;
                excelApp.UserControl = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel'e veri aktarılırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            ExportListViewToExcel(listView1, "2.Sınıf"); //Excele aktarma işlemleri için gpt den yardım alındı.
            ExportListViewToExcel(listView2, "1.Sınıf"); 

           
        }

    }
}