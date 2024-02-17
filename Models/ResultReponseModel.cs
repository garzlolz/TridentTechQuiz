using TridentTech.Const;

namespace TridentTech.Models
{
    /// <summary>
    /// 回傳格式
    /// </summary>
    public class ResultResponse
    {
        /// <summary>
        /// http 狀態
        /// </summary>
        public int HttpStatus { get; set; } = StatusCodes.Status200OK;
        /// <summary>
        /// 回傳代號
        /// </summary>
        public string Code { get; set; } = ResponseMessage.SuccessCode;
        /// <summary>
        /// 回傳訊息
        /// </summary>
        public string Message { get; set; } = ResponseMessage.Success;
    }

    /// <summary>
    /// 回傳T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultResponse<T> : ResultResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public T? Data { get; set; }
    }
}
