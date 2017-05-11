namespace MyWebsite.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SAN_PHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SAN_PHAM()
        {
            DON_HANG_CT = new HashSet<DON_HANG_CT>();
        }

        [Key]
        public int MaSP { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSP { get; set; }

        public int DonGia { get; set; }

        public bool? TrangThai { get; set; }

        public bool? NoiBat { get; set; }

        [Required]
        [StringLength(255)]
        public string HinhAnh { get; set; }

        [Required]
        [StringLength(255)]
        public string MoTa { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string ChiTiet { get; set; }

        public int MaDM { get; set; }

        public virtual DANH_MUC DANH_MUC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DON_HANG_CT> DON_HANG_CT { get; set; }
    }
}
