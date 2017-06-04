namespace MyWebsite.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DON_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DON_HANG()
        {
            DON_HANG_CT = new HashSet<DON_HANG_CT>();
        }

        [Key]
        public int MaDH { get; set; }

        public int MaKH { get; set; }

        public decimal? TongTien { get; set; }

        public DateTime? Ngay { get; set; }

        public bool? TrangThai { get; set; }

        public virtual KHACH_HANG KHACH_HANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DON_HANG_CT> DON_HANG_CT { get; set; }
    }
}
