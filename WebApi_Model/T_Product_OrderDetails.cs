using System;
namespace WebApi_Model
{
    /// <summary>
    /// 订单详情
    ///   
    /// </summary>
    [Serializable]
    public partial class T_Product_OrderDetails
    {
        public T_Product_OrderDetails()
        { }
        #region Model
        private int _orderdetailsid;
        private int? _orderid;
        private int? _productid;
        private int? _productextid;
        private int? _qty;
        private T_Product _product;
        private T_Product_Ext _product_ext;



        public T_Product Product
        {
            set { _product = value; }
            get { return _product; }
        }

        public T_Product_Ext Product_Ext
        {
            set { _product_ext = value; }
            get { return _product_ext; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int OrderDetailsID
        {
            set { _orderdetailsid = value; }
            get { return _orderdetailsid; }
        }
        /// <summary>
        /// 订单ID
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 产品ID
        /// </summary>
        public int? ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 扩展ID
        /// </summary>
        public int? ProductExtID
        {
            set { _productextid = value; }
            get { return _productextid; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int? Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        #endregion Model

    }
}

