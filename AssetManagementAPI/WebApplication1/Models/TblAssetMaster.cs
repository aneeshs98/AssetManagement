using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TblAssetMaster
    {
        public int AmId { get; set; }
        public int? AmAtypeId { get; set; }
        public int? AmMakeId { get; set; }
        public int? AmAdId { get; set; }
        public string AmModel { get; set; }
        public string AmSnumber { get; set; }
        public string AmMyyear { get; set; }
        public DateTime? AmPdate { get; set; }
        public string AmWarranty { get; set; }
        public DateTime? AmFrom { get; set; }
        public DateTime? AmTo { get; set; }

        public virtual TblAssetDefinition AmAd { get; set; }
        public virtual TblAssetType AmAtype { get; set; }
        public virtual TblVendor AmMake { get; set; }
    }
}
