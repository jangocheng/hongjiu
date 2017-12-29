﻿using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Qrcms.DBUtility;
using Qrcms.Common;
namespace Qrcms.DAL
{
    //auction
    public partial class auction
    {
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetListNew(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM dt_auction");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 增加一条数据并修改
        /// </summary>
        public int AddNew(Qrcms.Model.auction model, Model.siteconfig config)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_auction(");
            strSql.Append("no,title,quiz_no,quiz_result,quiz_date,create_user,create_time");
            strSql.Append(") values (");
            strSql.Append("@no,@title,@quiz_no,@quiz_result,@quiz_date,@create_user,@create_time");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@no", SqlDbType.VarChar,50) ,
                        new SqlParameter("@title", SqlDbType.VarChar,500) ,
                        new SqlParameter("@quiz_no", SqlDbType.Int,4) ,
                        new SqlParameter("@quiz_result", SqlDbType.Int,4) ,
                        new SqlParameter("@quiz_date", SqlDbType.DateTime),
                        new SqlParameter("@create_user", SqlDbType.VarChar,50) ,
                        new SqlParameter("@create_time", SqlDbType.DateTime)

            };

            parameters[0].Value = model.no;
            parameters[1].Value = model.title;
            parameters[2].Value = model.quiz_no;
            parameters[3].Value = model.quiz_result;
            parameters[4].Value = model.quiz_date;
            parameters[5].Value = model.create_user;
            parameters[6].Value = model.create_time;

            int m = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (m > 0)
            {
                pageHelper.WriteLog("M>0开始");
                DataTable tb = DbHelperSQL.Query("select quiz,id,order_amount from dt_orders where isnull(auction_no,'')='' and quiz_time <= '" + model.quiz_date.AddSeconds(-20).ToString("yyyy-MM-dd HH:mm:ss") + "' and Order_type=1 ").Tables[0];
                foreach (DataRow row in tb.Rows)
                {
                    pageHelper.WriteLog("for开始");
                    int quiz = Utils.ObjToInt(row["quiz"]);
                    int id = Utils.ObjToInt(row["id"]);
                    int _r = 2;
                    decimal performance = 0;//业绩
                    decimal cover_charge = config.cover_charge;

                    Model.orders modelOrderl = new orders(config.sysdatabaseprefix).GetModel(id);
                    if (modelOrderl != null)
                    {
                        decimal om = modelOrderl.real_amount;
                        if (modelOrderl.order_goods != null && modelOrderl.order_goods.Count > 0)
                        {
                            var goods = modelOrderl.order_goods[0];
                            if (model.quiz_result.ToString().IndexOf(quiz.ToString())!=-1)//时时彩中奖数包含客户选择数
                            {
                                _r = 1;
                                //中奖
                                cover_charge = 0;


                                var bllArticle = new article(config.sysdatabaseprefix);

                                //中奖
                                //大升级
                                var modelArticle = bllArticle.GetModel(Utils.ObjToInt(bllArticle.GetFiled("goods", "big_upgrade", " id=" + goods.article_id)));
                                if (modelArticle != null)
                                {
                                    //更新订单商品
                                    decimal sell_price = Utils.StrToDecimal(modelArticle.fields["sell_price"], 0);
                                    om = sell_price * goods.quantity;
                                    performance = (sell_price * goods.quantity) - (goods.real_price * goods.quantity);
                                    DbHelperSQL.ExecuteSql("update dt_order_goods set article_id=" + modelArticle.id + ",goods_title='" + modelArticle.title + "',img_url='" + modelArticle.img_url + "',goods_price=" + sell_price + ",real_price=" + sell_price + "  where id=" + goods.id);

                                }

                            }
                            else
                            {
                                performance = goods.real_price * goods.quantity - cover_charge;
                                performance = performance > 0 ? performance * -1 : performance;
                            }
                        }
                        StringBuilder strSql1 = new StringBuilder();
                        strSql1.Append(" UPDATE [dt_orders] SET");
                        strSql1.Append(" performance="+performance+ ",cover_charge="+cover_charge+", quiz_result=" + _r + " ,auction_no='" + model.no + "',order_amount=" + (om + modelOrderl.express_fee + modelOrderl.payment_fee + modelOrderl.invoice_taxes));
                        strSql1.Append(" where id=" + id + "");
                        DbHelperSQL.ExecuteSql(strSql1.ToString());
                    }

                }
               
            } return m;
        }


        public bool Exists(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_auction");
            strSql.Append(" where ");
            strSql.Append(" no = @no  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@no", SqlDbType.VarChar,50)           };
            parameters[0].Value = no;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取期数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetCount(int id, string auction_no)
        {
            string sql = "";
            object obj;
            if (!string.IsNullOrEmpty(auction_no))
            {
                Model.auction model = GetModel(auction_no);
                if (model.article_id == id)
                {
                    sql = "select layer from dt_auction where no='" + auction_no + "'";
                    obj = DbHelperSQL.GetSingle(sql);
                    if (obj == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt32(obj);
                    }
                }

            }
            sql = "select count(*) from dt_auction where article_id=" + id + "";
            obj = DbHelperSQL.GetSingle(sql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj) + 1;
            }

        }
        /// <summary>
        /// 获取文本编辑器信息
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public object GetDetails(string no)
        {
            string sql = "select describe from dt_auction where no='" + no + "'";
            return DbHelperSQL.GetSingle(sql);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Qrcms.Model.auction model)
        {
            //int layer = model.layer;
            ////再查下期数，避免多人操作，数据不准确
            //layer= GetCount(model.article_id,"");
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("insert into dt_auction(");
            //strSql.Append("no,title,article_id,layer,describe,banner,article_img,low_price,high_price,sale_price,avg_price,remark,create_user,create_time,article_title,avg_status,end_date,publish_date,recommend,float_num");
            //strSql.Append(") values (");
            //strSql.Append("@no,@title,@article_id,@layer,@describe,@banner,@article_img,@low_price,@high_price,@sale_price,@avg_price,@remark,@create_user,@create_time,@article_title,@avg_status,@end_date,@publish_date,@recommend,@float_num");
            //strSql.Append(") ");

            //SqlParameter[] parameters = {
            //   new SqlParameter("@no", SqlDbType.VarChar,50) ,            
            //            new SqlParameter("@title", SqlDbType.VarChar,500) ,            
            //            new SqlParameter("@article_id", SqlDbType.Int,4) ,            
            //            new SqlParameter("@layer", SqlDbType.Int,4) ,            
            //            new SqlParameter("@describe", SqlDbType.VarChar,5000) ,            
            //            new SqlParameter("@banner", SqlDbType.VarChar,200) ,            
            //            new SqlParameter("@article_img", SqlDbType.VarChar,200) ,            
            //            new SqlParameter("@low_price", SqlDbType.Decimal,9) ,            
            //            new SqlParameter("@high_price", SqlDbType.Decimal,9) ,            
            //            new SqlParameter("@sale_price", SqlDbType.Decimal,9) ,            
            //            new SqlParameter("@avg_price", SqlDbType.Decimal,9) ,            
            //            new SqlParameter("@remark", SqlDbType.VarChar,500) ,            
            //            new SqlParameter("@create_user", SqlDbType.VarChar,50) ,            
            //            new SqlParameter("@create_time", SqlDbType.DateTime) ,            
            //            new SqlParameter("@article_title", SqlDbType.VarChar,255) ,            
            //            new SqlParameter("@avg_status", SqlDbType.Int,4) ,            
            //            new SqlParameter("@end_date", SqlDbType.DateTime) ,            
            //            new SqlParameter("@publish_date", SqlDbType.DateTime) ,            
            //            new SqlParameter("@recommend", SqlDbType.Int,4) ,            
            //            new SqlParameter("@float_num", SqlDbType.Decimal,9)             

            //};

            //parameters[0].Value = model.no;
            //parameters[1].Value = model.title;
            //parameters[2].Value = model.article_id;
            //parameters[3].Value = layer;
            //parameters[4].Value = model.describe;
            //parameters[5].Value = model.banner;
            //parameters[6].Value = model.article_img;
            //parameters[7].Value = model.low_price;
            //parameters[8].Value = model.high_price;
            //parameters[9].Value = model.sale_price;
            //parameters[10].Value = model.avg_price;
            //parameters[11].Value = model.remark;
            //parameters[12].Value = model.create_user;
            //parameters[13].Value = model.create_time;
            //parameters[14].Value = model.article_title;
            //parameters[15].Value = model.avg_status;
            //parameters[16].Value = model.end_date;
            //parameters[17].Value = model.publish_date;
            //parameters[18].Value = model.recommend;
            //parameters[19].Value = model.float_num;
            //return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return 0;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Qrcms.Model.auction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_auction set ");

            strSql.Append(" no = @no , ");
            strSql.Append(" title = @title , ");
            strSql.Append(" article_id = @article_id , ");
            strSql.Append(" layer = @layer , ");
            strSql.Append(" describe = @describe , ");
            strSql.Append(" banner = @banner , ");
            strSql.Append(" article_img = @article_img , ");
            strSql.Append(" low_price = @low_price , ");
            strSql.Append(" high_price = @high_price , ");
            strSql.Append(" sale_price = @sale_price , ");
            strSql.Append(" avg_price = @avg_price , ");
            strSql.Append(" remark = @remark , ");
            strSql.Append(" create_user = @create_user , ");
            strSql.Append(" create_time = @create_time , ");
            strSql.Append(" article_title = @article_title , ");
            strSql.Append(" avg_status = @avg_status , ");
            strSql.Append(" end_date = @end_date , ");
            strSql.Append(" publish_date = @publish_date , ");
            strSql.Append(" recommend = @recommend , ");
            strSql.Append(" float_num = @float_num  ");
            strSql.Append(" where no=@no  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@no", SqlDbType.VarChar,50) ,
                        new SqlParameter("@title", SqlDbType.VarChar,500) ,
                        new SqlParameter("@article_id", SqlDbType.Int,4) ,
                        new SqlParameter("@layer", SqlDbType.Int,4) ,
                        new SqlParameter("@describe", SqlDbType.VarChar,5000) ,
                        new SqlParameter("@banner", SqlDbType.VarChar,200) ,
                        new SqlParameter("@article_img", SqlDbType.VarChar,200) ,
                        new SqlParameter("@low_price", SqlDbType.Decimal,9) ,
                        new SqlParameter("@high_price", SqlDbType.Decimal,9) ,
                        new SqlParameter("@sale_price", SqlDbType.Decimal,9) ,
                        new SqlParameter("@avg_price", SqlDbType.Decimal,9) ,
                        new SqlParameter("@remark", SqlDbType.VarChar,500) ,
                        new SqlParameter("@create_user", SqlDbType.VarChar,50) ,
                        new SqlParameter("@create_time", SqlDbType.DateTime) ,
                        new SqlParameter("@article_title", SqlDbType.VarChar,255) ,
                        new SqlParameter("@avg_status", SqlDbType.Int,4) ,
                        new SqlParameter("@end_date", SqlDbType.DateTime) ,
                        new SqlParameter("@publish_date", SqlDbType.DateTime) ,
                        new SqlParameter("@recommend", SqlDbType.Int,4) ,
                        new SqlParameter("@float_num", SqlDbType.Decimal,9)

            };

            parameters[0].Value = model.no;
            parameters[1].Value = model.title;
            parameters[2].Value = model.article_id;
            parameters[3].Value = model.layer;
            parameters[4].Value = model.describe;
            parameters[5].Value = model.banner;
            parameters[6].Value = model.article_img;
            parameters[7].Value = model.low_price;
            parameters[8].Value = model.high_price;
            parameters[9].Value = model.sale_price;
            parameters[10].Value = model.avg_price;
            parameters[11].Value = model.remark;
            parameters[12].Value = model.create_user;
            parameters[13].Value = model.create_time;
            parameters[14].Value = model.article_title;
            parameters[15].Value = model.avg_status;
            parameters[16].Value = model.end_date;
            parameters[17].Value = model.publish_date;
            parameters[18].Value = model.recommend;
            parameters[19].Value = model.float_num;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_auction ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
                    new SqlParameter("@no", SqlDbType.VarChar,50)           };
            parameters[0].Value = no;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM dt_auction");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList1(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,substring(title,1,20)t1,substring(article_title,1,20)t2 FROM dt_auction");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Qrcms.Model.auction GetModel(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no, title, article_id, layer, describe, banner, article_img, low_price, high_price, sale_price, avg_price, remark, create_user, create_time, article_title, avg_status, end_date, publish_date, recommend, float_num  ");
            strSql.Append("  from dt_auction ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
                    new SqlParameter("@no", SqlDbType.VarChar,50)           };
            parameters[0].Value = no;


            Qrcms.Model.auction model = new Qrcms.Model.auction();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.no = ds.Tables[0].Rows[0]["no"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                if (ds.Tables[0].Rows[0]["article_id"].ToString() != "")
                {
                    model.article_id = int.Parse(ds.Tables[0].Rows[0]["article_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["layer"].ToString() != "")
                {
                    model.layer = int.Parse(ds.Tables[0].Rows[0]["layer"].ToString());
                }
                model.describe = ds.Tables[0].Rows[0]["describe"].ToString();
                model.banner = ds.Tables[0].Rows[0]["banner"].ToString();
                model.article_img = ds.Tables[0].Rows[0]["article_img"].ToString();
                if (ds.Tables[0].Rows[0]["low_price"].ToString() != "")
                {
                    model.low_price = decimal.Parse(ds.Tables[0].Rows[0]["low_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["high_price"].ToString() != "")
                {
                    model.high_price = decimal.Parse(ds.Tables[0].Rows[0]["high_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sale_price"].ToString() != "")
                {
                    model.sale_price = decimal.Parse(ds.Tables[0].Rows[0]["sale_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["avg_price"].ToString() != "")
                {
                    model.avg_price = decimal.Parse(ds.Tables[0].Rows[0]["avg_price"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                model.create_user = ds.Tables[0].Rows[0]["create_user"].ToString();
                if (ds.Tables[0].Rows[0]["create_time"].ToString() != "")
                {
                    model.create_time = DateTime.Parse(ds.Tables[0].Rows[0]["create_time"].ToString());
                }
                model.article_title = ds.Tables[0].Rows[0]["article_title"].ToString();
                if (ds.Tables[0].Rows[0]["avg_status"].ToString() != "")
                {
                    model.avg_status = int.Parse(ds.Tables[0].Rows[0]["avg_status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["end_date"].ToString() != "")
                {
                    model.end_date = DateTime.Parse(ds.Tables[0].Rows[0]["end_date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["publish_date"].ToString() != "")
                {
                    model.publish_date = DateTime.Parse(ds.Tables[0].Rows[0]["publish_date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["recommend"].ToString() != "")
                {
                    model.recommend = int.Parse(ds.Tables[0].Rows[0]["recommend"].ToString());
                }
                if (ds.Tables[0].Rows[0]["float_num"].ToString() != "")
                {
                    model.float_num = decimal.Parse(ds.Tables[0].Rows[0]["float_num"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (!string.IsNullOrEmpty(top))
            {
                strSql.Append(" top " + top);
            }
            strSql.Append(" layer,no,article_id ");
            strSql.Append(" FROM dt_auction ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrEmpty(filedOrder))
            {
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetList(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM dt_auction ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrEmpty(filedOrder))
            {
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAuctionListByNo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [view_auction_infos] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM view_auction_recommend ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetAuctionList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM view_auction_recommend");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetReviewList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select [no]
                              ,[article_id]
                              ,[layer]
                              ,[article_img]
                              ,[sale_price]
                              ,[avg_price]
                              ,[create_time]
                              ,[end_date]
                              ,[publish_date]
	                          ,article_title FROM dt_auction");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        private string databaseprefix; //数据库表名前缀
        /// <summary>
        /// 删除一条数据，及子表所有相关数据
        /// </summary>
        public bool Delete(int id)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from " + databaseprefix + "order_goods ");
            strSql2.Append(" where order_id=@order_id ");
            SqlParameter[] parameters2 = {
                    new SqlParameter("@order_id", SqlDbType.Int,4)};
            parameters2[0].Value = id;
            CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "orders ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetFilter(string where, string filter)
        {
            return Utils.ObjectToStr(DbHelperSQL.GetSingle("select top 1 " + filter + " from dt_auction where " + where));
        }
        public DateTime GetMaxDate()
        {
            string str= Utils.ObjectToStr(DbHelperSQL.GetSingle("select top 1 quiz_date from dt_auction order by quiz_date desc"));
            if (string.IsNullOrEmpty(str)) {
                return DateTime.Now;
            }
            return Utils.StrToDateTime(str);
        }
        public bool ExitTitle(string title)
        {
            return Utils.ObjToInt(DbHelperSQL.GetSingle("select count(1) from dt_auction where title ='" + title + "'")) > 0;
        }
    }
}
