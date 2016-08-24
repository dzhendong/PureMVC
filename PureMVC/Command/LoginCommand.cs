using org.puremvc.csharp.interfaces;
using org.puremvc.csharp.patterns.command;

namespace PureMVC
{
    /// <summary>
    /// Command类是无状态的
    /// 只在需要时才被创建。
    /// 
    /// Command可以获取Proxy对象并与之交互
    /// 发送Notification，执行其他的Command。
    /// 经常用于复杂的或系统范围的操作
    /// 如应用程序的“启动”和“关闭”。
    /// 应用程序的业务逻辑应该在这里实现。
    /// </summary>
    public class LoginCommand : SimpleCommand
    {
        public static readonly string LOGIN_SUCCESS = "LoginSuccess";
        public static readonly string LOGIN_FAILED = "LoginFailed";
        public static readonly string USER_NOT_FOUND = "UserNotFound";

        public override void execute(INotification notification)
        {
            base.execute(notification);

            //获得用户登录的信息
            LoginVO loginVO = (LoginVO)notification.getBody();

            //获得需要使用到的Proxy
            UserProxy userProxy = facade.retrieveProxy(UserProxy.NAME) as UserProxy;

            //通过用户名返回用户的信息
            UserInfo userInfo = userProxy.GetUserInfo(loginVO.UserName);

            //实现用户的登录逻辑
            if (userInfo != null)
            {
                if (userInfo.Password == loginVO.Password)
                {
                    //发出登录情况的通知
                    sendNotification(LOGIN_SUCCESS, userInfo);
                }
                else
                {
                    sendNotification(LOGIN_FAILED);
                }
            }
            else
            {
                sendNotification(USER_NOT_FOUND);
            }
        }
    }
}
