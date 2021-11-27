using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TblVendor
    {
        public TblVendor()
        {
            TblAssetMaster = new HashSet<TblAssetMaster>();
            TblPurchaseOrder = new HashSet<TblPurchaseOrder>();
        }

        public int VdId { get; set; }
        public string VdName { get; set; }
        public string VdType { get; set; }
        public int? VdAtypeId { get; set; }
        public DateTime? VdFrom { get; set; }
        public DateTime? VdTo { get; set; }
        public string VdAddr { get; set; }

        public virtual TblAssetType VdAtype { get; set; }
        public virtual ICollection<TblAssetMaster> TblAssetMaster { get; set; }
        public virtual ICollection<TblPurchaseOrder> TblPurchaseOrder { get; set; }
    }
}
