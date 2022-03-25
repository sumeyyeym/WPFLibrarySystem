using System.Windows;
using System.Windows.Controls;
using WpfDeneme2.Classes;

namespace WpfDeneme2.UserControllers
{
    /// <summary>
    /// Interaction logic for BookList.xaml
    /// </summary>
    public partial class BookList : UserControl
    {
        public BookList()
        {
            InitializeComponent();

        }

        private void btnAddBook_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BookAdd bookAdd = new BookAdd();
            bookAdd.ShowDialog();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            DbLoader.GridFiller(dgvBooks);
        }

        private void dgvBooks_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("Tık tık!");
        }

   
    }
}
