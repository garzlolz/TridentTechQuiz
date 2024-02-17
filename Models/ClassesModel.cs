using System.ComponentModel.DataAnnotations;

namespace TridentTech.Models
{
    /// <summary>
    /// 課程列表 Model
    /// </summary>
    public class ClassListModel
    {
        /// <summary>
        /// 課程Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string? ClassName { get; set; }
        /// <summary>
        /// 老師Id
        /// </summary>
        public int? TeacherId { get; set; }
        /// <summary>
        /// 老師名稱
        /// </summary>
        public string? TeacherName { get; set; }
        /// <summary>
        /// 上課時間 (格式 HHmm)
        /// </summary>
        public string? StartAt { get; set; }
        /// <summary>
        /// 下課時間 (格式 HHmm)
        /// </summary>
        public string? EndAt { get; set; }
    }

    /// <summary>
    /// 課程基本資訊 Model
    /// </summary>
    public class ClassBaseModel
    {
        /// <summary>
        /// 課程名稱
        /// </summary>
        [Required]
        [StringLength(20)]
        public string ClassName { get; set; } = null!;
        /// <summary>
        /// 課程簡介
        /// </summary>
        [StringLength(100)]
        public string? Description { get; set; }
        /// <summary>
        /// 上課時間 (格式 HHmm)
        /// </summary>
        [Required]
        [StringLength(4), MinLength(4)]
        public string StartAt { get; set; } = null!;
        /// <summary>
        /// 下課時間 (格式 HHmm)
        /// </summary>
        [Required]
        [StringLength(4), MinLength(4)]
        public string EndAt { get; set; } = null!;
        /// <summary>
        /// 講師 Id
        /// </summary>
        public int? TeacherId { get; set; }
    }

    /// <summary>
    /// 課程詳細資訊Model
    /// </summary>
    public class ClassModel
    {
        /// <summary>
        /// 課程 Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string ClassName { get; set; } = null!;
        /// <summary>
        /// 課程簡介
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 上課時間 (格式 HHmm)
        /// </summary>
        [Required]
        public string StartAt { get; set; } = null!;
        /// <summary>
        /// 下課時間 (格式 HHmm)
        /// </summary>
        [Required]
        public string EndAt { get; set; } = null!;
    }
}
