using System;
using System.Collections.Generic;

namespace AssetManagmentSystem.Models
{
    public partial class AssetMaster
    {
        public int AmId { get; set; }
        public string AmAtypeId { get; set; }
        public decimal? AmMakeId { get; set; }
        public decimal? AmAdId { get; set; }
        public string AmModel { get; set; }
        public string AmSnumber { get; set; }
        public string AmMyyear { get; set; }
        public DateTime? AmPdate { get; set; }
        public string AmWaranty { get; set; }
        public DateTime? AmForm { get; set; }
        public DateTime? AmTo { get; set; }
    }
}
