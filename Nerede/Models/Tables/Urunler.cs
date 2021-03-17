using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nerede.Models.Tables
{
    public class Urunler
    {
        public int urunId { get; set; }
        public string urunAdi { get; set; }
        public int kategoriId { get; set; }
        public int resimId { get; set; }
        public string urunAciklama { get; set; }
        public string urunDurum { get; set; }
    }
}