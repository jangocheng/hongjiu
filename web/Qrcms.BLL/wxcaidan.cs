using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Qrcms.BLL
{

    public class wxcaidan
    {
        private readonly Qrcms.Model.siteconfig siteConfig = new Qrcms.BLL.siteconfig().loadConfig();
        private readonly DAL.wxcaidan dal;
        public wxcaidan()
        {
            dal = new DAL.wxcaidan(siteConfig.sysdatabaseprefix);
        }


        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int caidan_id)
        {
            return dal.Exists(caidan_id);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.wxcaidan model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int caidan_id)
        {
            return dal.Delete(caidan_id);
        }
        /// <summary>
        /// 删除所有数据
        /// </summary>
        public bool DeleteAll()
        {
            return dal.DeleteAll();
        }

        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        #endregion

        #region 扩展方法================================

        #endregion
    }
}
