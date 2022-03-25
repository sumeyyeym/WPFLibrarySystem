using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WpfDeneme2.Classes;
using WpfDeneme2.UserControllers;

namespace WpfDeneme2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadContent.BookAdd(contentWindow, new BookList());

            DbConnect.DbConnectionTest();
            lblDataBase.Content = DbConnect.DbState;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void brdSolUst_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void brdSagUst_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }


        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                grdMainGrid.Margin = new Thickness(0);
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnHamburger_Click(object sender, RoutedEventArgs e)
        {
            if (imgAdd.Width != 60)
            {
                GridLength length = new GridLength(80, GridUnitType.Pixel);
                grdMainGridColumn0.Width = length;

                imgAdd.Width = 60;

                lblLibrary.Width = 0;
                lblAuthors.Visibility = Visibility.Hidden;
                lblBookList.Visibility = Visibility.Hidden;
                lblDepositList.Visibility = Visibility.Hidden;
                lblGonnaRead.Visibility = Visibility.Hidden;
                lblReaded.Visibility = Visibility.Hidden;
                lblSettings.Visibility = Visibility.Hidden;
                lblDataBase.Visibility = Visibility.Hidden;

            }
            else
            {
                GridLength length = new GridLength(200, GridUnitType.Pixel);
                grdMainGridColumn0.Width = length;

                lblLibrary.Width = 100;
                lblAuthors.Visibility = Visibility.Visible;
                lblBookList.Visibility = Visibility.Visible;
                lblDepositList.Visibility = Visibility.Visible;
                lblGonnaRead.Visibility = Visibility.Visible;
                lblReaded.Visibility = Visibility.Visible;
                lblSettings.Visibility = Visibility.Visible;
                lblDataBase.Visibility = Visibility.Visible;

                imgAdd.Width = 90;
            }

        }

        #region menubuttons

        int checkState;

        private void btnBookList_Click(object sender, RoutedEventArgs e)
        {
            checkState = 1;
            CheckState();
            LoadContent.BookAdd(contentWindow, new BookList());
        }

        private void btnAuthors_Click(object sender, RoutedEventArgs e)
        {
            checkState = 2;
            CheckState();

        }
        private void btnReaded_Click(object sender, RoutedEventArgs e)
        {
            checkState = 3;
            CheckState();

        }

        private void btnGonnaRead_Click(object sender, RoutedEventArgs e)
        {
            checkState = 4;
            CheckState();

        }

        private void btnDepositList_Click(object sender, RoutedEventArgs e)
        {
            checkState = 5;
            CheckState();

        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            checkState = 6;
            CheckState();

        }

        void CheckState()
        {
            if (checkState==1)
            {
                btnBookList.IsChecked = true;
            }
            else
            {
                btnBookList.IsChecked = false;
            }

            if (checkState == 2)
            {
                btnAuthors.IsChecked = true;
            }
            else
            {
                btnAuthors.IsChecked = false;
            }

            if (checkState == 3)
            {
                btnReaded.IsChecked = true;
            }
            else
            {
                btnReaded.IsChecked = false;
            }

            if (checkState == 4)
            {
                btnGonnaRead.IsChecked = true;
            }
            else
            {
                btnGonnaRead.IsChecked = false;
            }

            if (checkState == 5)
            {
                btnDepositList.IsChecked = true;
            }
            else
            {
                btnDepositList.IsChecked = false;
            }

            if (checkState == 6)
            {
                btnSettings.IsChecked = true;
            }
            else
            {
                btnSettings.IsChecked = false;
            }
        }
        #endregion
    }
}
