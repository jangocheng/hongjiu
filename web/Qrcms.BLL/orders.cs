using System;
using System.Data;
using System.Collections.Generic;
using Qrcms.Common;

namespace Qrcms.BLL
{
    /// <summary>
    /// ������
    /// </summary>
    public partial class orders
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private DAL.orders dal;
        public orders()
        {
            dal = new DAL.orders(siteConfig.sysdatabaseprefix);
        }

        #region ��������================================
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }
        public string GetArticleTitle(int order_id)
        {
            return dal.GetArticleTitle(order_id);
        }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string order_no)
        {
            return dal.Exists(order_no);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.orders model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.orders model)
        {
            //���㶩���ܽ��:��Ʒ�ܽ��+���ͷ���+֧��������
            model.order_amount = model.real_amount + model.express_fee + model.payment_fee + model.invoice_taxes;
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.orders GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// ���ݶ����ŷ���һ��ʵ��
        /// </summary>
        public Model.orders GetModel(string order_no)
        {
            return dal.GetModel(order_no);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��ѯ��Ҫ������
        /// </summary>
        public DataSet GetList(string select, string strWhere, string filedOrder)
        {
            return dal.GetList(select, strWhere, filedOrder);
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList2(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList2(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// �������
        /// </summary>
        public DataSet GetList2(string strWhere)
        {
            return dal.GetList2(strWhere);
        }
        /// <summary>
        /// ��ò�ѯ��ҳ����dc
        /// </summary>
        public DataSet GetListdc(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetListdc(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// �������dc
        /// </summary>
        public DataSet GetListdc(string strWhere)
        {
            return dal.GetListdc(strWhere);
        }
        /// <summary>
        /// ��ò�ѯ��ҳ����dc
        /// </summary>
        public DataSet GetListdc22(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetListdc22(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// ��ò�ѯ��ҳ����dc
        /// </summary>
        public DataSet GetListdc22(string strWhere)
        {
            return dal.GetListdc22(strWhere);
        }
        /// <summary>
        /// ����dt_order_goods
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList1(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList1(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        public int GetAritcleID(int order_id)
        {
            return dal.GetAritcleID(order_id);
        }
        #endregion

        #region ��չ����================================
        /// <summary>
        /// ����������
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public bool UpdateField(string order_no, string strValue)
        {
            return dal.UpdateField(order_no, strValue);
        }
        #endregion
    }
}