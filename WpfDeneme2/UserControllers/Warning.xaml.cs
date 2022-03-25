using System;
using System.Collections.Generic;
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
using System.Windows.Threading;
using WpfDeneme2.Classes.Parametreler;

namespace WpfDeneme2.UserControllers
{
    /// <summary>
    /// Interaction logic for Warning.xaml
    /// </summary>
    public partial class Warning : Window
    {
        public Warning()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopArea.Right - this.Width;
            this.Top = desktopArea.Bottom - this.Height;
 
            ErrorWindow();
        }

        private void ErrorWindow()
        {
            if (Parameters.Error == 1)
            {
                imgCautionRed.Visibility = Visibility.Visible;
                imgCautionBlue.Visibility = Visibility.Hidden;
                lblInfoContent.Content = Parameters.InfoContent;
            }
            else
            {
                imgCautionRed.Visibility = Visibility.Hidden;
                imgCautionBlue.Visibility = Visibility.Visible;
                lblInfoContent.Content = Parameters.InfoContent;
                Header.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#77A9B0"));
            }

            DispatcherTimer dispatcherTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(3)
            };

            dispatcherTimer.Tick += delegate (object sender, EventArgs e)
            {
                ((DispatcherTimer)dispatcherTimer).Stop();
                if (this.ShowActivated) this.Close();
            };

            dispatcherTimer.Start();
        }
    }
}
