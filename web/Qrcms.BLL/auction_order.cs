using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Qrcms.Common;
using Qrcms.Model;
namespace Qrcms.BLL
{
    //dt_auction_order
    public partial class auction_order
    {

        private readonly Qrcms.DAL.auction_order dal = new Qrcms.DAL.auction_order();
        public auction_order()
        { }

        #region  Method
        /// <summary>
        /// 修改平均价
        /// </summary>
        /// <param name="filed"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool UpdateAvg(string filed, string where)
        {
            return dal.UpdateAvg(filed, where);
        }
        /// <summary>
        /// 修改收货地址
        /// </summary>
        /// <param name="filed"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool UpdateFiled(string filed, string where)
        {
            return dal.UpdateFiled(filed, where);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string no)
        {
            return dal.Exists(no);
        }

        public bool Exists1(string no)
        {
            return dal.Exists1(no);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Qrcms.Model.auction_order model)
        {
            return dal.Add(model);

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Qrcms.Model.auction_order model)
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
        public Qrcms.Model.auction_order GetModel(string no)
        {

            return dal.GetModel(no);
        }

        /// <summary>
        /// 通过竞拍编号得到一个对象实体
        /// </summary>
        public Qrcms.Model.auction_order GetModelbya_no(string a_no)
        {

            return dal.GetModelbya_no(a_no);
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Qrcms.Model.auction_order> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Qrcms.Model.auction_order> DataTableToList(DataTable dt)
        {
            List<Qrcms.Model.auction_order> modelList = new List<Qrcms.Model.auction_order>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Qrcms.Model.auction_order model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Qrcms.Model.auction_order();
                    model.no = dt.Rows[n]["no"].ToString();
                    model.user_name = dt.Rows[n]["user_name"].ToString();
                    model.a_no = dt.Rows[n]["a_no"].ToString();
                    if (dt.Rows[n]["article_id"].ToString() != "")
                    {
                        model.article_id = int.Parse(dt.Rows[n]["article_id"].ToString());
                    }
                    model.article_title = dt.Rows[n]["article_title"].ToString();
                    model.accept_name = dt.Rows[n]["accept_name"].ToString();
                    model.accept_mobile = dt.Rows[n]["accept_mobile"].ToString();
                    model.accept_address = dt.Rows[n]["accept_address"].ToString();
                    if (dt.Rows[n]["status"].ToString() != "")
                    {
                        model.status = int.Parse(dt.Rows[n]["status"].ToString());
                    }
                    if (dt.Rows[n]["quantity"].ToString() != "")
                    {
                        model.quantity = int.Parse(dt.Rows[n]["quantity"].ToString());
                    }
                    if (dt.Rows[n]["price"].ToString() != "")
                    {
                        model.price = decimal.Parse(dt.Rows[n]["price"].ToString());
                    }
                    if (dt.Rows[n]["createdate"].ToString() != "")
                    {
                        model.createdate = DateTime.Parse(dt.Rows[n]["createdate"].ToString());
                    }
                    if (dt.Rows[n]["express_time"].ToString() != "")
                    {
                        model.express_time = DateTime.Parse(dt.Rows[n]["express_time"].ToString());
                    }
                    if (dt.Rows[n]["express_id"].ToString() != "")
                    {
                        model.express_id = int.Parse(dt.Rows[n]["express_id"].ToString());
                    }
                    if (dt.Rows[n]["express_fee"].ToString() != "")
                    {
                        model.express_fee = decimal.Parse(dt.Rows[n]["express_fee"].ToString());
                    }
                    if (dt.Rows[n]["win_status"].ToString() != "")
                    {
                        model.win_status = int.Parse(dt.Rows[n]["win_status"].ToString());
                    }
                    model.article_img = dt.Rows[n]["article_img"].ToString();
                    model.a_title = dt.Rows[n]["a_title"].ToString();


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