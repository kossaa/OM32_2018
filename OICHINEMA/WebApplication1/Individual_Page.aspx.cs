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
    public partial class Individual_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter da;
            da = new OleDbDataAdapter("SELECT WORK_PASS1,WORK_PASS2,WORK_PASS3,WORK_PASS4 FROM TBL_WORK WHERE WORK_ID = '" + Session["IntroID"] + "'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MovieSignbordImage.ImageUrl = dt.Rows[0][0].ToString();
            MovieCaptureImage1.ImageUrl = dt.Rows[0][1].ToString();
            MovieCaptureImage2.ImageUrl = dt.Rows[0][2].ToString();
            MovieCaptureImage3.ImageUrl = dt.Rows[0][3].ToString();
        }
    }
}