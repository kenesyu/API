using System;
namespace WebApi_Model
{
    /// <summary>
    /// 商品扩展
    /// </summary>
    [Serializable]
    public partial class T_Product_Ext
    {
        public T_Product_Ext()
        { }
        #region Model
        private int _productextid;
        private int? _productid;
        private decimal? _price;
        private int? _propertya;
        private int? _propertyb;
        private int? _propertyc;
        private int? _stock;
        /// <summary>
        /// 
        /// </summary>
        public int ProductExtID
        {
            set { _productextid = value; }
            get { return _productextid; }
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
        /// 价格
        /// </summary>
        public decimal? Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 属性A
        /// </summary>
        public int? PropertyA
        {
            set { _propertya = value; }
            get { return _propertya; }
        }
        /// <summary>
        /// 属性B
        /// </summary>
        public int? PropertyB
        {
            set { _propertyb = value; }
            get { return _propertyb; }
        }
        /// <summary>
        /// 属性C
        /// </summary>
        public int? PropertyC
        {
            set { _propertyc = value; }
            get { return _propertyc; }
        }
        /// <summary>
        /// 库存
        /// </summary>
        public int? Stock
        {
            set { _stock = value; }
            get { return _stock; }
        }
        #endregion Model

    }
}

