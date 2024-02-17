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
        /// 是否為老師
        /// </summary>
        [Column("is_teacher")]
        [StringLength(100)]
        [Comment("是否為老師")]
        [Required]
        public bool IsTeacher { get; set; } = false;
        /// <summary>
        /// 是否為講師
        /// </summary>
        [Column("teacher_id")]
        [StringLength(100)]
        [Comment("講師Id")]
        [Required]
        public int? TeacherId { get; set; }
        /// <summary>
        /// 關聯講師
        /// </summary>
        public Teacher? Teacher { get; set; }
    }
}
