using System;
using System.Collections.Generic;
using System.Text;
using Qrcms.Common;
using System.Data;
using Qrcms.DBUtility;

namespace Qrcms.DAL
{
    /// <summary>
    /// 数据访问类:站点配置
    /// </summary>
    public partial class siteconfig
    {
        private static object lockHelper = new object();

        /// <summary>
        ///  读取站点配置文件
        /// </summary>
        public Model.siteconfig loadConfig(string configFilePath)
        {
            return (Model.siteconfig)SerializationHelper.Load(typeof(Model.siteconfig), configFilePath);
        }

        /// <summary>
        /// 写入站点配置文件
        /// </summary>
        public Model.siteconfig saveConifg(Model.siteconfig model, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(model, configFilePath);
            }
            return model;
        }
        public string getcodebh(string home, string table, string code)
        {
            string str = home + Qrcms.Common.Utils.Number(6);
            string sql = "select " + code + " from " + table + " where " + code + "='" + str + "'";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                str = getcodebh(home, table, code);
            }
            return str;
        }
    }
}
