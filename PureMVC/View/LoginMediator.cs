using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using org.puremvc.csharp.interfaces;
using org.puremvc.csharp.patterns.mediator;

namespace PureMVC
{
    /// <summary>
    /// View保存对Mediator对象的引用
    /// 由Mediator对象来操作具体的视图组件
    /// 包括：添加事件监听器，发送或接收Notification ，直接改变视图组件的状态。
    /// </summary>
    public class LoginMediator : Mediator
    {
        new public static readonly string NAME = "LoginMediator";

        /// <summary>
        /// 为页面控件添加事件，这里只添加登录事件
        /// </summary>
        public LoginMediator(Page page)
            : base(NAME, page)
        {
            Button loginButton = (Button)page.FindControl("LoginButton");
            loginButton.Click += new EventHandler(Login);
        }

        /// <summary>
        /// 列出该Mediator要接收的通知
        /// </summary>
        public override IList<string> listNotificationInterests()
        {
            List<string> list = new List<string>();
            list.Add(LoginCommand.LOGIN_SUCCESS);
            list.Add(LoginCommand.LOGIN_FAILED);
            list.Add(LoginCommand.USER_NOT_FOUND);
            return list;
        }

        /// <summary>
        /// 对接收到的通知分别进行处理
        /// </summary>
        public override void handleNotification(INotification notification)
        {
            switch (notification.getName())
            {
                case "LoginSuccess":
                    MyPage.Session["User"] = notification.getBody();
                    MyPage.Response.Redirect("Welcome.aspx");
                    break;
                case "LoginFailed":
                    Message.Text = "用户名或密码不正确 !";
                    break;
                case "UserNotFound":
                    Message.Text = "该用户不存在!";
                    break;
            }
        }

        /// <summary>
        /// 登录按钮的单击事件
        /// </summary>
        public void Login(object sender, EventArgs e)
        {
            TextBox userNameTextBox = (TextBox)MyPage.FindControl("UserNameTextBox");
            string userName = userNameTextBox.Text;
            TextBox passwordTextBox = (TextBox)MyPage.FindControl("PasswordTextBox");
            string password = passwordTextBox.Text;
            LoginVO loginVO = new LoginVO(userName, password);
            sendNotification(DefaultPageController.LOGIN, loginVO);
        }

        private Page MyPage
        {
            get { return viewComponent as Page; }
        }

        private Label Message
        {
            get
            {
                Label label = (Label)MyPage.FindControl("MessageLabel");
                return label;
            }
        }
    }
}
