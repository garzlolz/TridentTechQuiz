using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TridentTech.DBModels
{
    /// <summary>
    /// 老師DB Model
    /// </summary>
    [Comment("老師Table")]
    [Table("teachers")]
    public class Teacher
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
        /// 會員Id
        /// </summary>
        [Required]
        [Column("member_id")]
        [Comment("會員Id")]
        public int MemberId { get; set; }
        /// <summary>
        /// 老師姓名
        /// </summary>
        [Required]
        [Column("teacher_name")]
        [Comment("老師姓名")]
        [StringLength(20)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// 課程名稱
        /// </summary>
        [Required]
        [Column("email")]
        [Comment("E-mail")]
        [StringLength(50)]
        public string Email { get; set; } = null!;
        /// <summary>
        /// 關聯課程
        /// </summary>
        public ICollection<Class>? Classes { get; set; }
        /// <summary>
        /// 會員
        /// </summary>
        public Member Member { get; set; }
    }
}
