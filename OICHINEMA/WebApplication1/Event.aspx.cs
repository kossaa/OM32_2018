
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
    public partial class Event : System.Web.UI.Page
    {
        private String WeekDayString(int weeknum)
        {
            switch(weeknum){
                case 1: return "日曜日";
                case 2: return "月曜日";
                case 3: return "火曜日";
                case 4: return "水曜日";
                case 5: return "木曜日";
                case 6: return "金曜日";
                case 7: return "土曜日";
                default: return " ";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int dtcnt;
            int cnt;

            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter da;

            da = new OleDbDataAdapter("SELECT COUNT(*) FROM TBL_EVENT WHERE EVENT_STARTDAY>Date()", cn);
            DataTable dtc = new DataTable();
            da.Fill(dtc);
            dtcnt = int.Parse(dtc.Rows[0][0].ToString());

            DataTable dt = new DataTable();
            da = new OleDbDataAdapter("SELECT format(EVENT_STARTDAY,'M月D日'),EVENT_NAME,EVENT_COMMENT,WeekDay(EVENT_STARTDAY),EVENT_ENDDAY FROM TBL_EVENT WHERE EVENT_STARTDAY>Date()", cn);
            da.Fill(dt);

            da = new OleDbDataAdapter("SELECT EVENT_ENDDAY-EVENT_STARTDAY FROM TBL_EVENT",cn);
            DataTable test = new DataTable();
            da.Fill(test);
            TestLabel.Text = test.Rows[0][0].ToString();


            cnt = dtcnt;
            while (cnt > 0)
            {
                switch (cnt)
                {
                    case 1: 
                        DayLabel1.Text = dt.Rows[dtcnt - dtcnt][0].ToString();
                        WeekDayLabel1.Text = WeekDayString(int.Parse(dt.Rows[dtcnt - dtcnt][3].ToString()));
                        NameLabel1.Text = dt.Rows[dtcnt - dtcnt][1].ToString();
                        DetailLabel1.Text = dt.Rows[dtcnt - dtcnt][2].ToString();
                        break;
                    case 2: 
                        DayLabel2.Text = dt.Rows[dtcnt - (dtcnt-1)][0].ToString();
                        WeekDayLabel2.Text = WeekDayString(int.Parse(dt.Rows[dtcnt - (dtcnt - 1)][3].ToString()));
                        NameLabel2.Text = dt.Rows[dtcnt - (dtcnt - 1)][1].ToString();
                        DetailLabel2.Text = dt.Rows[dtcnt - (dtcnt - 1)][2].ToString();
                        break;
                    case 3: 
                        DayLabel3.Text = dt.Rows[dtcnt - (dtcnt-2)][0].ToString();
                        WeekDayLabel3.Text = WeekDayString(int.Parse(dt.Rows[dtcnt - (dtcnt - 2)][3].ToString()));
                        NameLabel3.Text = dt.Rows[dtcnt - (dtcnt - 2)][1].ToString();
                        DetailLabel3.Text = dt.Rows[dtcnt - (dtcnt - 2)][2].ToString();
                        break;
                    case 4: 
                        DayLabel4.Text = dt.Rows[dtcnt - (dtcnt-3)][0].ToString();
                        WeekDayLabel4.Text = WeekDayString(int.Parse(dt.Rows[dtcnt - (dtcnt - 3)][3].ToString()));
                        NameLabel4.Text = dt.Rows[dtcnt - (dtcnt - 3)][1].ToString();
                        DetailLabel4.Text = dt.Rows[dtcnt - (dtcnt - 3)][2].ToString();
                        break;
                    case 5: 
                        DayLabel5.Text = dt.Rows[dtcnt - (dtcnt-4)][0].ToString();
                        WeekDayLabel5.Text = WeekDayString(int.Parse(dt.Rows[dtcnt - (dtcnt - 4)][3].ToString()));
                        NameLabel5.Text = dt.Rows[dtcnt - (dtcnt - 4)][1].ToString();
                        DetailLabel5.Text = dt.Rows[dtcnt - (dtcnt - 4)][2].ToString();
                        break;
                    case 6:
                        DayLabel6.Text = dt.Rows[dtcnt - (dtcnt-5)][0].ToString();
                        WeekDayLabel6.Text = WeekDayString(int.Parse(dt.Rows[dtcnt - (dtcnt - 5)][3].ToString()));
                        NameLabel6.Text = dt.Rows[dtcnt - (dtcnt - 5)][1].ToString();
                        DetailLabel6.Text = dt.Rows[dtcnt - (dtcnt - 5)][2].ToString();
                        break;
                    case 7: 
                        DayLabel7.Text = dt.Rows[dtcnt - (dtcnt-6)][0].ToString();
                        WeekDayLabel7.Text = WeekDayString(int.Parse(dt.Rows[dtcnt - (dtcnt - 6)][3].ToString()));
                        NameLabel7.Text = dt.Rows[dtcnt - (dtcnt - 6)][1].ToString();
                        DetailLabel7.Text = dt.Rows[dtcnt - (dtcnt - 6)][2].ToString();
                        break;
                    case 8:
                        DayLabel8.Text = dt.Rows[dtcnt - (dtcnt-7)][0].ToString();
                        WeekDayLabel8.Text = WeekDayString(int.Parse(dt.Rows[dtcnt - (dtcnt - 7)][3].ToString()));
                        NameLabel8.Text = dt.Rows[dtcnt - (dtcnt - 7)][1].ToString();
                        DetailLabel8.Text = dt.Rows[dtcnt - (dtcnt - 7)][2].ToString();
                        break;
                    case 9:
                        DayLabel9.Text = dt.Rows[dtcnt - (dtcnt-8)][0].ToString();
                        WeekDayLabel9.Text = WeekDayString(int.Parse(dt.Rows[dtcnt - (dtcnt - 8)][3].ToString()));
                        NameLabel9.Text = dt.Rows[dtcnt - (dtcnt - 8)][1].ToString();
                        DetailLabel9.Text = dt.Rows[dtcnt - (dtcnt - 8)][2].ToString();
                        break;
                    case 10:
                        DayLabel10.Text = dt.Rows[dtcnt - (dtcnt-9)][0].ToString();
                        WeekDayLabel10.Text = WeekDayString(int.Parse(dt.Rows[dtcnt - (dtcnt - 9)][3].ToString()));
                        NameLabel10.Text = dt.Rows[dtcnt - (dtcnt - 9)][1].ToString();
                        DetailLabel10.Text = dt.Rows[dtcnt - (dtcnt - 9)][2].ToString();
                        break;
                }
                cnt--;
            }
        }
    }
}

