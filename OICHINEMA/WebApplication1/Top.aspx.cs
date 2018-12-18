using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Top : System.Web.UI.Page
    {
        String[] ADImage = { "avengers.jpg", "monsto.jpg", "oichinema.jpg" };
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["PageID"] = "Top.aspx";
            AdImageButton.ImageUrl = "~/Image/" + ADImage[2];
        }
        


    }
}