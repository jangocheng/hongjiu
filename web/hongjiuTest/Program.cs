using Qrcms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hongjiuTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //string password = "123456";
            //var salt = Utils.GetCheckCode(6);

            ////以随机生成的6位字符串做为密钥加密
            //var ps = DESEncrypt.Encrypt(password, salt);sinptech777

            var ss = DESEncrypt.Decrypt("29677F8118C101D3", "VXTNZ6");
        }
    }
}
