namespace MyWebsite.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BLOG")]
    public partial class BLOG
    {
        [Key]
        public int MaBlog { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [StringLength(255)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Display(Name = "Nổi bật")]
        public bool NoiBat { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày đăng")]
        public DateTime NgayDang { get; set; }
    }
}
