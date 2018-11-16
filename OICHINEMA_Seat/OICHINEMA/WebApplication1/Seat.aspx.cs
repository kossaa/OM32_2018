using System;
using System.Collections.Generic;
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
        string[] seatall = new string[SeatMax];

        protected void Page_Load(object sender, EventArgs e)
        {
            /*//PostBack処理
            // 毎回行う初期化処理
            if (!IsPostBack)
            {
                // 最初のアクセス時にのみ行う初期化処理

            }
            else
            {
                // ポストバック時にのみ行う初期化処理

            }*/

            //tableのRowとCellを宣言
            TableRow tableRow;
            TableCell tableCell;
            //RowとCellの作成
            tableRow = new TableRow();
            tableCell = new TableCell();
            //Seat生成
            this.imgBtn = new ImageButton[140];
            this.image = new Image[100];
            int imageSeatBtn = 0;
            int imageTuuro = 0;
            //横
            for (int i = 0; i < imgBtn.Length/14 ; i++)
            {       
                tableRow = new TableRow();//テーブル内に入れる行を生成
                
                //縦
                for (int j = 0; j < imgBtn.Length/10 ; j++)
                {
                    //左から４列目のときに画像追加
                    if (j == 3 || j == 10)
                    {
                        tableCell = new TableCell();
                        tableCell.Height = 20;
                        this.image[imageTuuro] = new Image();
                        //プロパティ設定
                        this.image[imageTuuro].ID = "Image" + imageTuuro.ToString();
                        this.image[imageTuuro].ImageUrl = "~/img/tuuro.png";
                        this.image[imageTuuro].Height = 30;
                        this.image[imageTuuro].Width = 30;
                        this.image[imageTuuro].CssClass = "SeatImg2";
                        //プロパティを設定したImageをテーブルのセルに追加
                        tableCell.Controls.Add(this.image[imageTuuro]);
                        //中身を設定したセルをテーブルに追加
                        tableRow.Cells.Add(tableCell);
                        imageTuuro++;        
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
                        this.imgBtn[imageSeatBtn - 1].ID = "SeatImage" + (imageSeatBtn-1).ToString();
                        this.imgBtn[imageSeatBtn-1].ImageUrl = "~/img/isu.png";
                        this.imgBtn[imageSeatBtn-1].Height = 30;
                        this.imgBtn[imageSeatBtn-1].Width = 30;
                        this.imgBtn[imageSeatBtn-1].CssClass = "SeatImg2";
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
        }    


        protected void ImageBtnSeat_Click(object sender, ImageClickEventArgs e)
        {
            //クリック時のIDを取得
            Label1.Text = ((ImageButton)sender).ID + "が押されました！";
            //複数選択された場合
            Label2.Text = ((ImageButton)sender).ID + "が選択中です";

            
            //クリックされたら色を変える
            if (((ImageButton)sender).CssClass == "SeatImg2")
            {
                //選択中
                int counter = 0;                
                //一つずつ格納
                for (int i = 0; i < SeatMax; i++)
                {
                    if (seatall[i] == null)
                    {                     
                        seatall[i] = ((ImageButton)sender).ID;
                        //CSSでグレーを挿入
                        ((ImageButton)sender).CssClass = "SeatImg";
                        break;
                    }
                    else
                    {
                       counter++;
                    }
                    //┏━━━━━━━━━━━━━━━━━━━━━━━━┓
                    //┃6席目でonloadが表示されるはずなのに表示されない ┃
                    //┃PostBackが原因？　　　　　　                    ┃
                    //┗━━━━━━━━━━━━━━━━━━━━━━━━┛
                    if(counter == SeatMax)
                    {
                        //javascriptでonloadを表示させる
                        ClientScriptManager cs = Page.ClientScript;
                        Type csType = this.GetType();
                        cs.RegisterStartupScript(csType, "onload", "<script type=\"text/javascript\">alert('5席まで同時選択可能です。');</script>");          
                    }
                }
            }
            else
            {
                //選択中を解除
                //CSSで色を元に戻す
                ((ImageButton)sender).CssClass = "SeatImg2";

                for(int i=0;i<SeatMax;i++)
                {
                    if(seatall[i] == ((ImageButton)sender).ID)
                    {
                        seatall[i] = null;
                        
                    }
                }
            }
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