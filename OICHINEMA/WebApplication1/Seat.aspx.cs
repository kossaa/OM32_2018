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
    public partial class test : System.Web.UI.Page
    {
        private ImageButton[] imgBtn;
        private Image[] image;   
        const int SeatMax = 5;
        string[] seatAll = new string[SeatMax];
        string seatChoice = ""; 


        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            //データベース接続
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|\\stusrv\\システム開発演習\\OM-32\\データベース\\BookingDB.accdb;");
            //OleDbDataAdapter daScreenId;         
            スクリーン番号取得
            daScreenId = new OleDbDataAdapter(" SELECT SEAT_ID FROM TBL_SEAT WHERE SCREEN_ID = '" + (string)Session["screenId"] +"'",cn);

            DataTable dtscreen = new DataTable();
            daScreenId.Fill(dtscreen);
            //座席が予約済みを取得
            OleDbDataAdapter daSeatId = new OleDbDataAdapter(" SELECT SEAT_ID FROM TBL_BOOKING WHERE SCREEN_ID = '" + (string)Session["scheduleId"] + "'", cn);

            DataTable dtseat = new DataTable();
            daScreenId.Fill(dtseat);

            //Labeに取得したデータを格納　rows[行][列]で指定
   　       Label2.Text = dtseat.Rows[0][0].ToString();
            Label3.Text = dtseat.Rows[1][0].ToString();
            */
            //tableのRowとCellを宣言
            TableRow tableRow;
            TableCell tableCell;            
            //Seat生成
            this.imgBtn = new ImageButton[140];
            this.image = new Image[100];
            int imageSeatBtn = 0;
            int imageRoad = 0;
            //列を生成
            for (int i = 0; i < imgBtn.Length/14 ; i++)
            {
                //Rowの作成
                tableRow = new TableRow();
                //行を生成
                for (int j = 0; j < imgBtn.Length/10 ; j++)
                {
                    //左から４列目のときに画像追加
                    if (j == 3 || j == 10)
                    {
                        //プロパティ設定
                        tableCell = new TableCell();
                        tableCell.Height = 20;
                        this.image[imageRoad] = new Image();
                        this.image[imageRoad].ID = "Image" + imageRoad.ToString();
                        this.image[imageRoad].ImageUrl = "~/img/tuuro.png";
                        this.image[imageRoad].Height = 30;
                        this.image[imageRoad].Width = 30;
                        //通路の画像を追加
                        this.image[imageRoad].CssClass = "FreeSeat";                        
                        //プロパティを設定したImageをテーブルのセルに追加
                        tableCell.Controls.Add(this.image[imageRoad]);
                        //中身を設定したセルをテーブルに追加
                        tableRow.Cells.Add(tableCell);
                        //通路の番号を+1
                        imageRoad++;        
                    }
                    else
                    {
                        //席１つ１つの数
                        imageSeatBtn ++;
                        //テーブル内に入れるセル(1マス)を生成
                        tableCell = new TableCell();
                        tableCell.Height = 20;
                        this.imgBtn[imageSeatBtn - 1] = new ImageButton();
                        //プロパティ設定
                        this.imgBtn[imageSeatBtn - 1].ID = "SeatImgBtn" + (imageSeatBtn-1).ToString();
                        this.imgBtn[imageSeatBtn-1].ImageUrl = "~/img/isu.png";
                        this.imgBtn[imageSeatBtn-1].Height = 30;
                        this.imgBtn[imageSeatBtn-1].Width = 30;
                        this.imgBtn[imageSeatBtn-1].CssClass = "ChoiceSeat";
                        //イベント追加
                        this.imgBtn[imageSeatBtn-1].Click += new System.Web.UI.ImageClickEventHandler(this.ImageBtnSeat_Click);
                        //プロパティを設定したImageをテーブルのセルに追加
                        tableCell.Controls.Add(this.imgBtn[imageSeatBtn-1]);
                        //中身を設定したセルをテーブルに追加
                        tableRow.Cells.Add(tableCell);                 
                    }
                    
                }
                //中身を設定した行をテーブルに追加
                Table1.Rows.Add(tableRow);  
                //ここで改行される          
            }
            //空席の有無    
            /*
            for(int i=0;i<dtseat.Rows.Count;i++)
            {
                dtseat.Rows[i][0].ToString();
                
            }
            */
        }    


        protected void ImageBtnSeat_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["value"] != null)
            {
                seatAll = (string[])Session["value"];
            }                    
            //クリックされたら色を変える
            if (((ImageButton)sender).CssClass == "FreeSeat")
            {
                //選択中
                int counter = 0;                
                //一つずつ格納
                for (int i = 0; i < SeatMax; i++)
                {
                    if (seatAll[i] == null)
                    {
                        seatAll[i] = ((ImageButton)sender).ID;
                        //CSSでグレーを挿入
                        ((ImageButton)sender).CssClass = "ChoiceSeat";
                        break;
                    }
                    else
                    {
                        counter++;
                        //┏━━━━━━━━━━━━━━━━━━━━━━━━┓
                        //┃6席目でonloadが表示されるはずなのに表示されない ┃
                        //┃PostBackが原因？　　　　　　                    ┃
                        //┗━━━━━━━━━━━━━━━━━━━━━━━━┛
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
                ((ImageButton)sender).CssClass = "FreeSeat";

                for(int i = 0; i < SeatMax; i++)
                {
                    if(seatAll[i] == ((ImageButton)sender).ID)
                    {
                        seatAll[i] = null;
                        
                    }
                }
            }
            Session["value"] = seatAll;

            
            //今までの選択された席をStringの中に入れる
            for (int i = 0; i < SeatMax; i++)
            {
                if(i!=0)
                {
                    seatChoice = seatChoice + "、";
                }
                seatChoice = seatChoice + seatAll[i];
            }
            seatChoice = seatChoice + "が選択中です";

            //ラベルに表示
            Label1.Text = seatChoice;
        }

        


        protected void Button1_Click(object sender, EventArgs e)
        {
            //次（確定）画面に飛ぶ
            //リンクを飛ばす
            //Response.Redirect("https://www.yahoo.co.jp/");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //前（スケジュール）画面に戻る

        }
     
    }
}