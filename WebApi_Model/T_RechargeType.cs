using System;
namespace WebApi_Model
{
    /// <summary>
    /// T_RechargeType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_RechargeType
    {
        public T_RechargeType()
        { }
        #region Model
        private int _rechargeid;
        private string _rechargename;
        private int? _adddays;
        private string _ico;
        private int? _addpiaozi;
        private decimal? _rechargeprice;
        /// <summary>
        /// 
        /// </summary>
        public int RechargeID
        {
            set { _rechargeid = value; }
            get { return _rechargeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RechargeName
        {
            set { _rechargename = value; }
            get { return _rechargename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? AddDays
        {
            set { _adddays = value; }
            get { return _adddays; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ICO
        {
            set { _ico = value; }
            get { return _ico; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? AddPiaoZi
        {
            set { _addpiaozi = value; }
            get { return _addpiaozi; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal? RechargePrice
        {
            set { _rechargeprice = value; }
            get { return _rechargeprice; }
        }
        #endregion Model

    }
}

