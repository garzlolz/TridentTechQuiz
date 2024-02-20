using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TridentTech.DBModels
{
    /// <summary>
    /// 學生所屬課程
    /// </summary>
    [Table("class_selections")]
    public class ClassSelection
    {
        /// <summary>
        /// 選課Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Comment("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 會員Id
        /// </summary>
        [Comment("member_id")]
        public int MemberId { get; set; }
        /// <summary>
        /// 課程Id
        /// </summary>
        [Column("class_id")]
        [Comment("所屬課程Id")]
        public int ClassId { get; set; }
        /// <summary>
        /// 會員
        /// </summary>
        public Member Member { get; set; } = null!;
        /// <summary>
        /// 課程
        /// </summary>
        public Class Class { get; set; } = null!;
    }
}
