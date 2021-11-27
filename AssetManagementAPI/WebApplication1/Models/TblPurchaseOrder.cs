using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TblPurchaseOrder
    {
        public int PdId { get; set; }
        public string PdOrderNo { get; set; }
        public int? PdAdId { get; set; }
        public int? PdTypeId { get; set; }
        public int? PdQty { get; set; }
        public int? PdVendorId { get; set; }
        public DateTime? PdDate { get; set; }
        public DateTime? PdDdate { get; set; }
        public string PdStatus { get; set; }

        public virtual TblAssetDefinition PdAd { get; set; }
        public virtual TblAssetType PdType { get; set; }
        public virtual TblVendor PdVendor { get; set; }
    }
}
