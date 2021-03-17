using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nerede.Models.Tables;

namespace Nerede.Models.Views
{
    public class urunListesi
    {
        public int urunId { get; set; }
        public string urunAdi { get; set; }
        public string urunDurum { get; set; }
        public string resimYolu { get; set; }
        public string resimAdi { get; set; }
        public string kategoriAdi { get; set; }
    }
}