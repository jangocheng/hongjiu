using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Qrcms.DBUtility;
using Qrcms.Common;

namespace Qrcms.DAL
{
    /// <summary>
    /// 数据访问类:提现记录
    /// </summary>
    public partial class txjl
    {

        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_txjl");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Qrcms.Model.txjl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_txjl(");
            strSql.Append("[user_name],[bank_name],[bank_card],[bank_username],[money],[sxf],[status],[audit_time],[audit_remark],[createtime]");
            strSql.Append(") values (");
            strSql.Append("@user_name,@bank_name,@bank_card,@bank_username,@money,@sxf,@status,@audit_time,@audit_remark,@createtime");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@user_name", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@bank_name", SqlDbType.VarChar,255) ,                       
                        new SqlParameter("@bank_card", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@bank_username", SqlDbType.VarChar,100) ,   
                        new SqlParameter("@money",SqlDbType.Decimal,5),
                        new SqlParameter("@sxf",SqlDbType.Decimal,5),
                        new SqlParameter("@status",SqlDbType.Int,4),
                        new SqlParameter("@audit_time",SqlDbType.DateTime),
                        new SqlParameter("@audit_remark",SqlDbType.VarChar,500),
                        new SqlParameter("@createtime", SqlDbType.DateTime)                        
            };
            parameters[0].Value = model.user_name;
            parameters[1].Value = model.bank_name;
            parameters[2].Value = model.bank_card;
            parameters[3].Value = model.bank_username;
            parameters[4].Value = model.money;
            parameters[5].Value = model.sxf;
            parameters[6].Value = model.status;
            parameters[7].Value = model.audit_time;
            parameters[8].Value = model.audit_remark;
            parameters[9].Value = model.createtime;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Qrcms.Model.txjl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_txjl set ");

            strSql.Append(" [user_name] = @user_name , ");
            strSql.Append(" [bank_name] = @bank_name , ");
            strSql.Append(" [bank_card] = @bank_card , ");
            strSql.Append(" [bank_username] = @bank_username , ");
            strSql.Append(" [money]=@money , ");
            strSql.Append(" [sxf]=@sxf , ");
            strSql.Append(" [status]=@status , ");
            strSql.Append(" [audit_time]=@audit_time , ");
            strSql.Append(" [audit_remark]=@audit_remark ,");
            strSql.Append(" [createtime] = @createtime  ");
            strSql.Append(" where id=@id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@user_name", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@bank_name", SqlDbType.VarChar,255) ,                       
                        new SqlParameter("@bank_card", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@bank_username", SqlDbType.VarChar,100) ,   
                        new SqlParameter("@money",SqlDbType.Decimal,5),
                        new SqlParameter("@sxf",SqlDbType.Decimal,5),
                        new SqlParameter("@status",SqlDbType.Int,4),
                        new SqlParameter("@audit_time",SqlDbType.DateTime),
                        new SqlParameter("@audit_remark",SqlDbType.VarChar,500),
                        new SqlParameter("@createtime", SqlDbType.DateTime),
                        new SqlParameter("@id",SqlDbType.Int,4)
            };
            parameters[0].Value = model.user_name;
            parameters[1].Value = model.bank_name;
            parameters[2].Value = model.bank_card;
            parameters[3].Value = model.bank_username;
            parameters[4].Value = model.money;
            parameters[5].Value = model.sxf;
            parameters[6].Value = model.status;
            parameters[7].Value = model.audit_time;
            parameters[8].Value = model.audit_remark;
            parameters[9].Value = model.createtime;
            parameters[10].Value = model.id;
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
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_txjl ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

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

        public bool DeleteNew(string Where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_txjl ");
            strSql.Append(" where " + Where);

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
            strSql.Append("select * FROM  dt_txjl");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 查询结果返回dt
        /// </summary>
        /// <param name="Selectzd"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public DataTable Select(string Selectzd,string Where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Selectzd + " ");
            strSql.Append("FROM dt_txjl");
            strSql.Append(" where " + Where);
            
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable dt = ds.Tables[0];
            return dt;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Qrcms.Model.txjl GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [id],[user_name],[bank_name],[bank_card],[bank_username],[money],[sxf],[status],[audit_time],[audit_remark],[createtime]  ");
            strSql.Append("  from dt_txjl ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;


            Qrcms.Model.txjl model = new Qrcms.Model.txjl();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                model.bank_name = ds.Tables[0].Rows[0]["bank_name"].ToString();
                model.bank_card = ds.Tables[0].Rows[0]["bank_card"].ToString();
                model.bank_username = ds.Tables[0].Rows[0]["bank_username"].ToString();
                model.money = Convert.ToDouble(ds.Tables[0].Rows[0]["money"].ToString());
                model.sxf = Convert.ToDouble(ds.Tables[0].Rows[0]["sxf"].ToString());
                model.status = Convert.ToInt32(ds.Tables[0].Rows[0]["status"].ToString());
                model.audit_time = Utils.StrToDateTime(ds.Tables[0].Rows[0]["audit_time"].ToString());
                model.audit_remark = ds.Tables[0].Rows[0]["audit_remark"].ToString();
                model.createtime = Utils.StrToDateTime(ds.Tables[0].Rows[0]["createtime"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }

        private string databaseprefix; //数据库表名前缀

        public string GetFilter(string where, string filter)
        {
            return Utils.ObjectToStr(DbHelperSQL.GetSingle("select top 1 " + filter + " from dt_txjl where " + where));
        }
    }
}

