using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TridentTech.DBModels
{
    [Table("classes")]
    public class Class
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Comment("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        [Column("class_name")]
        [Comment("課程名稱")]
        [StringLength(20)]
        [Required]
        public string ClassName { get; set; } = null!;
        /// <summary>
        /// 課程名稱
        /// </summary>
        [Column("class_description")]
        [Comment("課程描述")]
        [StringLength(200)]
        public string? Description { get; set; }
        /// <summary>
        /// 上課時間
        /// </summary>
        [Column("start_at")]
        [Comment("上課時間")]
        [StringLength(4), MinLength(4)]
        [Required]
        public string StartAt { get; set; } = null!;
        /// <summary>
        /// 下課時間
        /// </summary>
        [Column("end_at")]
        [Comment("下課時間")]
        [StringLength(4), MinLength(4)]
        [Required]
        public string EndAt { get; set; } = null!;
        /// <summary>
        /// 會員(講師)Id
        /// </summary>
        [Column("member_id")]
        [Comment("會員 Id")]
        public int? MemberId { get; set; }
        /// <summary>
        /// 課程講師
        /// </summary>
        public Member? Member { get; set; }
        /// <summary>
        /// 課程關聯會員
        /// </summary>
        public ICollection<ClassSelection>? MemberClasses { get; set; }
    }
}
