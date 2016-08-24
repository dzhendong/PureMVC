<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="index.aspx.cs" Inherits="PureTest.index" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>本Demo由真的骄傲精心制作</h1>
    <h3>我在博客园的地址是：
    <asp:HyperLink ID="HyperLink1" NavigateUrl="http://www.cnblogs.com/reallypride/" runat="server">真的骄傲梦想家园</asp:HyperLink>
    欢迎大家访问
    </h3>
    <div>
        <table>
            <tr>
                <td></td>
                <td>用户登录</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="用户名："></asp:Label></td>
                <td>
                    <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="密码："></asp:Label></td>
                <td>
                    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="LoginButton" runat="server" Text="登 录" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="MessageLabel" runat="server"></asp:Label></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
