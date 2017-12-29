using Qrcms.API.Weixin.Common;
using Qrcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using ThoughtWorks.QRCode.Codec;

namespace Qrcms.Web.UI.Page
{

    public partial class wx_ewm : Web.UI.UserPage
    {
        JavaScriptSerializer Jss = new JavaScriptSerializer();
        protected string pre_login_time = string.Empty;
        protected string tuijiantruename = "";
        protected string turl = string.Empty;
        protected string erweima = "";

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {
            //try
            //{
           
            string token = string.Empty; //与微信公众账号后台的Token设置保持一致，区分大小写。
            int uid = 0;
            BLL.weixin_account bllweixin = new BLL.weixin_account();
            DataTable dtweixin = bllweixin.GetList("").Tables[0];
            pageHelper.WriteLog("获取数据");
            if (dtweixin.Rows.Count > 0)
            {
                uid = Convert.ToInt32(dtweixin.Rows[0]["id"]);
            }
            pageHelper.WriteLog("获取数据2");
            CRMComm comm = new CRMComm();
            pageHelper.WriteLog("获取数据3");
            string error = "";
            token = comm.GetAccessToken(uid, out error); //获取公众账户的ToKen


            string id = userModel.id.ToString();

            string data = postticket(token, id);

            string picurl = userModel.avatar;
            string newpicurl = userModel.avatar;
            if (picurl.IndexOf("http://") > -1)
            {
                newpicurl = CRMComm.downRemoteImgup("upload/", picurl);
            }
            System.Drawing.Image erweimanew = geterweima(data, newpicurl);


            System.Drawing.Image newimg1 = erweimanew;
            if (newpicurl != null && newpicurl != "")
            {
                System.Drawing.Image touxiang = System.Drawing.Image.FromFile(Server.MapPath("~" + newpicurl));
                newimg1 = CombinImage2(erweimanew, touxiang, 2);
                touxiang.Dispose();
            }


            string filename = Server.MapPath("~/upload/img/" + userModel.id + ".png");
            newimg1.Save(filename);
            erweimanew.Dispose();
            newimg1.Dispose();
            erweima = "/upload/img/" + userModel.id + ".png";
            //}
            //catch (Exception ex)
            //{
            //    pageHelper.WriteLog(ex.StackTrace); ; ;
            //}

        }
        /// <summary>    
        /// 调用此函数后使此两种图片合并，类似相册，有个    
        /// 背景图，中间贴自己的目标图片    
        /// </summary>    
        /// <param name="imgBack">粘贴的源图片</param>    
        /// <param name="destImg">粘贴的目标图片</param>    
        private System.Drawing.Image CombinImage2(System.Drawing.Image imgBack, System.Drawing.Image destImg, int zeshu)
        {
            if (destImg.Height != 85 || destImg.Width != 85)
            {
                destImg = KiResizeImage(destImg, 85, 85, 0);
            }
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);     

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框    

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);    

            g.DrawImage(destImg, imgBack.Width / 2 - 220, 20, destImg.Width, destImg.Height);
            GC.Collect();

            return imgBack;
        }
        /// <summary>    
        /// 调用此函数后使此两种图片合并，类似相册，有个    
        /// 背景图，中间贴自己的目标图片    
        /// </summary>    
        /// <param name="imgBack">粘贴的源图片</param>    
        /// <param name="destImg">粘贴的目标图片</param>    
        private System.Drawing.Image CombinImage1(System.Drawing.Image imgBack, System.Drawing.Image destImg, int zeshu)
        {

            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);     

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框    

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);    

            g.DrawImage(destImg, imgBack.Width / 2 - destImg.Width / 2, (imgBack.Width / 2 - destImg.Width / 2) + zeshu, destImg.Width, destImg.Height);
            GC.Collect();
            return imgBack;
        }

        private System.Drawing.Image geterweima(string data, string Qr_headimgUrl)
        {

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 5;
            qrCodeEncoder.QRCodeVersion = 8;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            System.Drawing.Image image = qrCodeEncoder.Encode(data);
            System.IO.MemoryStream MStream = new System.IO.MemoryStream();
            image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png);

            System.Drawing.Image imgg = image;
            if (Qr_headimgUrl != null && Qr_headimgUrl != "")
            {
                imgg = CombinImage(image, HttpContext.Current.Server.MapPath("~" + Qr_headimgUrl + ""));
            }



            return imgg;


        }
        /// <summary>    
        /// 调用此函数后使此两种图片合并，类似相册，有个    
        /// 背景图，中间贴自己的目标图片    
        /// </summary>    
        /// <param name="imgBack">粘贴的源图片</param>    
        /// <param name="destImg">粘贴的目标图片</param>    
        private System.Drawing.Image CombinImage(System.Drawing.Image imgBack, string destImg)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(destImg);        //照片图片      
            if (img.Height != 65 || img.Width != 65)
            {
                img = KiResizeImage(img, 65, 65, 0);
            }
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);     

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框    

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);    

            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }


        /// <summary>    
        /// Resize图片    
        /// </summary>    
        /// <param name="bmp">原始Bitmap</param>    
        /// <param name="newW">新的宽度</param>    
        /// <param name="newH">新的高度</param>    
        /// <param name="Mode">保留着，暂时未用</param>    
        /// <returns>处理以后的图片</returns>    
        private System.Drawing.Image KiResizeImage(System.Drawing.Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                System.Drawing.Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量    
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }


        #region 临时二维码请求说明
        private string postticket(string access_token, string Qr_UserId)
        {
            string respText = "";
            string erweimaJson = "{\"expire_seconds\": 2591000, \"action_name\": \"QR_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": " + Qr_UserId + "}}}";

            string postUrl = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}";
            string url = string.Format(postUrl, access_token);
            byte[] requestBytes = Encoding.UTF8.GetBytes(erweimaJson);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = requestBytes.Length;

            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(requestBytes, 0, requestBytes.Length);
                reqStream.Flush();
                reqStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();//返回来自inertnet的响应

            using (Stream resStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(resStream, Encoding.Default);
                respText = reader.ReadToEnd();
                resStream.Close();
            }


            Dictionary<string, object> respDic = (Dictionary<string, object>)Jss.DeserializeObject(respText);

            return respDic["url"].ToString();//发送返回的错误码

        }
        #endregion 发送文本
        /// <summary>
        /// 文字水印
        /// </summary>
        /// <param name="imgPath">服务器图片相对路径</param>
        /// <param name="filename">保存文件名</param>
        /// <param name="watermarkText">水印文字</param>
        /// <param name="watermarkStatus">图片水印位置 0=不使用 1=左上 2=中上 3=右上 4=左中  9=右下</param>
        /// <param name="quality">附加水印图片质量,0-100</param>
        /// <param name="fontname">字体</param>
        /// <param name="fontsize">字体大小</param>
        private System.Drawing.Image AddImageSignText(System.Drawing.Image imgPath, string watermarkText, int watermarkStatus, int quality, string fontname, int fontsize)
        {
            System.Drawing.Image img = null;
            Graphics g = Graphics.FromImage(imgPath);
            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Font drawFont = new Font(fontname, fontsize, FontStyle.Regular, GraphicsUnit.Pixel);
            SizeF crSize;
            crSize = g.MeasureString(watermarkText, drawFont);

            float xpos = 0;
            float ypos = 0;
            if (watermarkText.Length > 8)
            {
                xpos = ((float)imgPath.Width * (float).50) - (crSize.Width / 2) + 100;
            }
            else
            {
                xpos = ((float)imgPath.Width * (float).50) - (crSize.Width / 2) + 30;
            }
            ypos = (float)imgPath.Height * (float).01 + 30;

            g.DrawString(watermarkText, drawFont, new SolidBrush(Color.White), xpos, ypos);

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo ici = null;
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType.IndexOf("jpeg") > -1)
                    ici = codec;
            }
            EncoderParameters encoderParams = new EncoderParameters();
            long[] qualityParam = new long[1];
            if (quality < 0 || quality > 100)
                quality = 80;

            qualityParam[0] = quality;

            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualityParam);
            encoderParams.Param[0] = encoderParam;

            img = imgPath;
            g.Dispose();
            return img;

        }

    }
}
