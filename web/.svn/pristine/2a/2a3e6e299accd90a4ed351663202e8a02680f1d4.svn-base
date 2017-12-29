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
using System.Collections.Generic;
using Qrcms.Common;
using Qrcms.Model;
namespace Qrcms.BLL
{
	/// <summary>
	/// fensi
	/// </summary>
	public partial class fensi
	{
		private readonly Qrcms.DAL.fensi dal=new Qrcms.DAL.fensi();
		public fensi()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string openid)
		{
			return dal.Exists(openid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Qrcms.Model.fensi model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Qrcms.Model.fensi model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string openid)
		{
			
			return dal.Delete(openid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string openidlist )
		{
			return dal.DeleteList(openidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Qrcms.Model.fensi GetModel(string openid)
		{
			
			return dal.GetModel(openid);
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
		public List<Qrcms.Model.fensi> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Qrcms.Model.fensi> DataTableToList(DataTable dt)
		{
			List<Qrcms.Model.fensi> modelList = new List<Qrcms.Model.fensi>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Qrcms.Model.fensi model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

