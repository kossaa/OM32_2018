using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1
{
    public class FormatCheck
    {
        static Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");//文字コードを指定する

        public static bool CheckMailAddressFormat(string address)
        {
            try
            {
                System.Net.Mail.MailAddress mailAddress = new System.Net.Mail.MailAddress(address);
            }
            catch (FormatException)
            {
                //メールアドレスとしての文法エラー
                return false;
            }
            //文法エラーなしなら大文字チェック
            int num = sjisEnc.GetByteCount(address);
            return num == address.Length;
        }
    }
}