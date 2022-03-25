using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDeneme2.Classes.Parametreler
{
    public class Parameters
    {
        #region Static Parameters
        public static sbyte Error;
        public static string InfoContent;
        public static string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
        public static string ImageName;
        public static string BookName;
        #endregion

        #region Book Add Parameters
        private string _kitapAdi;
        private string _yazarAdiSoyadi;
        private string _yayinEvi;
        private string _baskiTarihi;
        private string _kitapTuru;
        private string _sayfaSayisi;
        private string _kitapKonusu;
        private string _resim;

        private int _yayinEviId;
        private int _yazarAdiId;

        private bool _emanetDurumu;

        public string KitapAdi { get => _kitapAdi; set => _kitapAdi = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); }
        public string YazarAdiSoyadi { get => _yazarAdiSoyadi; set => _yazarAdiSoyadi = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); }
        public string YayinEvi { get => _yayinEvi; set => _yayinEvi = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); }
        public string BaskiTarihi { get => _baskiTarihi; set => _baskiTarihi = value; }
        public string KitapTuru { get => _kitapTuru; set => _kitapTuru = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); }
        public string SayfaSayisi { get => _sayfaSayisi; set => _sayfaSayisi = value; }
        public string KitapKonusu { get => _kitapKonusu; set => _kitapKonusu = value; }
        public string Resim { get => _resim; set => _resim = value; }

        public int YayinEviId { get => _yayinEviId; set => _yayinEviId = value; }
        public int YazarAdiId { get => _yazarAdiId; set => _yazarAdiId = value; }
        public bool EmanetDurumu { get => _emanetDurumu; set => _emanetDurumu = value; }
        #endregion
    }
}
