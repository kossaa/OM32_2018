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

        protected void ImageBtn_Click(object sender,ImageClickEventArgs e)
        {
            seatFull((ImageButton)sender);
        }

        public void seatFull(ImageButton SelectedButton)
        {
            //セッション
            if (Session["value"] != null)
            {
                seatAll = (string[])Session["value"];
            }
            //クリックされたら色を変える
            if ((SelectedButton).CssClass == "FreeSeat")
            {
                //今までの選択中のカウント
                int counter = 0;
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
                        counter++;
                        //席が６席以上選択されたら
                        if (counter == SeatMax)
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

                for (int i = 0; i < SeatMax; i++)
                {
                    if (seatAll[i] == (SelectedButton).ID)
                    {
                        seatAll[i] = null;
                    }
                }
            }
            Session["value"] = seatAll;

            //ソートする
            StringComparer cmp = StringComparer.OrdinalIgnoreCase;
            Array.Sort(seatAll, cmp);
            //string temp = "";
            //for (int i = 0; i < SeatMax; i++)
            //{
            //    temp = seatAll[i];
            //    string tempmin = "";
            //    tempmin = seatAll[SeatMax-i];
            //    for (int j = 0; j < SeatMax - i; j++)
            //    {
                        
            //    }
            //}

                //今までの選択された席をStringの中に入れる
                for (int i = 0; i < SeatMax; i++)
                {
                    if (seatAll[i] != null)
                    {
                        if (i != 0&&seatChoice!="")
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
            //データベース接続
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter daScreenId;
            //スクリーン番号取得、セションを使用
            daScreenId = new OleDbDataAdapter(" SELECT SEAT_ID FROM TBL_SEAT WHERE SCREEN_ID = '" + (string)Session["screenId"] + "'", cn);

            DataTable dtscreen = new DataTable();
            daScreenId.Fill(dtscreen);
            //座席が予約済みを取得、セションを使用
            OleDbDataAdapter daSeatId = new OleDbDataAdapter(" SELECT SEAT_ID FROM TBL_BOOKING INNER JOIN TBL_BOOKINGDETAIL ON TBL_BOOKING.BOOKING_ID = TBL_BOOKINGDETAIL.BOOKING_ID WHERE SCREEN_ID = '" + (string)Session["scheduleId"] + "'", cn);

            DataTable dtseat = new DataTable();
            daScreenId.Fill(dtseat);

            Label2.Text = dtseat.Rows[0][0].ToString();
            //処理を楽にする
            if(IsPostBack)
            {
                return;
            }

            //座席の有無
            
        }

            protected void Button1_Click(object sender, EventArgs e)
            {

            }

            protected void Button2_Click(object sender, EventArgs e)
            {

            }

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

        
    }
}