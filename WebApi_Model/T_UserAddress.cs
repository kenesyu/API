using System;
namespace WebApi_Model
{
    /// <summary>
    /// T_UserAddress:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_UserAddress
    {
        public T_UserAddress()
        { }
        #region Model
        private int _addressid;
        private string _province;
        private string _city;
        private string _area;
        private string _receivename;
        private string _postcode;
        private string _tel;
        private string _description;
        private int? _isdefault;
        private int? _uid;
        /// <summary>
        /// 
        /// </summary>
        public int AddressID
        {
            set { _addressid = value; }
            get { return _addressid; }
        }
        /// <summary>
        /// 省
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 市
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 区
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 收件人
        /// </summary>
        public string ReceiveName
        {
            set { _receivename = value; }
            get { return _receivename; }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 是否默认收货地址
        /// </summary>
        public int? IsDefault
        {
            set { _isdefault = value; }
            get { return _isdefault; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        #endregion Model

    }
}

