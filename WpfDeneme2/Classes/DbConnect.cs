using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDeneme2.Classes
{
    public class DbConnect
    {
        public static string DbAddress = @"Data Source=" + Environment.CurrentDirectory + "\\DB\\kitap.db;Version=3;New=False;Compress=True;Read Only=False";
        public static string DbState;

        public static void DbConnectionTest()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DbAddress))
            {
                if (connection.State == ConnectionState.Closed) //bağlantı durumu kapalıysa
                {
                    try
                    {
                        connection.Open();
                        DbState = "Veri tabanına bağlantı gerçekleşti";
                    }
                    catch (Exception)
                    {
                        DbState = "Bağlantı hatası!";
                    }
                }
                else
                {
                    DbState = "Veri tabanına bağlantı gerçekleşti"; 
                }
            }
        }
    }
}
