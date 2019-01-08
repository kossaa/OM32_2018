using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class SQLWhereMaker
    {
        //一つ目の引数に複数条件に指定したい同じColumnのデータが入ったstring型のリスト
        //二つ目の引数にColumn名を格納

        //WHERE句内のこの関数の呼出し命令より左に他の条件が存在しない場合
        public static string SQLMakeNoAND(List<string> receive,string ColumnName)
        {
            string connect = " (";
            for (int i = 0; i < receive.Count; i++)
            {
                if (i != 0)
                {
                    connect = connect + " OR  ";
                }
                connect = connect + ColumnName + "='" + receive[i] + "'";
            }
            connect = connect + ")";
            return connect;
        }

        //WHERE句内のこの関数の呼出し命令より左に他の条件が存在する場合
        public static string SQLMakeAND(List<string> receive, string ColumnName)
        {
            string connect = " AND (";
            for (int i = 0; i < receive.Count; i++)
            {
                if (i != 0)
                {
                    connect = connect + " OR  ";
                }
                connect = connect + ColumnName + "='" + receive[i] + "'";
            }
            connect = connect + ")";
            return connect;
        }
    }
}