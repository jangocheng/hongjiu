using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Qrcms.Model
{
    //dt_auction_order
    public class auction_order
    {
        /// <summary>
        /// 收货地址id
        /// </summary>
        public int accept_id { set; get; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal amount { set; get; }
        /// <summary>
        /// 期数
        /// </summary>
        public int layer { set; get; }
        /// <summary>
        /// 主键，订单编号
        /// </summary>		
        private string _no;
        public string no
        {
            get { return _no; }
            set { _no = value; }
        }
        /// <summary>
        /// 会员名
        /// </summary>		
        private string _user_name;
        public string user_name
        {
            get { return _user_name; }
            set { _user_name = value; }
        }
        /// <summary>
        /// 竞拍编号
        /// </summary>		
        private string _a_no;
        public string a_no
        {
            get { return _a_no; }
            set { _a_no = value; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>		
        private int _article_id;
        public int article_id
        {
            get { return _article_id; }
            set { _article_id = value; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>		
        private string _article_title;
        public string article_title
        {
            get { return _article_title; }
            set { _article_title = value; }
        }
        /// <summary>
        /// 收货人姓名
        /// </summary>		
        private string _accept_name;
        public string accept_name
        {
            get { return _accept_name; }
            set { _accept_name = value; }
        }
        /// <summary>
        /// 收货人手机号
        /// </summary>		
        private string _accept_mobile;
        public string accept_mobile
        {
            get { return _accept_mobile; }
            set { _accept_mobile = value; }
        }
        /// <summary>
        /// 收货人地址，省市区+详细地址
        /// </summary>		
        private string _accept_address;
        public string accept_address
        {
            get { return _accept_address; }
            set { _accept_address = value; }
        }
        /// <summary>
        /// 订单状态： 已付款、 开奖中、待发货、已发货、已完成
        /// </summary>		
        private int _status;
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 购买数量
        /// </summary>		
        private int _quantity;
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        /// <summary>
        /// 购买价格
        /// </summary>		
        private decimal _price;
        public decimal price
        {
            get { return _price; }
            set { _price = value; }
        }
        /// <summary>
        /// 购买时间
        /// </summary>		
        private DateTime _createdate;
        public DateTime createdate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// 物流单号
        /// </summary>		
        private string _express_no;
        public string express_no
        {
            get { return _express_no; }
            set { _express_no = value; }
        }
        /// <summary>
        /// 发货时间
        /// </summary>		
        private DateTime _express_time;
        public DateTime express_time
        {
            get { return _express_time; }
            set { _express_time = value; }
        }
        /// <summary>
        /// 快递id
        /// </summary>		
        private int _express_id;
        public int express_id
        {
            get { return _express_id; }
            set { _express_id = value; }
        }
        /// <summary>
        /// 运费
        /// </summary>		
        private decimal _express_fee;
        public decimal express_fee
        {
            get { return _express_fee; }
            set { _express_fee = value; }
        }
        /// <summary>
        /// 中奖状态：待开奖、已中奖、未中奖
        /// </summary>		
        private int _win_status;
        public int win_status
        {
            get { return _win_status; }
            set { _win_status = value; }
        }
        /// <summary>
        /// 商品图片
        /// </summary>		
        private string _article_img;
        public string article_img
        {
            get { return _article_img; }
            set { _article_img = value; }
        }
        /// <summary>
        /// 竞拍标题
        /// </summary>		
        private string _a_title;
        public string a_title
        {
            get { return _a_title; }
            set { _a_title = value; }
        }

    }
}

