using System;
using System.Data;
using System.Collections.Generic;
using Qrcms.Common;

namespace Qrcms.BLL
{
    /// <summary>
    /// 用户短信息
    /// </summary>
    public partial class user_message
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.user_message dal;
        public user_message()
        {
            dal = new DAL.user_message(siteConfig.sysdatabaseprefix);
        }

        #region 基本方法==============================
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
        public int Add(int type, string post_user_name, string accept_user_name, string title, string content)
        {
            Model.user_message model = new Model.user_message();
            model.type = type;
            model.post_user_name = post_user_name;
            model.accept_user_name = accept_user_name;
            model.title = title;
            model.content = content;
            return Add(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.user_message model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.user_message model)
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
        /// 根据用户名删除一条数据
        /// </summary>
        public bool Delete(int id, string user_name)
        {
            return dal.Delete(id, user_name);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.user_message GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion

        #region 扩展方法==============================
        /// <summary>
        /// 返回记录总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }
        #endregion
    }
}