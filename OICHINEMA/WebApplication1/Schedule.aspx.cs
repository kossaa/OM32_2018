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
    public partial class Schedule : System.Web.UI.Page
    {
        const int SeatMax = 5;
        string[] seatAll = new string[SeatMax];
        string seatChoice = "";

        //データベース接続
        OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");

        protected void ImageBtn_Click(object sender,ImageClickEventArgs e)
        {
            //クリックされたボタンを取得
            seatFull((ImageButton)sender);
        }

        public void seatFull(ImageButton SelectedButton)
        {
            //セッション
            if (Session["seatInfomation"] != null)
            {
                seatAll = (string[])Session["seatInfomation"];
            }
            //クリックされたら色を変える
            if ((SelectedButton).CssClass == "FreeSeat")
            {
                
                //一つずつ格納
                for (int i = 0; i < SeatMax; i++)
                {
                    if (seatAll[i] == null)
                    {
                        seatAll[i] = (SelectedButton).ID;
                        //CSSでグレーを挿入
                        (SelectedButton).CssClass = "ChoiceSeat";
                        break;
                    }
                    else
                    {
                        //今までの選択中のカウント
                        Session["counter"] = (int)Session["counter"] + 1;
                        //席が６席以上選択されたら
                        if ((int)Session["counter"] == SeatMax)
                        {
                            //javascriptでonloadを表示させる
                            ClientScriptManager cs = Page.ClientScript;
                            Type csType = this.GetType();
                            cs.RegisterStartupScript(csType, "onload", "<script type=\"text/javascript\">alert('5席まで同時選択可能です。');</script>");
                        }
                    }
                }
            }
            else
            {
                //選択中を解除
                //CSSで色を元に戻す
                (SelectedButton).CssClass = "FreeSeat";
                Session["counter"] = (int)Session["counter"] - 1;

                for (int i = 0; i < SeatMax; i++)
                {
                    if (seatAll[i] == (SelectedButton).ID)
                    {
                        seatAll[i] = null;
                    }
                }
            }
            Session["seatInfomation"] = seatAll;
            
            //ソートする
            StringComparer cmp = StringComparer.OrdinalIgnoreCase;
            Array.Sort(seatAll, cmp);

            //今までの選択された席をStringの中に入れる
            for (int i = 0; i < SeatMax; i++)
            {
                if (seatAll[i] != null)
                {
                    if (i != 0 && seatChoice != "")
                    {
                        seatChoice = seatChoice + "、";
                    }
                    seatChoice = seatChoice + seatAll[i];
                }
            }
            seatChoice = seatChoice + "が選択中です";

            //ラベルに表示
            Label1.Text = seatChoice;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["counter"] = 0;
            //座席の予約済みを取得し昇順で表示
            Session["scheduleId"] = "0000001";
            OleDbDataAdapter daSeatId = new OleDbDataAdapter(" SELECT SEAT_ID FROM TBL_BOOKING , TBL_BOOKINGDETAIL WHERE TBL_BOOKING.BOOKING_ID = TBL_BOOKINGDETAIL.BOOKING_ID AND SCHEDULE_ID = '" + (string)Session["scheduleId"] + "' ORDER BY SEAT_ID ASC", cn);

            //DataTableを作成し実行
            DataTable dtseat = new DataTable();
            daSeatId.Fill(dtseat);           

            //処理を楽にする
            if(IsPostBack)
            {
                return;
            }

            //ロードに予約されていたら色を変えてクリックできなくする
            for (int i = 0; i < dtseat.Rows.Count; i++)
            {

                ImageButton ibtn = new ImageButton(); 
                //指定したフォームのFindControlで指定したIDを見つけてそのプロパティを変更
                ibtn = Master.FindControl("MainContent").FindControl(dtseat.Rows[i][0].ToString()) as ImageButton;
                ibtn.CssClass = "SoldSeat";
                ibtn.Enabled = false;
            }

            OleDbDataAdapter daBookingId = new OleDbDataAdapter(" SELECT SEAT_ID FROM TBL_BOOKING , TBL_BOOKINGDETAIL WHERE TBL_BOOKING.BOOKING_ID = TBL_BOOKINGDETAIL.BOOKING_ID AND SCHEDULE_ID = '" + (string)Session["scheduleId"] + "' ORDER BY SEAT_ID ASC", cn);

            //DataTableを作成し実行
            DataTable dtBooking = new DataTable();
            daBookingId.Fill(dtBooking);

            //ロードに予約されていたら色を変えてクリックできなくする
            for (int i = 0; i < dtBooking.Rows.Count; i++)
            {
                ImageButton ibtn = new ImageButton();
                ibtn = Master.FindControl("MainContent").FindControl(dtBooking.Rows[i][0].ToString()) as ImageButton;
                ibtn.CssClass = "SoldSeat";
                ibtn.Enabled = false;
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            //途中    
            
            seatAll = (string[])Session["seatInfomation"];
            //選択された席分をデータベースに仮登録
            for (int i = 0; i < (int)Session["counter"]; i++)
            {
                OleDbDataAdapter daBookingId = new OleDbDataAdapter(" INSERT INTO TBL_TEMPORARY( TEMPORARY_SCHEDULE , TEMPORARY_SEAT , TEMPORARY_TIME) VALUES ('" + (string)Session["scheduleId"] + "' ,'" + seatAll[i] + "' , #" + DateTime.Now + "# ) ", cn);
                //DataTableを作成し実行
                DataTable dtBooking = new DataTable();
                daBookingId.Fill(dtBooking);
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            //スケジュール画面に戻る

        }
            
        /*
            protected void imgBtnA01Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA02Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA03Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA04Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA05Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA06Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA07Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA08Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA09Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA10Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA11Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA12Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA13Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA14Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnA15Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB01Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB02Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB03Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB04Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB05Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB06Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB07Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB08Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB09Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB10Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB11Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB12Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB13Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB14Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB15Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnB16Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC01Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC02Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC03Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC04Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC05Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC06Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC07Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC08Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC09Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC10Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC11Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC12Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC13Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC14Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC15Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC16Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnC17Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD01Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD02Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD03Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD04Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD05Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD06Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD07Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD08Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD09Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD10Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD11Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD12Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);

            }

            protected void imgBtnD13Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD14Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD15Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD16Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnD17Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE01Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE02Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE03Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE04Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE05Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE06Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE07Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE08Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE09Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE10Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE11Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE12Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE13Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE14Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE15Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE16Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnE17Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF01Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF02Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF03Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF04Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF05Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF06Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF07Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF08Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF09Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF10Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF11Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF12Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF13Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF14Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF15Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF16Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnF17Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG01Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG02Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG03Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG04Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG05Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG06Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG07Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG08Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG09Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG10Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG11Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG12Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG13Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG14Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG15Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG16Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnG17Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH01Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH02Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH03Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH04Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH05Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH06Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH07Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH08Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH09Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH10Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH11Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH12Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH13Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH14Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH15Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH16Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH17Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnH18Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI01Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI02Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI03Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI04Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI05Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI06Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI07Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI08Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI09Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI10Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI11Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI12Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI13Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI14Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI15Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI16Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI17Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnI18Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ01Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ02Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ03Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ04Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ05Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ06Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ07Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ08Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ09Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ10Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ11Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ12Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ13Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ14Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ15Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ16Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ17Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnJ18Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK01Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK02Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK03Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK04Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK05Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK06Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK07Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK08Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK09Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK10Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK11Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK12Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK13Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK14Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK15Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK16Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK17Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }

            protected void imgBtnK18Click(object sender, ImageClickEventArgs e)
            {
                seatFull((ImageButton)sender);
            }                   
         */
    }
}