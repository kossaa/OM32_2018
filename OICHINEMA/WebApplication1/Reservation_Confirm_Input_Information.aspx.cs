using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Reservation_Confirm_Input_Information : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MovieNameTextbox.ReadOnly = true;
            NameTextbox.ReadOnly = true;
            ReservationSeatTextbox.ReadOnly = true;
            MailAddressTextbox.ReadOnly = true;
            ReservationDateStartTextbox.ReadOnly = true;
            ReservationDateEndTextbox.ReadOnly = true;
        }

        protected void AcceptBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reservation_Receipt_Confirmation.aspx");
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.yahoo.co.jp/");//結合後はReservation_Enter_Reservation Information.aspxに遷移
        }
    }
}