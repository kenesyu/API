using System;
namespace WebApi_Model
{
    /// <summary>
    /// T_Product_Property:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Product_Property
    {
        public T_Product_Property()
        { }
        #region Model
        private int _propertyid;
        private string _propertyname;
        private string _propertyvalue;
        private string _propertygroup;
        private int _productID;
        /// <summary>
        /// 
        /// </summary>
        public int PropertyID
        {
            set { _propertyid = value; }
            get { return _propertyid; }
        }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName
        {
            set { _propertyname = value; }
            get { return _propertyname; }
        }
        /// <summary>
        /// 属性值
        /// </summary>
        public string PropertyValue
        {
            set { _propertyvalue = value; }
            get { return _propertyvalue; }
        }
        /// <summary>
        /// 属性组
        /// </summary>
        public string PropertyGroup
        {
            set { _propertygroup = value; }
            get { return _propertygroup; }
        }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductID { 
            set { _productID = value; }
            get { return _productID; }
        }
        #endregion Model

    }
}

