using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//杉本　2018_10_26
//全然できてないけどDBの接続方法参考用
namespace WebApplication1
{
    public partial class Event : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter da;
            da = new OleDbDataAdapter("SELECT EVENT_STARTDAY,EVENT_NAME FROM TBL_EVENT", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DayLabel1.Text = dt.Rows[0][0].ToString();
            DayLabel2.Text = dt.Rows[1][0].ToString();
            /*DayLabel3.Text = dt.Rows[2][0].ToString();
            DayLabel4.Text = dt.Rows[3][0].ToString();
            DayLabel5.Text = dt.Rows[4][0].ToString();
            DayLabel6.Text = dt.Rows[5][0].ToString();
            DayLabel7.Text = dt.Rows[6][0].ToString();
            DayLabel8.Text = dt.Rows[7][0].ToString();
            DayLabel9.Text = dt.Rows[8][0].ToString();
            DayLabel10.Text = dt.Rows[9][0].ToString();
            */

            NameLabel1.Text = dt.Rows[0][1].ToString();
            NameLabel2.Text = dt.Rows[1][1].ToString();
            /*NameLabel3.Text = dt.Rows[2][1].ToString();
            NameLabel4.Text = dt.Rows[3][1].ToString();
            NameLabel5.Text = dt.Rows[4][1].ToString();
            NameLabel6.Text = dt.Rows[5][1].ToString();
            NameLabel7.Text = dt.Rows[6][1].ToString();
            NameLabel8.Text = dt.Rows[7][1].ToString();
            NameLabel9.Text = dt.Rows[8][1].ToString();
            NameLabel10.Text = dt.Rows[9][1].ToString();
             */
            
        }
    }
}