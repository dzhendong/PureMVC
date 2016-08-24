using System.Web.UI;
using org.puremvc.csharp.patterns.facade;

namespace PureMVC
{
    /// <summary>
    /// MyFacade 的摘要说明
    /// </summary>
    public class MyFacade : Facade
    {
        //定义通知常量
        public static MyFacade Instance = null;
        public static readonly string DEFAULTSTARTUP = "DefaultStartUp";
        
        /// <summary>
        /// 单例模式实例化对象
        /// </summary>       
        new public static MyFacade getInstance()
        {
            if (Instance == null)
            {
                Instance = new MyFacade();
            }

            return Instance;
        }

        /// <summary>
        /// 初始化Controller
        /// 注册需要使用到的Command
        /// </summary>
        protected override void initializeController()
        {
            base.initializeController();
            registerCommand(MyFacade.DEFAULTSTARTUP, typeof(DefaultPageController));
        }

        /// <summary>
        /// 初始化Model
        /// 注册需要使用到的Proxy
        /// </summary>
        protected override void initializeModel()
        {
            base.initializeModel();
            registerProxy(new UserProxy());
        }

        /// <summary>
        /// 初始化View
        /// </summary>
        protected override void initializeView()
        {
            base.initializeView();
        }

        /// <summary>
        /// 启动DefaultPage页面，注册其它类
        /// </summary>
        public void DefaultPage(Page page)
        {
            sendNotification(MyFacade.DEFAULTSTARTUP, page);
        }

        /// <summary>
        /// 如果还有其它页面，添加相应的启动方法就可以了，
        /// 剩下的工作就由大家来练习吧
        /// </summary>
        /// <param name="page"></param>
        public void OtherPage(Page page)
        {
        }
    }
}
