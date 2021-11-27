using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TblAssetType
    {
        public TblAssetType()
        {
            TblAssetDefinition = new HashSet<TblAssetDefinition>();
            TblAssetMaster = new HashSet<TblAssetMaster>();
            TblPurchaseOrder = new HashSet<TblPurchaseOrder>();
            TblVendor = new HashSet<TblVendor>();
        }

        public int AtId { get; set; }
        public string AtName { get; set; }

        public virtual ICollection<TblAssetDefinition> TblAssetDefinition { get; set; }
        public virtual ICollection<TblAssetMaster> TblAssetMaster { get; set; }
        public virtual ICollection<TblPurchaseOrder> TblPurchaseOrder { get; set; }
        public virtual ICollection<TblVendor> TblVendor { get; set; }
    }
}
