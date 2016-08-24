
namespace PureMVC
{
    /// <summary>
    /// 登录实体
    /// </summary>
    public class LoginVO
    {
        public LoginVO(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
