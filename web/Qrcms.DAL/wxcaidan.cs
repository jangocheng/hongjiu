using Qrcms.Common;
using Qrcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Qrcms.DAL
{
    public class wxcaidan
    {
        private string databaseprefix; //数据库表名前缀
        public wxcaidan(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int caidan_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "wxcaidan");
            strSql.Append(" where caidan_id=@caidan_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = caidan_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.wxcaidan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "wxcaidan(");
            strSql.Append("caidan_name,caidan_cid,caidan_type ,caidan_key ,caidan_retype ,caidan_retext ,caidan_url ,caidan_layid ,caidan_order ,caidan_addtime)");
            strSql.Append(" values (");
            strSql.Append("@caidan_name,@caidan_cid,@caidan_type ,@caidan_key ,@caidan_retype ,@caidan_retext ,@caidan_url ,@caidan_layid ,@caidan_order ,@caidan_addtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@caidan_name", SqlDbType.VarChar,50),
                    new SqlParameter("@caidan_cid", SqlDbType.Int),
                    new SqlParameter("@caidan_type", SqlDbType.NVarChar,50),
                    new SqlParameter("@caidan_key", SqlDbType.NVarChar,500),
                    new SqlParameter("@caidan_retype", SqlDbType.VarChar,50),
                    new SqlParameter("@caidan_retext", SqlDbType.VarChar,500),
                    new SqlParameter("@caidan_url", SqlDbType.NVarChar,500),
                    new SqlParameter("@caidan_layid", SqlDbType.Int),
                    new SqlParameter("@caidan_order", SqlDbType.Int),

                    new SqlParameter("@caidan_addtime", SqlDbType.DateTime),

            };
            parameters[0].Value = model.caidan_name;
            parameters[1].Value = model.caidan_cid;
            parameters[2].Value = model.caidan_type;
            parameters[3].Value = model.caidan_key;
            parameters[4].Value = model.caidan_retype;
            parameters[5].Value = model.caidan_retext;
            parameters[6].Value = model.caidan_url;
            parameters[7].Value = model.caidan_layid;
            parameters[8].Value = model.caidan_order;
            parameters[9].Value = model.caidan_addtime;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int caidan_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "wxcaidan ");
            strSql.Append(" where caidan_id=@caidan_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@caidan_id", SqlDbType.Int,4)};
            parameters[0].Value = caidan_id;

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
        /// 删除所有数据
        /// </summary>
        public bool DeleteAll()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "wxcaidan ");

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
       
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM " + databaseprefix + "wxcaidan ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        #endregion

        #region 扩展方法================================
       
        #endregion
    }
}
