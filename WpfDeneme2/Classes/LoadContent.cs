using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfDeneme2.Classes
{
    public class LoadContent
    {
        public static void BookAdd(Grid grd, UserControl userControl)
        {
            //Burada ilk aşamada eğer içerik penceresinin içerisinde zaten başka bir datagrid görüntüleniyorsa bunları temizleyip seçili datagridin gelmesini sağlayacağız. bunun için bir if yazdık.
            if (grd.Children.Count>0)
            {
                grd.Children.Clear();
                grd.Children.Add(userControl);
            }
            else
            {
                grd.Children.Add(userControl);
            }
        }
    }
}
