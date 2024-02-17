namespace TridentTech.Services.Interface
{
    public interface IJwtService
    {
        /// <summary>
        /// 取得前台使用者
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isTeacher"></param>
        /// <param name="expiredMinutes"></param>
        /// <returns></returns>
        public string GetApiJwt(int userId, bool isTeacher, int expiredMinutes = 1440);
    }
}
