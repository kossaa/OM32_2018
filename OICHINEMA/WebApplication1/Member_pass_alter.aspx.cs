using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Member_pass_alter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
            {

            }
        }

        protected void Back_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member_MyPage.aspx");
        }

        protected void Con_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member_MyPage.aspx");
        }

        protected void Oldpass_tb_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Newpass_tb_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Newpass2_tb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}