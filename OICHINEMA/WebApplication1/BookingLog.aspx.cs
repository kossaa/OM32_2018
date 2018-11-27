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
    public partial class BookingLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String userNo = (string)Session["UserNo"];
            String userNo = "0000001";
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT BOOKING_DAY,WORK_NAME,SEAT_ID,RATE_NAME,EVENT_NAME,BOOKINGDETAIL_POINT FROM Q_BOOKINGLOG WHERE MEMBER_ID = '" + userNo + "'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}