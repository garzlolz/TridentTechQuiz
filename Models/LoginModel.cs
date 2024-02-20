using System.ComponentModel.DataAnnotations;

namespace TridentTech.Models
{
    /// <summary>
    /// 登入 Model
    /// </summary>
    public class LoginRequestModel
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Account { get; set; } = null!;
        /// <summary>
        /// 密碼
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Password { get; set; } = null!;
        /// <summary>
        /// 是否為講師
        /// </summary>
        [Required]
        public bool IsTeacher { get; set; }
    }

    /// <summary>
    /// 登入 Response Model
    /// </summary>
    public class LoginResponseModel
    {
        /// <summary>
        /// 會員JwtToken
        /// </summary>
        public string? Token { get; set; }
    }

    /// <summary>
    /// 註冊  Model
    /// </summary>
    public class RegisterRequestModel
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Account { get; set; } = null!;
        /// <summary>
        /// 密碼
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Password { get; set; } = null!;
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Email { get; set; } = null!;
        /// <summary>
        /// 是否為講師
        /// </summary>
        [Required]
        public bool IsTeacher { get; set; } = false;
    }
}
