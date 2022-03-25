using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace WpfDeneme2.Classes
{
    public class PopupMaker
    {
        public static void PopupShow(Popup popup)
        {
            //Bunu yazma amacımız şu: Her seferinde info butonuna tıklamadan gerekli ve acil durumlarda popup belirsin ve kaybolsun

            popup.IsOpen = true;

            DispatcherTimer dispatcherTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(5)
            };

            dispatcherTimer.Tick += delegate (object sender, EventArgs e)
            {
                ((DispatcherTimer)dispatcherTimer).Stop();
                if (popup.IsOpen)
                {
                    popup.IsOpen = false;
                }
            };

            dispatcherTimer.Start();
        }
    }
}
