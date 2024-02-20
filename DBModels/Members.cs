using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TridentTech.DBModels
{
    [Table("members")]
    public class Member
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
        /// 帳號
        /// </summary>
        [StringLength(100)]
        [Column("member_account")]
        [Comment("帳號")]
        [Required]
        public string Account { get; set; } = null!;
        /// <summary>
        /// 密碼
        /// </summary>
        [Column("member_password")]
        [StringLength(100)]
        [Comment("密碼")]
        [Required]
        public string Password { get; set; } = null!;
        /// <summary>
        /// 姓名
        /// </summary>
        [Column("member_name")]
        [StringLength(10)]
        [Comment("姓名")]
        [Required]
        public string Name { get; set; } = null!;
        /// <summary>
        /// E-mail
        /// </summary>
        [Column("member_email")]
        [StringLength(50)]
        [Comment("E-mail")]
        [Required]
        public string Email { get; set; } = null!;
        /// <summary>
        /// 是否為老師
        /// </summary>
        [Column("is_teacher")]
        [Comment("是否為老師")]
        [Required]
        public bool IsTeacher { get; set; } = false;
        /// <summary>
        /// 講師課程列表
        /// </summary>
        public ICollection<Class>? Classes { get; set; }
        /// <summary>
        /// 學生關聯選課
        /// </summary>
        public ICollection<ClassSelection>? MemberClasses { get; set; }
    }
}
