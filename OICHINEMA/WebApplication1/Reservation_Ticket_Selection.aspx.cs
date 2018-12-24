using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    //１つのイベントのデータを管理するクラス
    class Event
    {
        public int rate;//イベント料金を格納
        public string name;//イベント名を格納
        public string number;//イベント番号を格納
        public string price;//変更する料金番号を格納

        //コンストラクタ
        //書かないと、引数なしのコンストラクタが使えない
        public Event()
        {
            //特に何もしない
        }

        //引数ありコンストラクタ
        public Event(int r, string n, string num, string p)
        {
            rate = r;
            name = n;
            number = num;
            price = p;
        }

        public void setData(int r, string n, string num, string p)
        {
            rate = r;
            name = n;
            number = num;
            price = p;
        }
    }

    //イベントによってデータの変更が行われる
    //１つのイベントのデータを管理する
    class AddEvent
    {
        public int rate;//イベント料金を格納
        public string name;//イベント名を格納
        public string number;//イベント番号を格納

        //コンストラクタ
        public AddEvent()
        {
        }

        //引数ありコンストラクタ
        public AddEvent(int r, string n, string num)
        {
            rate = r;
            name = n;
            number = num;
        }

        public void setData(int r, string n, string num)
        {
            rate = r;
            name = n;
            number = num;
        }
    }

    class DisplayData
    {
        public int ticketRate;
        public string ticketName;
        public string eventNumber;
        public string defaultnumber;

        //コンストラクタ
        public DisplayData()
        {
        }

        //引数ありコンストラクタ
        public DisplayData(int tr, string tn, string evenum, string defnum)
        {
            ticketRate = tr;
            ticketName = tn;
            eventNumber = evenum;
            defaultnumber = defnum;
        }

        public void setData(int tr, string tn, string evenum, string defnum)
        {
            ticketRate = tr;
            ticketName = tn;
            eventNumber = evenum;
            defaultnumber = defnum;
        }
    }

    class SelectedTicket
    {
        public int ticketRate;//チケット料金
        public string ticketName;//チケット名
        public string eventNumber;//イベント番号
        public string defaultnumber;//通常料金番号
        public string seatNumber;//座席番号

        //コンストラクタ
        public SelectedTicket()
        {
        }

        //引数ありコンストラクタ
        public SelectedTicket(int tr, string tn, string evenum, string defnum, string snum)
        {
            ticketRate = tr;
            ticketName = tn;
            eventNumber = evenum;
            defaultnumber = defnum;
            seatNumber = snum;
        }

        public void setData(int tr, string tn, string evenum, string defnum, string snum)
        {
            ticketRate = tr;
            ticketName = tn;
            eventNumber = evenum;
            defaultnumber = defnum;
            seatNumber = snum;
        }
    }

    public partial class Reservation_Ticket_Selection : System.Web.UI.Page
    {
        const int Cell2Width = 300;
        Button BackBtn = new Button();
        Button NextBtn = new Button();
        TextBox MailAddressTextbox = new TextBox();

        //Listを使って可変長にデータを管理する
        List<Event> eventList = new List<Event>();
        List<AddEvent> addEventList = new List<AddEvent>();
        List<SelectedTicket> selectedticketList = new List<SelectedTicket>();
        List<string> seatList = new List<string>();//座席選択画面から引き継いだ座席情報を格納

        string[] displayticketname = new string[0];//表示されるチケット名を格納
        int[] displayticketrate = new int[0];//表示されるチケット料金を格納
        string[] displayeventnumber = new string[0];//表示されるチケットのイベント番号を格納する。ただし、通常料金の場合も0で格納する
        string[] displaydefaultnumber = new string[0];//表示されるチケットの料金番号を格納する。ただし、イベント料金の場合も0で格納する

        private DropDownList[] TicketDDL;

        protected void Page_Load(object sender, EventArgs e)
        {
            //結合準備中
            Session["ScheduleID"] = "0000004";
            Session["ScheduleEnd"] = DateTime.Parse("2019/12/29 14:25:00");
            Session["MemberID"] = "0000007";
            seatList.Add("c4");
            seatList.Add("c5");
            seatList.Add("c6");
            Session["SeatInformation"] = seatList;
            Session["ScheduleStart"] = DateTime.Parse("2019/12/29 12:20:00");
            Session["WorkName"] = "アベンジャーズ／インフィニティ・ウォー";



            //画面結合時に前の画面からデータを継承する
            //ログイン中の場合会員情報を取得する
            //seatList = (List<string>)Session["seatInfomation"];//Sessionに格納されてる選択された座席情報を使えるようにseatListに展開する
            /************************************/
            /****ここからロードイベントの本体****/
            /************************************/
            int backflag = 0;
            if ((string)Session["PageID"] == "Reservation_Confirm_Input_Information_back" && !IsPostBack)
                backflag = 1;
            else if ((string)Session["PageID"] != "Seat" && !IsPostBack)//正規の手順でこのフォームを表示しなかった場合
            {
                /*
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
                Response.Redirect("https://www.yahoo.co.jp/");
                //Response.Redirect("Schedule.aspx");//TOP画面に飛ぶ
                return;
                 */
            }
            Session["PageID"] = "Reservation_Ticket_Selection";
            DateTime time = (DateTime)Session["ScheduleEnd"];
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            //イベントテーブル
            //その上映時に開催しているイベントの一覧を取得する
            //dtEvent.Rows[0][0]イベント番号、[0][1]イベント名、[0][2]イベント料金、[0][3]スケジュール番号、[0][4]料金番号
            OleDbDataAdapter daEvent = new OleDbDataAdapter("SELECT EVENT_ID,EVENT_NAME,EVENT_RATE,SCHEDULE_ID,RATE_ID FROM TBL_EVENT WHERE EVENT_STARTDAY<=#" + Session["ScheduleEnd"] + "# AND EVENT_ENDDAY>=#" + (DateTime)Session["ScheduleEnd"] + "# ORDER BY RATE_ID", cn);
            DataTable dtEvent = new DataTable();
            daEvent.Fill(dtEvent);
            int scheduleflag = 0;//スケジュール番号がnullでないイベントがあった時にフラグを立てる
            for (int i = 0; i < dtEvent.Rows.Count; i++)//スケジュール番号チェック
            {
                //スケジュール番号が登録されている場合
                if (dtEvent.Rows[i][3].ToString() != "")
                {
                    scheduleflag = 1;
                    Event tmp;
                    tmp = new Event(
                        int.Parse(dtEvent.Rows[i][2].ToString()), //イベント料金
                         dtEvent.Rows[i][1].ToString(), //イベント名
                        dtEvent.Rows[i][0].ToString(),  //イベント番号
                        "000" //変更する料金番号
                        );
                    eventList.Add(tmp);
                    break;
                }
            }
            //イベントListに該当する条件のイベントを格納する
            if (scheduleflag == 0)//スケジュール番号が登録されていなければ
            {
                for (int i = 0; i < dtEvent.Rows.Count; i++)//イベントテーブルに該当するイベントが登録されていたら
                {
                    if (dtEvent.Rows[i][4].ToString() == "ADD")//追加されるチケットを格納
                    {
                        AddEvent tmp = new AddEvent(
                            int.Parse(dtEvent.Rows[i][2].ToString()),   //追加イベント料金
                            dtEvent.Rows[i][1].ToString(),              //追加イベント名
                            dtEvent.Rows[i][0].ToString()               //イベント番号
                            );
                        addEventList.Add(tmp);
                    }
                    else//変更されるチケットを格納
                    {
                        Event tmp = new Event();
                        tmp = new Event(
                            int.Parse(dtEvent.Rows[i][2].ToString()), //イベント料金
                            dtEvent.Rows[i][1].ToString(), //イベント名
                            dtEvent.Rows[i][0].ToString(),  //イベント番号
                            "000" //変更する料金番号
                            );
                        eventList.Add(tmp);
                    }
                }
                //料金テーブル
                //上映終了時間が開始時間と終了時間の間に含まれる料金の一覧を取得する
                //dtRate.Rows[0][0]料金番号、[0][1]料金名、[0][2]料金
                OleDbDataAdapter daRate = new OleDbDataAdapter("SELECT RATE_ID,RATE_NAME,RATE_PRICE FROM TBL_RATE WHERE RATE_START<=#" + ((DateTime)Session["ScheduleEnd"]).TimeOfDay + "# AND RATE_END>=#" + ((DateTime)Session["ScheduleEnd"]).TimeOfDay + "# ORDER BY RATE_ID", cn);
                DataTable dtRate = new DataTable();
                daRate.Fill(dtRate);
                int ticketcount = 0;
                //表示されるチケットを確定させて格納する
                for (int i = 0; i < dtRate.Rows.Count; i++, ticketcount++)
                {
                    Array.Resize(ref displayeventnumber, i + 2);
                    Array.Resize(ref displaydefaultnumber, i + 2);
                    Array.Resize(ref displayticketname, i + 2);
                    Array.Resize(ref displayticketrate, i + 2);
                    int inflag = 0;
                    for (int j = 0; j < eventList.Count; j++)
                    {
                        if (dtRate.Rows[i][0].ToString() == eventList[j].price)//イベント料金番号が見つかれば
                        {
                            displayeventnumber[ticketcount] = eventList[j].price;//イベント料金番号を格納する
                            displaydefaultnumber[ticketcount] = "000";//通常料金番号を0として格納する
                            displayticketname[ticketcount] = eventList[j].name;//イベント料金名を格納する
                            displayticketrate[ticketcount] = eventList[j].rate;//イベント料金を格納する
                            inflag = 1;
                            break;
                        }
                    }
                    if (inflag == 0)//イベントがなければ
                    {
                        displayeventnumber[ticketcount] = "000";//イベント料金番号を0として格納する
                        displaydefaultnumber[ticketcount] = dtRate.Rows[i][0].ToString();//通常料金番号を格納する
                        displayticketname[ticketcount] = dtRate.Rows[i][1].ToString();//通常料金名を格納する
                        displayticketrate[ticketcount] = int.Parse(dtRate.Rows[i][2].ToString());//通常料金を格納する
                    }
                }
                for (int j = 0; j < addEventList.Count; j++, ticketcount++)
                {
                    Array.Resize(ref displayeventnumber, displayeventnumber.Length + 1);
                    Array.Resize(ref displaydefaultnumber, displaydefaultnumber.Length + 1);
                    Array.Resize(ref displayticketname, displayticketname.Length + 1);
                    Array.Resize(ref displayticketrate, displayticketrate.Length + 1);
                    displayeventnumber[ticketcount] = "000";
                    displaydefaultnumber[ticketcount] = "000";
                    displayticketname[ticketcount] = addEventList[j].name;
                    displayticketrate[ticketcount] = addEventList[j].rate;
                }
                if ((string)Session["MemberID"] != "")//ログインされていたら
                {
                    OleDbDataAdapter daMember = new OleDbDataAdapter("SELECT MEMBER_NAME,MEMBER_POINT FROM TBL_MEMBER WHERE MEMBER_ID='" + (string)Session["MemberID"] + "'", cn);
                    DataTable dtMember = new DataTable();
                    daMember.Fill(dtMember);
                    Session["MemberName"] = dtMember.Rows[0][0].ToString();
                    Session["MemberPoint"] = int.Parse(dtMember.Rows[0][1].ToString());
                    //ポイントテーブル
                    OleDbDataAdapter daPoint = new OleDbDataAdapter("SELECT POINT_GET,POINT_USE FROM TBL_POINT WHERE POINT_START<=#" + DateTime.Today.ToString() + "# AND POINT_END>=#" + DateTime.Today.ToString() + "#", cn);
                    DataTable dtPoint = new DataTable();
                    daPoint.Fill(dtPoint);
                    Session["PointGet"] = int.Parse(dtPoint.Rows[0][0].ToString());
                    Session["PointUse"] = int.Parse(dtPoint.Rows[0][1].ToString());
                    displayeventnumber[ticketcount] = "000";
                    displaydefaultnumber[ticketcount] = "000";
                    displayticketname[ticketcount] = dtPoint.Rows[0][1].ToString() + "ポイントで一回無料";
                    displayticketrate[ticketcount] = 0;
                }
            }
            //ClientScriptManager cs = Page.ClientScript;
            //Type csType = this.GetType();
            //cs.RegisterStartupScript(csType, "onload", "<script type=\"text/javascript\">alert('"+表示したい値+"');</script>");
            TableRow tableRow;
            TableCell tableCell;

            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "席番号";
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = "チケットの種類";
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);
            this.TicketDDL = new DropDownList[seatList.Count];
            for (int i = 0; i < seatList.Count; i++)
            {
                tableRow = new TableRow();
                tableCell = new TableCell();
                tableCell.Text = seatList[i];
                tableRow.Cells.Add(tableCell);
                tableCell = new TableCell();
                TicketDDL[i] = new DropDownList();
                //TicketDDL[i].ID =i.ToString();
                TicketDDL[i].Items.Add("チケットの種類を選択してください");
                if (scheduleflag == 0)//スケジュール番号が登録されていないからチケットの種類が一つに絞られない場合
                {
                    for (int j = 0; j < displayticketname.Length; j++)//表示チケット名配列の数だけ繰り返す
                        TicketDDL[i].Items.Add(displayticketname[j]);
                }
                else//スケジュール番号が登録されているからチケットが一種類しかない場合
                    TicketDDL[i].Items.Add(eventList[0].name);
                tableCell.Controls.Add(TicketDDL[i]);
                tableRow.Cells.Add(tableCell);
                Table1.Rows.Add(tableRow);
            }
            if ((string)Session["MemberID"] == "")
            {
                tableRow = new TableRow();
                tableCell = new TableCell();
                Button LoginLinkBtn = new Button();
                LoginLinkBtn.Text = "ログイン";
                LoginLinkBtn.Click += new System.EventHandler(this.LoginLinkBtn_Click);
                tableCell.Controls.Add(LoginLinkBtn);
                tableRow.Cells.Add(tableCell);
                tableCell = new TableCell();
                Button MemberFormLinkBtn = new Button();
                MemberFormLinkBtn.Text = "新規登録";
                MemberFormLinkBtn.Click += new System.EventHandler(this.MemberFormLinkBtn_Click);
                tableCell.Controls.Add(MemberFormLinkBtn);
                tableRow.Cells.Add(tableCell);
                Table1.Rows.Add(tableRow);
            }
            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "メールアドレス：";
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            MailAddressTextbox.MaxLength = 50;
            MailAddressTextbox.Width = 296;//セルのサイズが300の場合そこに入る最大サイズが296
            if (backflag == 1)
                MailAddressTextbox.Text = (string)Session["BookingMail"];
            tableCell.Controls.Add(MailAddressTextbox);
            tableCell.Width = Cell2Width;
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);

            tableRow = new TableRow();
            tableCell = new TableCell();
            BackBtn.Text = "戻る";
            BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            tableCell.Controls.Add(BackBtn);
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            NextBtn.Text = "次へ進む";
            NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            tableCell.Controls.Add(NextBtn);
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);
            if (backflag == 1)
            {
                List<int> TicketSelectList = new List<int>();
                TicketSelectList = (List<int>)Session["TicketSelectedIndexList"];
                for (int i = 0; i < TicketSelectList.Count; i++)
                    TicketDDL[i].SelectedIndex = TicketSelectList[i];
            }
        }

        protected void LoginLinkBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member_Login.aspx");
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reservation_Seat_Selection.aspx");
        }

        protected void NextBtn_Click(object sender, EventArgs e)
        {
            //DropDownList wrkdrop = new DropDownList();
            ////wrkdrop = (DropDownList) this.FindControl("MainContent_0");
            //wrkdrop = (DropDownList)this.Master.FindControl("MainContent").FindControl("Table1").FindControl("MainContent_0");
            //string str = wrkdrop.SelectedValue.ToString();
            List<int> TicketSelectList = new List<int>();
            int noSelectflag = 0;//選択されていないチケットがあったときにフラグが立つ
            int PointBuyCounter = 0;//ポイント支払いを選択した数を数える
            for (int i = 0; i < seatList.Count; i++)
            {
                if (TicketDDL[i].SelectedIndex == 0)
                {
                    noSelectflag = 1;
                    break;//for文のチェックを抜ける
                }
                else
                    TicketSelectList.Add(TicketDDL[i].SelectedIndex);//選択されたチケットのSelectedIndexを格納
                if (TicketDDL[i].Text == ((int)Session["PointUse"]).ToString() + "ポイントで一回無料")
                    PointBuyCounter++;
            }
            //入力項目の不備によるエラー表示
            if (noSelectflag == 1)
            {
                TableRow tableRow;
                TableCell tableCell;
                tableRow = new TableRow();
                tableCell = new TableCell();
                tableCell.Text = "チケットの種類を選択してください";
                tableCell.ColumnSpan = 2;
                tableRow.Cells.Add(tableCell);
                Table1.Rows.AddAt(seatList.Count + 3, tableRow);
                return;
            }
            if ((string)Session["MemberID"] != "")
            {
                if (PointBuyCounter * (int)Session["PointUse"] > (int)Session["MemberPoint"])
                {
                    TableRow tableRow;
                    TableCell tableCell;
                    tableRow = new TableRow();
                    tableCell = new TableCell();
                    tableCell.Text = "お客様のポイントが不足しています";
                    tableCell.ColumnSpan = 2;
                    tableRow.Cells.Add(tableCell);
                    Table1.Rows.AddAt(seatList.Count + 3, tableRow);
                    return;
                }
            }
            if (MailAddressTextbox.Text == "")
            {
                TableRow tableRow;
                TableCell tableCell;
                tableRow = new TableRow();
                tableCell = new TableCell();
                tableCell.Text = "メールアドレスを入力してください";
                tableCell.ColumnSpan = 2;
                tableRow.Cells.Add(tableCell);
                Table1.Rows.AddAt(seatList.Count + 3, tableRow);
                return;
            }
            if (FormatCheck.CheckMailAddressFormat(MailAddressTextbox.Text) == false)
            {
                TableRow tableRow;
                TableCell tableCell;
                tableRow = new TableRow();
                tableCell = new TableCell();
                tableCell.Text = "正しいメールアドレスではありません";
                tableCell.ColumnSpan = 2;
                tableRow.Cells.Add(tableCell);
                Table1.Rows.AddAt(seatList.Count + 3, tableRow);
                return;
            }
            Session["BookingMail"] = MailAddressTextbox.Text;//メールアドレス
            //DropDownListで選択されたチケットの種類をSelectedIndexで取得し、各種チケット配列の何番目かを見てそれぞれのSessionに配列(List)として格納する
            int[] SeatSelectedIndex = new int[seatList.Count];
            for (int i = 0; i < seatList.Count; i++)
            {
                //TicketDDL[i].SelectedIndexを表示されるチケット配列のにより何個目のDropDownListにおいて何個目のItemが選択されたかを取得できる
                SelectedTicket tmp;
                tmp = new SelectedTicket(
                    displayticketrate[TicketDDL[i].SelectedIndex - 1],//チケット料金
                    displayticketname[TicketDDL[i].SelectedIndex - 1],//チケット名
                    displayeventnumber[TicketDDL[i].SelectedIndex - 1],//イベント料金番号
                    displaydefaultnumber[TicketDDL[i].SelectedIndex - 1],//通常料金番号
                    seatList[i]//座席番号
                    );
                selectedticketList.Add(tmp);//4つの項目をListに加える
            }
            Session["TicketSelectedIndexList"] = TicketSelectList;//戻るボタンが押された時に選択した情報を反映するために保存
            Session["SelectedTicket"] = selectedticketList;//選択されたチケット情報をSessionに格納して次の画面に遷移する
            Response.Redirect("Reservation_Confirm_Input_Information.aspx");
            //ClientScriptManager cs = Page.ClientScript;
            //Type csType = this.GetType();
            //cs.RegisterStartupScript(csType, "onclick", "<script type=\"text/javascript\">location.replace('http://firebombar.com/');</script>");
        }

        protected void MemberFormLinkBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberForm.aspx");
        }
    }
}