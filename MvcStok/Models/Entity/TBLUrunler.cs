//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//TBLKAtegoriler
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLUrunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLUrunler()
        {
            this.TBLSatıslar = new HashSet<TBLSatıslar>();
        }
    
        public int UrunID { get; set; }

        public string UrunAd { get; set; }
        public string Marka { get; set; }
        public Nullable<int> UrunKategori { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public Nullable<byte> Stok { get; set; }
    
        public virtual TBLKAtegoriler TBLKAtegoriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSatıslar> TBLSatıslar { get; set; }
    }
}