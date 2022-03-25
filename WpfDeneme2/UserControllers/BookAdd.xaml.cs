using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfDeneme2.Classes;
using WpfDeneme2.Classes.Parametreler;

namespace WpfDeneme2.UserControllers
{
    /// <summary>
    /// Interaction logic for BookAdd.xaml
    /// </summary>
    public partial class BookAdd : Window
    {
        public BookAdd()
        {
            InitializeComponent();
            ComboboxFillerAuthors();
            ComboboxFillerPublishers();
        }

        void ComboboxFillerAuthors()
        {
            SQLiteConnection connection = new SQLiteConnection(DbConnect.DbAddress);

            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("select * from tbl_Yazarlar", connection);
                //command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    string name = reader.GetString(1); //Hangi sütunu istiyosak onun index nosunu giricez
                    cbxAuthorName.Items.Add(name);
                }

                connection.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }

        void ComboboxFillerPublishers()
        {
            SQLiteConnection connection = new SQLiteConnection(DbConnect.DbAddress);

            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("select * from tbl_YayinEvleri", connection);
                //command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string publisher = reader.GetString(1); //Hangi sütunu istiyosak onun index nosunu giricez
                    cbxPublisher.Items.Add(publisher);
                }

                connection.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        sbyte isImageSelected = 0;

        private void tbxPageCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            } //Bu kod sayesinde textboxa harf girmek mümkün olmuyor. yalnızca sayı.
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            PopupMaker.PopupShow(popupInfo);
        }


        private void imgBookAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tbxBookName.Text != "" && cbxAuthorName.Text != "" && tbxPageCount.Text != "")
            {
                Parameters data = new Parameters();

                Parameters.BookName = tbxBookName.Text;
                data.BaskiTarihi = dpDate.Text;
                data.KitapAdi = tbxBookName.Text;
                data.KitapKonusu = tbxSummary.Text;
                data.KitapTuru = tbxBookType.Text;
                data.SayfaSayisi = tbxPageCount.Text;
                data.YayinEvi = cbxPublisher.Text;
                data.YazarAdiSoyadi = cbxAuthorName.Text;

                if (isImageSelected == 1)
                {
                    data.Resim = Parameters.ImageName;
                }
                else
                {
                    data.Resim = Environment.CurrentDirectory + "\\items\\imageadd.png";
                }


                //burası sonradan değişecek
                data.YayinEviId = 1;
                data.YazarAdiId = 1;

                if (DbLoader.IsAdded(data))
                {
                    Warning warning = new Warning();

                    Parameters.Error = 0;
                    Parameters.InfoContent = "Ekleme işlemi başarılı şekilde gerçekleşti.";

                    warning.Show();
                }
            }
            else
            {
                Warning warning = new Warning();

                Parameters.Error = 1;
                Parameters.InfoContent = "Lütfen zorunlu alanları doldurunuz.\n - Kitap Adı\n - Yazar Adı\n - Sayfa Sayısı";

                warning.Show();
            }
        }


        string selectedImage;
        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Directory.Exists(Parameters.MyDocuments + "\\Kutuphanem\\Resimler"))
                {
                    Directory.CreateDirectory(Parameters.MyDocuments + "\\Kutuphanem\\Resimler");
                }

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Resim Seç";
                dialog.InitialDirectory = "";
                dialog.Filter = "Image Files (*.jpg, *.jpeg)|*.jpg; *.jpeg| PNG Files (*.png)|*.png| JPG Files (*.jpg)|*.jpg";
                dialog.FilterIndex = 1;

                if ((bool)dialog.ShowDialog())
                {
                    selectedImage = dialog.FileName;
                    DateTime dateTime = DateTime.Now;
                    string format = "dd-MM-yyyy_hh-mm-ss";
                    Parameters.ImageName = Parameters.MyDocuments + "\\Kutuphanem\\Resimler\\" + Parameters.BookName + dateTime.ToString(format) + ".jpg  "; //Burada verilen formatta kaydedilecek seçilen resmin adı. Bu saydede ilgili dosya yolunda seçilen resmin kopyaso oluşturulacak.

                    File.Copy(selectedImage, Parameters.ImageName, true);

                    //bu kısım dosyadaki resmin uygulama ekranında görünmesini sağlıyor
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(@"" + Parameters.ImageName);
                    image.EndInit();
                    imgImage.Source = image;

                    Warning warning = new Warning();
                    Parameters.Error = 0;
                    Parameters.InfoContent = "Resim ekleme işlemi başarılı şekilde gerçekleşti.";
                    warning.Show();

                    isImageSelected = 1;
                }
                else
                {
                    Warning warning = new Warning();
                    Parameters.Error = 1;
                    Parameters.InfoContent = "Resim ekleme işlemi başarısız.";
                    warning.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
