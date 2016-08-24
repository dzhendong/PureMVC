using System.Web.UI;
using org.puremvc.csharp.interfaces;
using org.puremvc.csharp.patterns.command;

namespace PureMVC
{
    /// <summary>
    /// Controller保存所有Command的映射
    /// </summary>
    public class DefaultPageController : SimpleCommand
    {
        public static readonly string LOGIN = "Login";

        /// <summary>
        /// 注册页面要使用到的类
        /// </summary>
        /// <param name="notification"></param>
        public override void execute(INotification notification)
        {
            Page page = notification.getBody() as Page;
            facade.registerCommand(LOGIN, typeof(LoginCommand));
            facade.registerMediator(new LoginMediator(page));
        }
    }
}