using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Reservation_Receipt_Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["PageID"] != "Reservation_Ticket_Selection")
            {
                Response.Redirect("https://www.yahoo.co.jp/");
                //Response.Redirect("Schedule.aspx");//TOP画面に飛ぶ
                return;
            }
            BookingIDLabel.Text = "予約番号：";
            BookingMailAddressLabel.Text = Session["BookingMail"].ToString()+"にメールを送信しました";
            //各Sessionのクリア
            Session.Remove("ScheduleID");
            Session.Remove("ScheduleEnd");
            Session.Remove("BookingMail");
            Session.Remove("SeatInformation");
            Session.Remove("SelectedTicket");
            Session.Remove("WorkName");
            Session.Remove("ScheduleStart");
        }
    }
}