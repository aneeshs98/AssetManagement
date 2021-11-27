using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TblAssetDefinition
    {
        public TblAssetDefinition()
        {
            TblAssetMaster = new HashSet<TblAssetMaster>();
            TblPurchaseOrder = new HashSet<TblPurchaseOrder>();
        }

        public int AdId { get; set; }
        public string AdName { get; set; }
        public int? AdTypeId { get; set; }
        public string AdClass { get; set; }

        public virtual TblAssetType AdType { get; set; }
        public virtual ICollection<TblAssetMaster> TblAssetMaster { get; set; }
        public virtual ICollection<TblPurchaseOrder> TblPurchaseOrder { get; set; }
    }
}
