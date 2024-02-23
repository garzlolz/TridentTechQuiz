using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TridentTech.Models
{
    /// <summary>
    /// 講師資訊 Model
    /// </summary>
    public class GetTeachersModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int TeacherMemberId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        public string Email { get; set; } = null!;
    }

    /// <summary>
    /// 講師開課 Model
    /// </summary>
    public class TeacherClassModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 講師會員 Id
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        public string Email { get; set; } = null!;
        /// <summary>
        /// 課程列表
        /// </summary>
        public List<ClassModel>? Classes { get; set; }
    }

    /// <summary>
    /// 講師基本資訊 Model
    /// </summary>
    public class TeacherBaseModel
    {
        /// <summary>
        /// 講師帳號
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Account { get; set; } = null!;
        /// <summary>
        /// 講師密碼
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Password { get; set; } = null!;
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        public string Email { get; set; } = null!;
    }

    /// <summary>
    /// 課程資訊 Model
    /// </summary>
    public class TeacherClass
    {
        /// <summary>
        /// 課程Id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string? ClassName { get; set; }
        /// <summary>
        /// 課程簡介
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 上課時間 (格式 HHmm)
        /// </summary>
        [Required]
        public string? StartAt { get; set; }
    }
}
