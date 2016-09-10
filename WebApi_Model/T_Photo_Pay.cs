using System;
namespace WebApi_Model
{
    /// <summary>
    /// T_Photo_Pay:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Photo_Pay
    {
        public T_Photo_Pay()
        { }
        #region Model
        private int _payid;
        private int? _photocollectionid;
        private int? _uid;
        private DateTime? _buydate;
        private int? _payway;
        private int? _payvalue;
        /// <summary>
        /// 
        /// </summary>
        public int PayID
        {
            set { _payid = value; }
            get { return _payid; }
        }
        /// <summary>
        /// 图集ID
        /// </summary>
        public int? PhotoCollectionID
        {
            set { _photocollectionid = value; }
            get { return _photocollectionid; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 购买日期
        /// </summary>
        public DateTime? BuyDate
        {
            set { _buydate = value; }
            get { return _buydate; }
        }
        /// <summary>
        /// 支付方式 1 瞟姿 2 腿毛
        /// </summary>
        public int? PayWay
        {
            set { _payway = value; }
            get { return _payway; }
        }
        /// <summary>
        /// 付费金额
        /// </summary>
        public int? PayValue
        {
            set { _payvalue = value; }
            get { return _payvalue; }
        }
        #endregion Model

    }
}

