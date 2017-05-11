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
        public string TieuDe { get; set; }

        [Required]
        [StringLength(255)]
        public string HinhAnh { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string NoiDung { get; set; }

        public bool NoiBat { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDang { get; set; }
    }
}
