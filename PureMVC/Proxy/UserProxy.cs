
using org.puremvc.csharp.patterns.proxy;

namespace PureMVC
{
    /// <summary>
    /// 用户数据访问
    /// </summary>
    public class UserProxy : Proxy
    {
        new public static readonly string NAME = "UserProxy";

        public UserProxy()
            : base(NAME)
        {
        }

        /// <summary>
        /// 从数据库中读取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string userName)
        {
            UserInfo userInfo = null;
           
            return userInfo;
        }
    }
}