using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LogoutButton.Visible = false;

        }

        protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Text=="会員ページ")
            {
                Session["PageID"] = "Member_MyPage.aspx";
                if(Session["UserID"]!=null){//セッションの中身が入ってたら
                    e.Item.NavigateUrl = "Member_MyPage.aspx";
                }
                else{
                    e.Item.NavigateUrl = "Login.aspx";
                }
            }

        }

        protected void NavigationMenu_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            e.Item.NavigateUrl = "";
        }

        protected void NavigationMenu_Load(object sender, EventArgs e)
        {
            
        }
    }
}