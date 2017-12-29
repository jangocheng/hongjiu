using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Qrcms.Common;
using Qrcms.Model;
namespace Qrcms.BLL
{
    //dt_auction_comment
    public partial class auction_comment
    {

        private readonly Qrcms.DAL.auction_comment dal = new Qrcms.DAL.auction_comment();
        public auction_comment()
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
        /// 增加一条数据
        /// </summary>
        public int Add(Qrcms.Model.auction_comment model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Qrcms.Model.auction_comment model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetCommentList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetCommentList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
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
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Qrcms.Model.auction_comment GetModel(int id)
        {

            return dal.GetModel(id);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
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
        public List<Qrcms.Model.auction_comment> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Qrcms.Model.auction_comment> DataTableToList(DataTable dt)
        {
            List<Qrcms.Model.auction_comment> modelList = new List<Qrcms.Model.auction_comment>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Qrcms.Model.auction_comment model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Qrcms.Model.auction_comment();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.auction_no = dt.Rows[n]["auction_no"].ToString();
                    if (dt.Rows[n]["article_id"].ToString() != "")
                    {
                        model.article_id = int.Parse(dt.Rows[n]["article_id"].ToString());
                    }
                    model.user_name = dt.Rows[n]["user_name"].ToString();
                    model.title = dt.Rows[n]["title"].ToString();
                    model.content = dt.Rows[n]["content"].ToString();
                    if (dt.Rows[n]["add_time"].ToString() != "")
                    {
                        model.add_time = DateTime.Parse(dt.Rows[n]["add_time"].ToString());
                    }
                    model.remark = dt.Rows[n]["remark"].ToString();


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