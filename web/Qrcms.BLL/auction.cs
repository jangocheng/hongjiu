using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Qrcms.Common;
using Qrcms.Model;
namespace Qrcms.BLL
{
    //dt_auction
    public partial class auction
    {

        private readonly Qrcms.DAL.auction dal = new Qrcms.DAL.auction();
        public auction()
        { }


        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetListNew(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetListNew(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddNew(Qrcms.Model.auction model)
        {
            return dal.AddNew(model,new siteconfig().loadConfig());

        }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string no)
        {
            return dal.Exists(no);
        }

        /// <summary>
        /// 获取期数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetCount(int id, string auction_no)
        {
            return dal.GetCount(id, auction_no);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList1(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList1(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Qrcms.Model.auction model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Qrcms.Model.auction model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string no)
        {

            return dal.Delete(no);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Qrcms.Model.auction GetModel(string no)
        {

            return dal.GetModel(no);
        }

        /// <summary>
        /// 获取文本编辑器信息
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public object GetDetails(string no)
        {
            return dal.GetDetails(no);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string top, string strWhere, string filedOrder)
        {
            return dal.GetList(top, strWhere, filedOrder);
        }
        public DataSet GetList(string strWhere, string filedOrder)
        {
            return dal.GetList(strWhere, filedOrder);
        }
        /// <summary>
		/// 获得前几行数据
		/// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAuctionListByNo(string strWhere)
        {
            return dal.GetAuctionListByNo(strWhere);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetAuctionList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetAuctionList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetReviewList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetReviewList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Qrcms.Model.auction> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList("", strWhere, "");
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Qrcms.Model.auction> DataTableToList(DataTable dt)
        {
            List<Qrcms.Model.auction> modelList = new List<Qrcms.Model.auction>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Qrcms.Model.auction model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Qrcms.Model.auction();
                    model.no = dt.Rows[n]["no"].ToString();
                    model.title = dt.Rows[n]["title"].ToString();
                    if (dt.Rows[n]["article_id"].ToString() != "")
                    {
                        model.article_id = int.Parse(dt.Rows[n]["article_id"].ToString());
                    }
                    if (dt.Rows[n]["layer"].ToString() != "")
                    {
                        model.layer = int.Parse(dt.Rows[n]["layer"].ToString());
                    }
                    model.describe = dt.Rows[n]["describe"].ToString();
                    model.banner = dt.Rows[n]["banner"].ToString();
                    model.article_img = dt.Rows[n]["article_img"].ToString();
                    if (dt.Rows[n]["low_price"].ToString() != "")
                    {
                        model.low_price = decimal.Parse(dt.Rows[n]["low_price"].ToString());
                    }
                    if (dt.Rows[n]["high_price"].ToString() != "")
                    {
                        model.high_price = decimal.Parse(dt.Rows[n]["high_price"].ToString());
                    }
                    if (dt.Rows[n]["sale_price"].ToString() != "")
                    {
                        model.sale_price = decimal.Parse(dt.Rows[n]["sale_price"].ToString());
                    }
                    if (dt.Rows[n]["avg_price"].ToString() != "")
                    {
                        model.avg_price = decimal.Parse(dt.Rows[n]["avg_price"].ToString());
                    }
                    model.remark = dt.Rows[n]["remark"].ToString();
                    model.create_user = dt.Rows[n]["create_user"].ToString();
                    if (dt.Rows[n]["create_time"].ToString() != "")
                    {
                        model.create_time = DateTime.Parse(dt.Rows[n]["create_time"].ToString());
                    }
                    model.article_title = dt.Rows[n]["article_title"].ToString();
                    if (dt.Rows[n]["avg_status"].ToString() != "")
                    {
                        model.avg_status = int.Parse(dt.Rows[n]["avg_status"].ToString());
                    }
                    if (dt.Rows[n]["end_date"].ToString() != "")
                    {
                        model.end_date = DateTime.Parse(dt.Rows[n]["end_date"].ToString());
                    }
                    if (dt.Rows[n]["publish_date"].ToString() != "")
                    {
                        model.publish_date = DateTime.Parse(dt.Rows[n]["publish_date"].ToString());
                    }
                    if (dt.Rows[n]["recommend"].ToString() != "")
                    {
                        model.recommend = int.Parse(dt.Rows[n]["recommend"].ToString());
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
            return GetList("", "", "");
        }
        public string GetFilter(string where, string filter)
        {
            return dal.GetFilter(where, filter);
        }
        public DateTime GetMaxDate()
        {
            return dal.GetMaxDate();
        }
        public bool ExitTitle(string title)
        {
            return dal.ExitTitle(title);
        }
        #endregion

    }
}