using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Qrcms.DBUtility;
using Qrcms.Common;
namespace Qrcms.DAL
{
    //dt_auction_comment
    public partial class auction_comment
    {

        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_auction_comment");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM dt_auction_comment");
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
        public DataSet GetCommentList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM view_auction_comment");
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
        public int Add(Qrcms.Model.auction_comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_auction_comment(");
            strSql.Append("auction_no,article_id,user_name,title,content,add_time,remark");
            strSql.Append(") values (");
            strSql.Append("@auction_no,@article_id,@user_name,@title,@content,@add_time,@remark");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@auction_no", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@article_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@user_name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@title", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@content", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = model.auction_no;
            parameters[1].Value = model.article_id;
            parameters[2].Value = model.user_name;
            parameters[3].Value = model.title;
            parameters[4].Value = model.content;
            parameters[5].Value = model.add_time;
            parameters[6].Value = model.remark;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt32(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Qrcms.Model.auction_comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_auction_comment set ");

            strSql.Append(" auction_no = @auction_no , ");
            strSql.Append(" article_id = @article_id , ");
            strSql.Append(" user_name = @user_name , ");
            strSql.Append(" title = @title , ");
            strSql.Append(" content = @content , ");
            strSql.Append(" add_time = @add_time , ");
            strSql.Append(" remark = @remark  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@auction_no", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@article_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@user_name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@title", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@content", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.auction_no;
            parameters[2].Value = model.article_id;
            parameters[3].Value = model.user_name;
            parameters[4].Value = model.title;
            parameters[5].Value = model.content;
            parameters[6].Value = model.add_time;
            parameters[7].Value = model.remark;
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
            strSql.Append("delete from dt_auction_comment ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
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

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_auction_comment ");
            strSql.Append(" where ID in (" + idlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public Qrcms.Model.auction_comment GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, auction_no, article_id, user_name, title, content, add_time, remark  ");
            strSql.Append("  from dt_auction_comment ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Qrcms.Model.auction_comment model = new Qrcms.Model.auction_comment();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.auction_no = ds.Tables[0].Rows[0]["auction_no"].ToString();
                if (ds.Tables[0].Rows[0]["article_id"].ToString() != "")
                {
                    model.article_id = int.Parse(ds.Tables[0].Rows[0]["article_id"].ToString());
                }
                model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();

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
            strSql.Append(" FROM dt_auction_comment ");
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
            strSql.Append(" FROM dt_auction_comment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

