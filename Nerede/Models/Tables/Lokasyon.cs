using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nerede.Models.Tables
{
    public class Lokasyon
    {
        public int koordinatId { get; set; }
        public decimal xKoordinat { get; set; }
        public decimal yKoordinat { get; set; }
    }
}