using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Qrcms.Web.admin
{
    public partial class Qaptcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            string code = Command_StringPlus.RandomCode("verificationcode", 4, true);
            //Command_Session.Add("verificationcode", vVerificationCode.ToLower());   //Session中保存验证码
            //把验证码保存到cookie中
            Response.Cookies.Add(new HttpCookie("CheckCode", code.ToUpper()));
            CreateImage(code);
        }
        #region 验证码
        ///  <summary>
        ///  创建验证码图片
        ///  </summary>
        ///  <param  name="randomcode">验证码</param>
        private void CreateImage(string randomcode)
        {
            int randAngle = 40; //随机转动角度
            int mapwidth = (int)(randomcode.Length * 18);
            Bitmap map = new Bitmap(mapwidth, 32);//创建图片背景
            Graphics graph = Graphics.FromImage(map);
            graph.Clear(Color.White);//清除画面，填充背景
            //graph.DrawRectangle(new Pen(Color.Silver, 0), 0, 0, map.Width - 1, map.Height - 1);//画一个边框

            Random rand = new Random();

            //验证码旋转，防止机器识别
            char[] chars = randomcode.ToCharArray();//拆散字符串成单字符数组
            //文字距中
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            //定义颜色
            Color[] c = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.DarkBlue };

            //画图片的背景噪音线
            for (int i = 0; i < 1; i++)
            {
                int x1 = rand.Next(10);
                int x2 = rand.Next(map.Width - 10, map.Width);
                int y1 = rand.Next(map.Height);
                int y2 = rand.Next(map.Height);

                graph.DrawLine(new Pen(c[rand.Next(7)]), x1, y1, x2, y2);
            }

            for (int i = 0; i < chars.Length; i++)
            {
                int cindex = rand.Next(7);
                int findex = rand.Next(5);
                Font f = new System.Drawing.Font("宋体", 22, System.Drawing.FontStyle.Bold);//字体样式(参数2为字体大小)
                Brush b = new System.Drawing.SolidBrush(c[cindex]);
                Point dot = new Point(12, 16);
                float angle = rand.Next(-randAngle, randAngle);//转动的度数
                graph.TranslateTransform(dot.X, dot.Y);//移动光标到指定位置
                graph.RotateTransform(angle);
                graph.DrawString(chars[i].ToString(), f, b, 1, 1, format);
                graph.RotateTransform(-angle);//转回去
                graph.TranslateTransform(2, -dot.Y);//移动光标到指定位置
            }
            //生成图片
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            map.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "image/gif";
            Response.BinaryWrite(ms.ToArray());
            graph.Dispose();
            map.Dispose();
        }
        #endregion
    }

}