using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                LogoutButton.Visible = false;
            }
            else
            {
                SignupButton.Visible = false;
                LoginButton.Visible = false;
                Label1.Visible = false;
                LogoutButton.Visible = true;
            }
        }

        protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Text == "トップ")
            {
                Session["PageID"] = "Top.aspx";
                e.Item.NavigateUrl = "Top.aspx";
            }
            if (e.Item.Text=="会員ページ")
            {
                Session["PageID"] = "Member_MyPage.aspx";
                if(Session["UserID"] != null){//セッションの中身が入ってたら
                    e.Item.NavigateUrl = "Member_MyPage.aspx";
                }
                else
                {
                    e.Item.NavigateUrl = "Login.aspx";
                }
            }
            if (e.Item.Text == "スケジュール")
            {
                e.Item.NavigateUrl = "Schedule.aspx";
            }
            if (e.Item.Text == "作品案内")
            {
                e.Item.NavigateUrl = null;
            }
            if (e.Item.Text == "イベント")
            {
                e.Item.NavigateUrl = "Event.aspx";
            }
            if (e.Item.Text == "販売")
            {
                e.Item.NavigateUrl = null;
            }
            if (e.Item.Text == "予約確認")
            {
                e.Item.NavigateUrl = null;
            }
            if (e.Item.Text == "アクセス")
            {
                e.Item.NavigateUrl = "Access.aspx";
            }            
        }

        protected void NavigationMenu_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            e.Item.NavigateUrl = "";
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            //ログアウト処理
            FormsAuthentication.SignOut();
            Session["UserNo"] = null;
            Response.Redirect("Top.aspx");
        }
    }
}