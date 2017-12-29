using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Qrcms.Common;
using Qrcms.Model;
namespace Qrcms.BLL {
	 	//图片相册
		public partial class auction_albums
	{
   		     
		private readonly Qrcms.DAL.auction_albums dal=new Qrcms.DAL.auction_albums();
		public auction_albums()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Qrcms.Model.auction_albums model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Qrcms.Model.auction_albums model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Qrcms.Model.auction_albums GetModel(int id)
		{
			
			return dal.GetModel(id);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Qrcms.Model.auction_albums> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Qrcms.Model.auction_albums> DataTableToList(DataTable dt)
		{
			List<Qrcms.Model.auction_albums> modelList = new List<Qrcms.Model.auction_albums>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Qrcms.Model.auction_albums model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Qrcms.Model.auction_albums();					
													if(dt.Rows[n]["id"].ToString()!="")
				{
					model.id=int.Parse(dt.Rows[n]["id"].ToString());
				}
																																				model.no= dt.Rows[n]["no"].ToString();
																																model.thumb_path= dt.Rows[n]["thumb_path"].ToString();
																																model.original_path= dt.Rows[n]["original_path"].ToString();
																																model.remark= dt.Rows[n]["remark"].ToString();
																												if(dt.Rows[n]["add_time"].ToString()!="")
				{
					model.add_time=DateTime.Parse(dt.Rows[n]["add_time"].ToString());
				}
																										
				
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
#endregion
   
	}
}