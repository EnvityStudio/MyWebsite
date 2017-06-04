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
        [Display(Name = "Tên sản phẩm")]
        public string TenSP { get; set; }
        [Display(Name = "Đơn giá")]
        public int DonGia { get; set; }
        [Display(Name = "Trạng thái")]
        public bool? TrangThai { get; set; }
        [Display(Name = "Nổi bật")]
        public bool? NoiBat { get; set; }

        [StringLength(255)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Chi tiết")]
        public string ChiTiet { get; set; }
        [Display(Name = "Mã danh mục")]
        public int MaDM { get; set; }

        public virtual DANH_MUC DANH_MUC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DON_HANG_CT> DON_HANG_CT { get; set; }
    }
}
