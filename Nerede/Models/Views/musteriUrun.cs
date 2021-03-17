using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nerede.Models.Tables;

namespace Nerede.Models.Views
{
    public class musteriUrun
    {
        public int stokId { get; set; }
        public int stokAdet { get; set; }
        public string urunAdi { get; set; }
        public string kategoriAdi { get; set; }
        public string resimYolu { get; set; }
        public string resimAdi { get; set; }
        public decimal fiyat { get; set; }
        public decimal indirimTutari { get; set; }
        public string dukkanAdi { get; set; }
        public decimal xKoordinat { get; set; }
        public decimal yKoordinat { get; set; }
        public decimal indirimliFiyat { get; set; }
    }
}