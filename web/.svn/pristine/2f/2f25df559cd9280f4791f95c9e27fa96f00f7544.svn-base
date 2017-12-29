/** 
//
//
//      ┏┛ ┻━━━━━┛ ┻┓
//      ┃　　　　　　 ┃
//      ┃　　　━　　　┃
//      ┃　┳┛　  ┗┳　┃
//      ┃　　　　　　 ┃
//      ┃　　　┻　　　┃
//      ┃　　　　　　 ┃
//      ┗━┓　　　┏━━━┛
//        ┃　　　┃   神兽保佑
//        ┃　　　┃   代码无BUG！
//        ┃　　　┗━━━━━━━━━┓
//        ┃　　　　　　　    ┣┓
//        ┃　　　　         ┏┛
//        ┗━┓ ┓ ┏━━━┳ ┓ ┏━┛
//          ┃ ┫ ┫   ┃ ┫ ┫
//          ┗━┻━┛   ┗━┻━┛

* fensi.cs
* 类 名： fensi
*   2016/11/1 17:06:57  
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Qrcms.DBUtility;//Please add references
namespace Qrcms.DAL
{
	/// <summary>
	/// 数据访问类:fensi
	/// </summary>
	public partial class fensi
	{
		public fensi()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string openid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_fensi");
			strSql.Append(" where openid=@openid ");
			SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.VarChar,100)			};
			parameters[0].Value = openid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Qrcms.Model.fensi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_fensi(");
			strSql.Append("openid,headimg,nickname,parentid)");
			strSql.Append(" values (");
			strSql.Append("@openid,@headimg,@nickname,@parentid)");
			SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@headimg", SqlDbType.VarChar,200),
					new SqlParameter("@nickname", SqlDbType.VarChar,100),
					new SqlParameter("@parentid", SqlDbType.VarChar,50)};
			parameters[0].Value = model.openid;
			parameters[1].Value = model.headimg;
			parameters[2].Value = model.nickname;
			parameters[3].Value = model.parentid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Qrcms.Model.fensi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_fensi set ");
			strSql.Append("headimg=@headimg,");
			strSql.Append("nickname=@nickname,");
			strSql.Append("parentid=@parentid");
			strSql.Append(" where openid=@openid ");
			SqlParameter[] parameters = {
					new SqlParameter("@headimg", SqlDbType.VarChar,200),
					new SqlParameter("@nickname", SqlDbType.VarChar,100),
					new SqlParameter("@parentid", SqlDbType.VarChar,50),
					new SqlParameter("@openid", SqlDbType.VarChar,100)};
			parameters[0].Value = model.headimg;
			parameters[1].Value = model.nickname;
			parameters[2].Value = model.parentid;
			parameters[3].Value = model.openid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string openid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_fensi ");
			strSql.Append(" where openid=@openid ");
			SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.VarChar,100)			};
			parameters[0].Value = openid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string openidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_fensi ");
			strSql.Append(" where openid in ("+openidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Qrcms.Model.fensi GetModel(string openid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 openid,headimg,nickname,parentid from dt_fensi ");
			strSql.Append(" where openid=@openid ");
			SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.VarChar,100)			};
			parameters[0].Value = openid;

			Qrcms.Model.fensi model=new Qrcms.Model.fensi();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Qrcms.Model.fensi DataRowToModel(DataRow row)
		{
			Qrcms.Model.fensi model=new Qrcms.Model.fensi();
			if (row != null)
			{
				if(row["openid"]!=null)
				{
					model.openid=row["openid"].ToString();
				}
				if(row["headimg"]!=null)
				{
					model.headimg=row["headimg"].ToString();
				}
				if(row["nickname"]!=null)
				{
					model.nickname=row["nickname"].ToString();
				}
				if(row["parentid"]!=null)
				{
					model.parentid=row["parentid"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select openid,headimg,nickname,parentid ");
			strSql.Append(" FROM dt_fensi ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" openid,headimg,nickname,parentid ");
			strSql.Append(" FROM dt_fensi ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM dt_fensi ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.openid desc");
			}
			strSql.Append(")AS Row, T.*  from dt_fensi T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "dt_fensi";
			parameters[1].Value = "openid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

