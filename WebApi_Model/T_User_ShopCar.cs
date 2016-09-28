using System;
using System.Collections.Generic;
namespace WebApi_Model
{
    /// <summary>
    /// 购物车
    /// </summary>
    [Serializable]
    public partial class T_User_ShopCar
    {
        public T_User_ShopCar()
        { }
        #region Model
        private int _shopcarid;
        private int? _uid;
        private int? _productid;
        private int? _productextid;
        private int? _qty;
        private T_Product _product;
        private T_Product_Ext _product_ext;
        private List<T_Product_Property> _product_property;

        /// <summary>
        /// 
        /// </summary>
        public int ShopCarID
        {
            set { _shopcarid = value; }
            get { return _shopcarid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProductExtID
        {
            set { _productextid = value; }
            get { return _productextid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }

        /// <summary>
        /// 
        /// </summary>
        public T_Product Product
        {
            set { _product = value; }
            get { return _product; }
        }

        /// <summary>
        /// 
        /// </summary>
        public T_Product_Ext Product_Ext
        {
            set { _product_ext = value; }
            get { return _product_ext; }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<T_Product_Property> Product_Property
        {
            set { _product_property = value; }
            get { return _product_property; }
        }

        #endregion Model

    }
}

