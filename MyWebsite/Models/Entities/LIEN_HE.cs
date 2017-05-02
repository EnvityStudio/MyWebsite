namespace MyWebsite.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LIEN_HE
    {
        [Key]
        public int MaLH { get; set; }

        [Required]
        [StringLength(255)]
        public string TieuDe { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(50)]
        public string TenKH { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        public bool TrangThai { get; set; }

        public DateTime NgayDang { get; set; }
    }
}
