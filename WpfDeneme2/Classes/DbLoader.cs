using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfDeneme2.Classes.Parametreler;

namespace WpfDeneme2.Classes
{
    public class DbLoader
    {

        //Datagrid doldurma metodu
        public static bool GridFiller(DataGrid grid)
        {
            sbyte i = 0;
            string sqlCommand = "Select tbl_KitapListesi.ID, tbl_KitapListesi.KitapAdi, tbl_Yazarlar.AdiSoyadi, tbl_KitapListesi.SayfaSayisi, tbl_KitapListesi.KitapTuru, tbl_KitapListesi.BaskiTarihi, tbl_YayinEvleri.YayinEviAdi, tbl_KitapListesi.KitapKonusu, tbl_KitapListesi.Resim, tbl_KitapListesi.EmanetDurumu From tbl_KitapListesi Inner Join tbl_YayinEvleri On tbl_YayinEvleri.ID = tbl_KitapListesi.YayınEviID Inner Join tbl_Yazarlar On tbl_Yazarlar.ID = tbl_KitapListesi.YazarAdiID";
            //string sqlCom = "select * from tbl_KitapListesi";

            SQLiteConnection connection = new SQLiteConnection(DbConnect.DbAddress);
            SQLiteCommand command = new SQLiteCommand(sqlCommand, connection);

            try
            {
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                grid.ItemsSource = null;
                grid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Dispose();
            }
            if (i > 0) return true; else return false;
        }

        //veri ekleme işlemi. ekleme durumuna göre true ya da false dönecek
        public static bool IsAdded(Parameters data)
        {
            sbyte i = 0;

            SQLiteConnection connection = new SQLiteConnection(DbConnect.DbAddress);
            SQLiteCommand command = new SQLiteCommand("Insert into tbl_KitapListesi (KitapAdi, SayfaSayisi, KitapTuru, BaskiTarihi, KitapKonusu, Resim, EmanetDurumu, YayınEviID, YazarAdiID) values (@KitapAdi, @SayfaSayisi, @KitapTuru, @BaskiTarihi, @KitapKonusu, @Resim, @EmanetDurumu, @YayınEviID, @YazarAdiID)", connection);

            command.Parameters.AddWithValue("@KitapAdi", data.KitapAdi);
            command.Parameters.AddWithValue("@SayfaSayisi", data.SayfaSayisi);
            command.Parameters.AddWithValue("@KitapTuru", data.KitapTuru);
            command.Parameters.AddWithValue("@BaskiTarihi", data.BaskiTarihi);
            command.Parameters.AddWithValue("@KitapKonusu", data.KitapKonusu);
            command.Parameters.AddWithValue("@Resim", data.Resim);
            command.Parameters.AddWithValue("@EmanetDurumu", data.EmanetDurumu);
            command.Parameters.AddWithValue("@YayınEviID", data.YayinEviId);
            command.Parameters.AddWithValue("@YazarAdiID", data.YazarAdiId);


            try
            {
                connection.Open();
                i = (sbyte)command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Dispose();
            }

            if (i > 0) return true; else return false;
        }
    }
}
