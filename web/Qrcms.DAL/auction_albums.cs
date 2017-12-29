using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Qrcms.DBUtility;
namespace Qrcms.DAL  
{
	 	//图片相册
		public partial class auction_albums
	{
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_auction_albums");
			strSql.Append(" where ");
			                                       strSql.Append(" id = @id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Qrcms.Model.auction_albums model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_auction_albums(");			
            strSql.Append("no,thumb_path,original_path,remark,add_time");
			strSql.Append(") values (");
            strSql.Append("@no,@thumb_path,@original_path,@remark,@add_time");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@no", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@thumb_path", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@original_path", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = model.no;                        
            parameters[1].Value = model.thumb_path;                        
            parameters[2].Value = model.original_path;                        
            parameters[3].Value = model.remark;                        
            parameters[4].Value = model.add_time;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
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
		public bool Update(Qrcms.Model.auction_albums model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_auction_albums set ");
			                                                
            strSql.Append(" no = @no , ");                                    
            strSql.Append(" thumb_path = @thumb_path , ");                                    
            strSql.Append(" original_path = @original_path , ");                                    
            strSql.Append(" remark = @remark , ");                                    
            strSql.Append(" add_time = @add_time  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@no", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@thumb_path", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@original_path", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@remark", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.no;                        
            parameters[2].Value = model.thumb_path;                        
            parameters[3].Value = model.original_path;                        
            parameters[4].Value = model.remark;                        
            parameters[5].Value = model.add_time;                        
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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_auction_albums ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;


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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_auction_albums ");
			strSql.Append(" where ID in ("+idlist + ")  ");
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
		public Qrcms.Model.auction_albums GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, no, thumb_path, original_path, remark, add_time  ");			
			strSql.Append("  from dt_auction_albums ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			Qrcms.Model.auction_albums model=new Qrcms.Model.auction_albums();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.no= ds.Tables[0].Rows[0]["no"].ToString();
																																model.thumb_path= ds.Tables[0].Rows[0]["thumb_path"].ToString();
																																model.original_path= ds.Tables[0].Rows[0]["original_path"].ToString();
																																model.remark= ds.Tables[0].Rows[0]["remark"].ToString();
																												if(ds.Tables[0].Rows[0]["add_time"].ToString()!="")
				{
					model.add_time=DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
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
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM dt_auction_albums ");
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
			strSql.Append(" * ");
			strSql.Append(" FROM dt_auction_albums ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

