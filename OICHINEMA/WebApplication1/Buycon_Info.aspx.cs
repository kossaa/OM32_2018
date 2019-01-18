using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Buycon_Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
            {

            }
        }

        protected void Back_btn_Click(object sender, EventArgs e)
        {
            Session["BokkingID"] = null;
            Response.Redirect("Buycon_Search.aspx");
        }
    }
}