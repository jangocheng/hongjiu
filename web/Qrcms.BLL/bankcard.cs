﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Qrcms.Common;
using Qrcms.Model;

namespace Qrcms.BLL
{
    /// <summary>
    /// 数据访问类:银行卡
    /// </summary>
   public partial class bankcard
	{

       private readonly Qrcms.DAL.bankcard dal = new Qrcms.DAL.bankcard();
        public bankcard()
        { }

		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Qrcms.Model.bankcard model)
		{
            return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Qrcms.Model.bankcard model)
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

        public bool DeleteNew(string Where)
        {
            return dal.DeleteNew(Where);
        }

        public DataTable Select(string Selectzd, string Where)
        {
            return dal.Select(Selectzd, Where);
        }
        public int GetUserCount(string user_name)
        {
            return dal.GetUserCount(user_name);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Qrcms.Model.bankcard GetModel(int id)
		{
			
			return dal.GetModel(id);
		}
        public string GetFilter(string where, string filter)
        {
            return dal.GetFilter(where, filter);
        }
            #endregion

        }
}