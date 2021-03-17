using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nerede.Models.Tables
{
    public class Stok
    {
        public int stokId { get; set; }
        public int urunId { get; set; }
        public int stokAdet { get; set; }
        public decimal fiyat { get; set; }
        public int indirimTutari { get; set; }
        public int dukkanId { get; set; }

    }
}