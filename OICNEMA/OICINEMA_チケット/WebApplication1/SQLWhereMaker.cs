using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class SQLWhereMaker
    {
        //条件文に他の条件が存在しない場合
        public static string SQLMakeNoAND(List<string> receive,string ColumnName)
        {
            string connect = "";
            for (int i = 0; i < receive.Count; i++)
            {
                if (i != 0)
                {
                    connect = connect + " OR  ";
                }
                connect = connect + ColumnName + "='" + receive[i] + "'";
            }
            return connect;
        }

        //条件文に他の条件が存在する場合
        public static string SQLMakeAND(List<string> receive, string ColumnName)
        {
            string connect = "";
            for (int i = 0; i < receive.Count; i++)
            {
                if (i != 0)
                {
                    connect = connect + " OR  ";
                }
                else
                {
                    connect = connect + " AND ";
                }
                connect = connect + ColumnName + "='" + receive[i] + "'";
            }
            return connect;
        }
    }
}