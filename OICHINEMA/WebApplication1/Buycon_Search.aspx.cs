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
    public partial class Buy_con : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (Page.IsPostBack != true)
            {
                Messe_lbl.Visible = false;
            }
        }

        protected void Inq_btn_Click(object sender, EventArgs e)
        {
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT BOOKING_ID FROM TBL_SCHEDULE INNER JOIN TBL_BOOKING ON TBL_SCHEDULE.SCHEDULE_ID = TBL_BOOKING.SCHEDULE_ID WHERE BOOKING_MAIL = '" + Mail_tb.Text + "'AND BOOKING_BUYID = '" + BuyID_tb.Text + "'AND SCHEDULE_END >= NOW", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["BookingID"] = dt.Rows[0][0];
                Response.Redirect("Buycon_Info.aspx");
            }
            else
            {
                Messe_lbl.Text = "ご入力されたメールアドレス、購入番号のご購入情報がございませんでした。ご入力内容をご確認ください。";
                Messe_lbl.Visible = true;
            }
        }
    }
}