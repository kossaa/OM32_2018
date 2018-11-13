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
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String userNo = (string)Session["UserNo"];
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT TBL_WORK.WORK_NAME FROM TBL_WORK INNER JOIN (TBL_SCHEDULE INNER JOIN TBL_BOOKING ON TBL_SCHEDULE.SCHEDULE_ID = TBL_BOOKING.SCHEDULE_ID) ON TBL_WORK.WORK_ID = TBL_SCHEDULE.WORK_ID WHERE MEMBER_ID = '" + userNo + "'", cn);
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT TBL_WORK.WORK_NAME FROM クエリ1 WHERE TBL_BOOKING.MEMBER_ID = '" + userNo + "'", cn);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT WORK_NAME FROM クエリ1 WHERE MEMBER_ID = '0000001'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
        }
    }
}