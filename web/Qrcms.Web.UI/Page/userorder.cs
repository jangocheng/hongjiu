using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using Qrcms.Common;


namespace Qrcms.Web.UI.Page
{
    public partial class userorder : Web.UI.UserPage
    {
        protected string action = string.Empty;
        protected int page;         //当前页码
        protected int totalcount;   //OUT数据总数

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {
            action = DTRequest.GetQueryString("action");
            page = DTRequest.GetQueryInt("page", 1);
        }
        public string show_btn(DataRow row)
        {
            //<a href="caijiou.aspx?id={dr[id]}" class="shengji">升级</a>
            //<a href="chaihb.aspx?id={dr[id]}" class="hongbao">红包</a>
            //<a href="javascript:void(0);" class="tuihuo" data-no="{dr[order_no]}">退货</a>
            //<a href="javascript:void(0);" class="tihuo" data-no="{dr[order_no]}">提货</a>
            //<a href="caijiou.aspx?id={dr[id]}" class="shengji">提款</a>
            string mes = "";
            //1生成订单,2确认订单,3完成订单,4取消订单,5作废订单
            if (row != null)
            {
                int status = Utils.ObjToInt(row["status"]);
                int express_status = Utils.ObjToInt(row["express_status"]);//1-待，2-已
                int payment_status = Utils.ObjToInt(row["payment_status"]);
                int is_upgrade = Utils.ObjToInt(row["is_upgrade"]);//1是
                int Order_type = Utils.ObjToInt(row["Order_type"]);//0-普通，1-升级，2-红包
                int quiz_result = Utils.ObjToInt(row["quiz_result"]);//0-未开，1-中奖，2-未中
                string accept_name = Utils.ObjectToStr(row["accept_name"]);
                if (status == 2)
                {
                    if (payment_status == 2)
                    {
                        if (Order_type == 0 && express_status != 2)
                        {
                            if (string.IsNullOrEmpty(accept_name))
                            {
                                mes += "<a href=\"javascript:void(0);\" class=\"tuihuo\" data-no=\"" + row["order_no"] + "\" style=\"width: 54px;\">退货</a>";
                            }
                        }
                        if (string.IsNullOrEmpty(accept_name))
                        {
                            if (Order_type == 0 || quiz_result !=0)
                            {
                                mes += "<a href=\"javascript: void(0);\" class=\"tihuo\" data-no=\"" + row["order_no"] + "\" data-quantity=\"" + row["quantity"] + "\" style=\"width: 54px;\">提货</a>";
                            }
                        }
                        if (string.IsNullOrEmpty(accept_name) && Order_type == 0 && is_upgrade == 1)
                        {
                            mes += "<a href=\"caijiou.aspx?order_no=" + row["order_no"] + "&id=" + row["id"] + "\" class=\"shengji\" style=\"width: 54px;\">鸡藕</a>";
                            mes += "<a href=\"chaihb.aspx?order_no="+row["order_no"]+"&id=" + row["id"] + "\" class=\"hongbao\" style=\"display:none;\">红包</a>";
                            mes += "<a href=\"caidaxiao.aspx?order_no=" + row["order_no"] + "&id=" + row["id"] + "\" class=\"shengji\" style=\"width: 54px;\">大中小</a>";
                            mes += "<a href=\"cainiuniu.aspx?order_no=" + row["order_no"] + "&id=" + row["id"] + "\" class=\"shengji\" style=\"width: 54px;\">牛牛</a>";
                        }
                        if (is_upgrade == 1 && quiz_result == 1 && string.IsNullOrEmpty(accept_name))
                        {

                            mes += "<a href=\"/mobile/upgrade_show.aspx?id=" + row["id"] + "\" class=\"shengji\" style=\"width: 54px;\">提款</a>";

                        }
                    }

                }
                else if (status == 3)
                {

                }
                else
                {

                }

            }
            return mes;
        }
        public string show_status(DataRow row)
        {
            string mes = "";
            //1生成订单,2确认订单,3完成订单,4取消订单,5作废订单
            if (row != null)
            {
                int status = Utils.ObjToInt(row["status"]);
                int express_status = Utils.ObjToInt(row["express_status"]);//1-待，2-已
                int payment_status = Utils.ObjToInt(row["payment_status"]);
                int is_upgrade = Utils.ObjToInt(row["is_upgrade"]);//1是
                int Order_type = Utils.ObjToInt(row["Order_type"]);//0-普通，1-升级，2-红包
                int quiz_result = Utils.ObjToInt(row["quiz_result"]);//0-未开，1-中奖，2-未中
                string accept_name = Utils.ObjectToStr(row["accept_name"]);
                if (status == 1)
                {
                    mes += "<span class=\"dzf\">待支付</span>";
                }
                else if (status == 2)
                {
                    if (payment_status == 2)
                    {
                      //  mes += "<span class=\"yzf\">已支付</span>";

                    }
                    if (express_status == 2)
                    {
                        mes += "<span class=\"yfh\">已发货</span>";

                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(accept_name))
                        {
                            mes += "<span class=\"dfh\">待发货</span>";
                        }
                        else
                        {
                            if (Order_type == 0)
                            {
                                mes += "<span class=\"dth\">待提货</span>";
                            }
                        }
                    }
                }
                else if (status == 3)
                {
                    mes += "<span class=\"ywc\">已完成</span>";
                }
                else
                {
                    mes += "<span class=\"yqx\">已取消</span>";
                }
                if (status <= 3)
                {
                    if (is_upgrade == 1)

                    {
                        if (quiz_result == 0)
                        {
                            mes += "<span class=\"dkj\">待开奖</span>";
                        }
                        if (quiz_result == 1)
                        {
                            mes += "<span class=\"yzj\">已中奖</span>";
                        }
                        if (quiz_result == 2)
                        {
                            mes += "<span class=\"wzj\">未中奖</span>";
                        }
                    }
                }
            }
            return mes;

        }
        public Model.cart_items get_article(string order_no)
        {
            Model.orders order = new BLL.orders().GetModel(order_no);
            return get_article(order);
        }
        public Model.cart_items get_article(Model.orders model)
        {
            if (model != null)
            {
                if (model.order_goods != null && model.order_goods.Count > 0)
                {

                    var goods = model.order_goods[0];
                    //var bllArticle = new BLL.article();
                    //if (model.quiz_result == 1)
                    //{
                    //    //中奖
                    //    var modelArticle = bllArticle.GetModel(Utils.ObjToInt(bllArticle.GetFiled("goods", "big_upgrade", " id=" + goods.article_id)));
                    //    if (modelArticle != null)
                    //    {
                    //        return new Model.cart_items() { article_id = modelArticle.id, goods_id =0, goods_no = "", img_url = modelArticle.img_url, point = goods.point, quantity = goods.quantity, sell_price =Utils.StrToDecimal(modelArticle.fields["sell_price"],0), spec_text = goods.spec_text, stock_quantity = 0, title = modelArticle.title, user_price = Utils.StrToDecimal(modelArticle.fields["sell_price"],0) };
                    //    }
                    //}
                    //else
                    //{

                        return new Model.cart_items() { article_id = goods.article_id, goods_id = goods.goods_id, goods_no = goods.goods_no, img_url = goods.img_url, point = goods.point, quantity = goods.quantity, sell_price = goods.real_price, spec_text = goods.spec_text, stock_quantity = 0, title = goods.goods_title, user_price = goods.real_price };
                  //  }
                }
            }
            return new Model.cart_items();
        }
    }
}
