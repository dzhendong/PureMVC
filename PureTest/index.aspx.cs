using System;
using System.Web.UI;
using PureMVC;

namespace PureTest
{
    public partial class index : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            MyFacade facade = MyFacade.getInstance();

            //启动这个页面
            facade.DefaultPage(Page);
        }
    }
}