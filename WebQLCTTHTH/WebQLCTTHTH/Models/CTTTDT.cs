//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebQLCTTHTH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTTTDT
    {
        public int LT { get; set; }
        public int Ma_NTT { get; set; }
        public Nullable<decimal> SoTienTaiTro { get; set; }
        public string HinhThuQuangCao { get; set; }
        public string LoaiQuangCao { get; set; }
    
        public virtual DotThi DotThi { get; set; }
        public virtual NhaTaiTro NhaTaiTro { get; set; }
    }
}
