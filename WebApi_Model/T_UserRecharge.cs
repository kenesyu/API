using System;
namespace WebApi_Model
{
    /// <summary>
    /// T_UserRecharge:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_UserRecharge
    {
        public T_UserRecharge()
        { }
        #region Model
        private int? _uid;
        private int? _rechargeid;
        private DateTime? _rechargedate;
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
        public int? RechargeID
        {
            set { _rechargeid = value; }
            get { return _rechargeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RechargeDate
        {
            set { _rechargedate = value; }
            get { return _rechargedate; }
        }
        #endregion Model
    }
}

