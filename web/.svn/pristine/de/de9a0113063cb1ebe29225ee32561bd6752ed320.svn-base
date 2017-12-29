using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Qrcms.DBUtility;
using System.IO;
using Qrcms.Common;
namespace Qrcms.DAL
{
    //dt_auction_order
    public partial class auction_order
    {
        /// <summary>
        /// 修改平均价
        /// </summary>
        /// <param name="filed"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool UpdateAvg(string filed, string where)
        {
            string sql = "update dt_auction set " + filed + " where " + where + "";
            return DbHelperSQL.ExecuteSql(sql) > 0 ? true : false;
        }

        /// <summary>
        /// 修改字段
        /// </summary>
        /// <param name="filed"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool UpdateFiled(string filed, string where)
        {
            string sql = "update dt_auction_order set " + filed + " where " + where + "";
            return DbHelperSQL.ExecuteSql(sql) > 0 ? true : false;
        }

        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_auction_order");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }

            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 竞拍订单表详情查询
        /// </summary>
        public bool Exists1(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_auction_order");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }

            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  [no]
                                  ,[status]
                                  ,[quantity]
                                  ,[price]
                                  ,[createdate]
                                  ,[win_status]
                                  ,[article_img]
                                  ,[a_title]
                                  ,a_no
                                  ,article_id
                                  ,layer
	                           FROM dt_auction_order");
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
            strSql.Append(@"select  [no]
                                  ,[user_name]
                                  ,[status]
                                  ,[quantity]
                                  ,[price]
                                  ,[createdate]
                                  ,[win_status]
                                  ,[article_img]
                                  ,[a_title]
                                  ,substring(article_title,1,30)t1
                                  ,a_no
                                  ,article_id
                                  ,layer
	                           FROM dt_auction_order");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Qrcms.Model.auction_order model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();

                        #region 订单表
                        strSql.Append("insert into dt_auction_order(");
                        strSql.Append("no,user_name,a_no,article_id,article_title,status,quantity,price,createdate,win_status,article_img,a_title,amount,layer");
                        strSql.Append(") values (");
                        strSql.Append("@no,@user_name,@a_no,@article_id,@article_title,@status,@quantity,@price,@createdate,@win_status,@article_img,@a_title,@amount,@layer");
                        strSql.Append(") ");

                        SqlParameter[] parameters = {
                        new SqlParameter("@no", SqlDbType.VarChar,50) ,
                        new SqlParameter("@user_name", SqlDbType.VarChar,50) ,
                        new SqlParameter("@a_no", SqlDbType.VarChar,50) ,
                        new SqlParameter("@article_id", SqlDbType.Int,4) ,
                        new SqlParameter("@article_title", SqlDbType.VarChar,255) ,
                        new SqlParameter("@status", SqlDbType.Int,4) ,
                        new SqlParameter("@quantity", SqlDbType.Int,4) ,
                        new SqlParameter("@price", SqlDbType.Decimal,9) ,
                        new SqlParameter("@createdate", SqlDbType.DateTime) ,
                        new SqlParameter("@win_status", SqlDbType.Int,4) ,
                        new SqlParameter("@article_img", SqlDbType.VarChar,200) ,
                        new SqlParameter("@a_title", SqlDbType.VarChar,500),
                        new SqlParameter("@amount", SqlDbType.Decimal,9) ,
                         new SqlParameter("@layer", SqlDbType.Int,4)

            };

                        parameters[0].Value = model.no;
                        parameters[1].Value = model.user_name;
                        parameters[2].Value = model.a_no;
                        parameters[3].Value = model.article_id;
                        parameters[4].Value = model.article_title;
                        parameters[5].Value = model.status;
                        parameters[6].Value = model.quantity;
                        parameters[7].Value = model.price;
                        parameters[8].Value = model.createdate;
                        parameters[9].Value = model.win_status;
                        parameters[10].Value = model.article_img;
                        parameters[11].Value = model.a_title;
                        parameters[12].Value = model.amount;
                        parameters[13].Value = model.layer;
                        DbHelperSQL.ExecuteSql(conn, tran, strSql.ToString(), parameters);
                        #endregion

                        #region 用户表余额
                        strSql = new StringBuilder();
                        //执行扣取账户金额
                        Model.user_amount_log log = new Model.user_amount_log();
                        log.user_id = Convert.ToInt32(DbHelperSQL.GetSingle("select id from dt_users where user_name='" + model.user_name + "'"));
                        log.user_name = model.user_name;
                        log.value = -model.amount;
                        log.remark = "竞拍商品，单号：" + model.no;
                        log.lx = "竞拍消费";
                        decimal amount = Convert.ToDecimal(DbHelperSQL.GetSingle("select amount from dt_users where id=" + log.user_id));
                        strSql.Append("insert into dt_user_amount_log(");
                        strSql.Append("user_id,user_name,value,remark,add_time,balance,lx)");
                        strSql.Append(" values (");
                        strSql.Append("@user_id,@user_name,@value,@remark,@add_time,@balance,@lx)");
                        SqlParameter[] parameter = {
                    new SqlParameter("@user_id", SqlDbType.Int,4),
                    new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                    new SqlParameter("@value", SqlDbType.Decimal,5),
                    new SqlParameter("@remark", SqlDbType.NVarChar,500),
                    new SqlParameter("@add_time", SqlDbType.DateTime),
                    new SqlParameter("@balance", SqlDbType.Decimal),
                    new SqlParameter("@lx", SqlDbType.NVarChar,50)};
                        parameter[0].Value = log.user_id;
                        parameter[1].Value = log.user_name;
                        parameter[2].Value = log.value;
                        parameter[3].Value = log.remark;
                        parameter[4].Value = log.add_time;
                        parameter[5].Value = log.value + amount;
                        parameter[6].Value = log.lx;// log.value > 0 ? "收入" : "支出";

                        DbHelperSQL.ExecuteSql(conn, tran, strSql.ToString(), parameter);

                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("update dt_users set amount=amount-" + log.value);
                        strSql2.Append(" where id=@id");
                        SqlParameter[] parameters2 = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters2[0].Value = log.user_id;
                        DbHelperSQL.ExecuteSql(conn, tran, strSql2.ToString(), parameters2);

                        #endregion

                        tran.Commit();
                        conn.Close();
                        conn.Dispose();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        conn.Close();
                        conn.Dispose();
                        return false;
                    }
                }
            }


        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Qrcms.Model.auction_order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_auction_order set ");

            strSql.Append(" no = @no , ");
            strSql.Append(" user_name = @user_name , ");
            strSql.Append(" a_no = @a_no , ");
            strSql.Append(" article_id = @article_id , ");
            strSql.Append(" article_title = @article_title , ");
            strSql.Append(" accept_name = @accept_name , ");
            strSql.Append(" accept_mobile = @accept_mobile , ");
            strSql.Append(" accept_address = @accept_address , ");
            strSql.Append(" status = @status , ");
            strSql.Append(" quantity = @quantity , ");
            strSql.Append(" price = @price , ");
            strSql.Append(" createdate = @createdate , ");
            strSql.Append(" express_no = @express_no , ");
            strSql.Append(" express_time = @express_time , ");
            strSql.Append(" express_id = @express_id , ");
            strSql.Append(" express_fee = @express_fee , ");
            strSql.Append(" win_status = @win_status , ");
            strSql.Append(" article_img = @article_img , ");
            strSql.Append(" a_title = @a_title  ");
            strSql.Append(" where no=@no  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@no", SqlDbType.VarChar,50) ,
                        new SqlParameter("@user_name", SqlDbType.VarChar,50) ,
                        new SqlParameter("@a_no", SqlDbType.VarChar,50) ,
                        new SqlParameter("@article_id", SqlDbType.Int,4) ,
                        new SqlParameter("@article_title", SqlDbType.VarChar,255) ,
                        new SqlParameter("@accept_name", SqlDbType.VarChar,50) ,
                        new SqlParameter("@accept_mobile", SqlDbType.VarChar,50) ,
                        new SqlParameter("@accept_address", SqlDbType.VarChar,500) ,
                        new SqlParameter("@status", SqlDbType.Int,4) ,
                        new SqlParameter("@quantity", SqlDbType.Int,4) ,
                        new SqlParameter("@price", SqlDbType.Decimal,9) ,
                        new SqlParameter("@createdate", SqlDbType.DateTime) ,
                        new SqlParameter("@express_no", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@express_time", SqlDbType.DateTime) ,
                        new SqlParameter("@express_id", SqlDbType.Int,4) ,
                        new SqlParameter("@express_fee", SqlDbType.Decimal,9) ,
                        new SqlParameter("@win_status", SqlDbType.Int,4) ,
                        new SqlParameter("@article_img", SqlDbType.VarChar,200) ,
                        new SqlParameter("@a_title", SqlDbType.VarChar,500)

            };

            parameters[0].Value = model.no;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.a_no;
            parameters[3].Value = model.article_id;
            parameters[4].Value = model.article_title;
            parameters[5].Value = model.accept_name;
            parameters[6].Value = model.accept_mobile;
            parameters[7].Value = model.accept_address;
            parameters[8].Value = model.status;
            parameters[9].Value = model.quantity;
            parameters[10].Value = model.price;
            parameters[11].Value = model.createdate;
            parameters[12].Value = model.express_no;
            parameters[13].Value = model.express_time;
            parameters[14].Value = model.express_id;
            parameters[15].Value = model.express_fee;
            parameters[16].Value = model.win_status;
            parameters[17].Value = model.article_img;
            parameters[18].Value = model.a_title;
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
            strSql.Append("delete from dt_auction_order ");
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
        /// 得到一个对象实体
        /// </summary>
        public Qrcms.Model.auction_order GetModel(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no, user_name, a_no, article_id, article_title, accept_name, accept_mobile, accept_address, status, quantity, price, createdate,  express_no, express_time, express_id, express_fee, win_status, article_img, a_title ,accept_id,layer ");
            strSql.Append("  from dt_auction_order ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
                    new SqlParameter("@no", SqlDbType.VarChar,50)           };
            parameters[0].Value = no;


            Qrcms.Model.auction_order model = new Qrcms.Model.auction_order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.no = ds.Tables[0].Rows[0]["no"].ToString();
                model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                model.a_no = ds.Tables[0].Rows[0]["a_no"].ToString();
                if (ds.Tables[0].Rows[0]["article_id"].ToString() != "")
                {
                    model.article_id = int.Parse(ds.Tables[0].Rows[0]["article_id"].ToString());
                }
                model.article_title = ds.Tables[0].Rows[0]["article_title"].ToString();
                model.accept_name = ds.Tables[0].Rows[0]["accept_name"].ToString();
                model.accept_mobile = ds.Tables[0].Rows[0]["accept_mobile"].ToString();
                model.accept_address = ds.Tables[0].Rows[0]["accept_address"].ToString();
                if (ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["accept_id"].ToString() != "")
                {
                    model.accept_id = int.Parse(ds.Tables[0].Rows[0]["accept_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["layer"].ToString() != "")
                {
                    model.layer = int.Parse(ds.Tables[0].Rows[0]["layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["quantity"].ToString() != "")
                {
                    model.quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["price"].ToString() != "")
                {
                    model.price = decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["createdate"].ToString() != "")
                {
                    model.createdate = DateTime.Parse(ds.Tables[0].Rows[0]["createdate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["express_no"].ToString() != "")
                {
                    model.express_no = ds.Tables[0].Rows[0]["express_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["express_time"].ToString() != "")
                {
                    model.express_time = DateTime.Parse(ds.Tables[0].Rows[0]["express_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["express_id"].ToString() != "")
                {
                    model.express_id = int.Parse(ds.Tables[0].Rows[0]["express_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["express_fee"].ToString() != "")
                {
                    model.express_fee = decimal.Parse(ds.Tables[0].Rows[0]["express_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["win_status"].ToString() != "")
                {
                    model.win_status = int.Parse(ds.Tables[0].Rows[0]["win_status"].ToString());
                }
                model.article_img = ds.Tables[0].Rows[0]["article_img"].ToString();
                model.a_title = ds.Tables[0].Rows[0]["a_title"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 通过竞拍编码得到一个对象实体
        /// </summary>
        public Qrcms.Model.auction_order GetModelbya_no(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no, user_name, a_no, article_id, article_title, accept_name, accept_mobile, accept_address, status, quantity, price, createdate, express_no, express_time, express_id, express_fee, win_status, article_img, a_title  ");
            strSql.Append("  from dt_auction_order ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
                    new SqlParameter("@no", SqlDbType.VarChar,50)           };
            parameters[0].Value = no;


            Qrcms.Model.auction_order model = new Qrcms.Model.auction_order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.no = ds.Tables[0].Rows[0]["no"].ToString();
                model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                model.a_no = ds.Tables[0].Rows[0]["a_no"].ToString();
                if (ds.Tables[0].Rows[0]["article_id"].ToString() != "")
                {
                    model.article_id = int.Parse(ds.Tables[0].Rows[0]["article_id"].ToString());
                }
                model.article_title = ds.Tables[0].Rows[0]["article_title"].ToString();
                model.accept_name = ds.Tables[0].Rows[0]["accept_name"].ToString();
                model.accept_mobile = ds.Tables[0].Rows[0]["accept_mobile"].ToString();
                model.accept_address = ds.Tables[0].Rows[0]["accept_address"].ToString();
                if (ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["quantity"].ToString() != "")
                {
                    model.quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["price"].ToString() != "")
                {
                    model.price = decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["createdate"].ToString() != "")
                {
                    model.createdate = DateTime.Parse(ds.Tables[0].Rows[0]["createdate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["express_no"].ToString() != "")
                {
                    model.express_no = ds.Tables[0].Rows[0]["express_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["express_time"].ToString() != "")
                {
                    model.express_time = DateTime.Parse(ds.Tables[0].Rows[0]["express_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["express_id"].ToString() != "")
                {
                    model.express_id = int.Parse(ds.Tables[0].Rows[0]["express_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["express_fee"].ToString() != "")
                {
                    model.express_fee = decimal.Parse(ds.Tables[0].Rows[0]["express_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["win_status"].ToString() != "")
                {
                    model.win_status = int.Parse(ds.Tables[0].Rows[0]["win_status"].ToString());
                }
                model.article_img = ds.Tables[0].Rows[0]["article_img"].ToString();
                model.a_title = ds.Tables[0].Rows[0]["a_title"].ToString();

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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM dt_auction_order ");
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
            strSql.Append(" FROM dt_auction_order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

