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
            if ((string)Session["PageID"] != "Reservation_Confirm_Input_Information" && !IsPostBack)
            {
                //各Sessionのクリア
                Session.Remove("ScheduleID");
                Session.Remove("ScheduleEnd");
                Session.Remove("BookingMail");
                Session.Remove("SeatInformation");
                Session.Remove("SelectedTicket");
                Session.Remove("WorkName");
                Session.Remove("ScheduleStart");
                Session.Remove("TicketSelectedIndexList");
                Session.Remove("MemberName");
                Session.Remove("MemberPoint");
                Session.Remove("PointGet");
                Session.Remove("PointUse");
                Session.Remove("BookingID");
                Response.Redirect("Reservation_Ticket_Selection.aspx");
                //Response.Redirect("TOP.aspx");//TOP画面に飛ぶ
                return;
            }
            Session["PageID"] = "Reservation_Receipt_Confirmation";
            //メール文章の作成
            string senderMail = "oicinema@asp.net";//送信者
            string recipientMail = Session["BookingMail"].ToString();//宛先
            string subject = "ご予約ありがとうございました";//件名
            string body = DateTime.Now.ToString("yyyy年M月d日 h:m:s") + "予約を完了いたしました\r\n\r\n予約番号：" + Session["BookingID"].ToString();//本文
            System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();//SmtpClientオブジェクトを作成する
            sc.Host = "localhost";//SMTPサーバーを指定する
            sc.Port = 25;//ポート番号を指定する（既定値は25）
            sc.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;//SMTPサーバーに送信する設定にする（既定はNetwork）
            //sc.Send(senderMail, recipientMail, subject, body);//メールを送信する
            sc.Dispose();//後始末（.NET Framework 4.0以降
            BookingIDLabel.Text = "予約番号：" + Session["BookingID"].ToString();
            BookingMailAddressLabel.Text = Session["BookingMail"].ToString() + "にメールを送信しました";
            //各Sessionのクリア
            Session.Remove("ScheduleID");
            Session.Remove("ScheduleEnd");
            Session.Remove("BookingMail");
            Session.Remove("SeatInformation");
            Session.Remove("SelectedTicket");
            Session.Remove("WorkName");
            Session.Remove("ScheduleStart");
            Session.Remove("MemberName");
            Session.Remove("MemberPoint");
            Session.Remove("PointGet");
            Session.Remove("PointUse");
            Session.Remove("BookingID");
            Session.Remove("TicketSelectedIndexList");
        }
    }
}