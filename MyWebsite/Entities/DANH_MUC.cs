﻿namespace MyWebsite.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DANH_MUC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DANH_MUC()
        {
            SAN_PHAM = new HashSet<SAN_PHAM>();
        }

        [Key]
        public int MaDM { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Tên danh mục")]
        public string TenDM { get; set; }
        
        public int? DmCha { get; set; }
        [Display(Name = "Thứ tự")]
        public int ThuTu { get; set; }
        [Display(Name = "Trạng thái")]
        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SAN_PHAM> SAN_PHAM { get; set; }
    }
}
