using System;
namespace WebApi_Model
{
    /// <summary>
    /// T_UserSign:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_UserSign
    {
        public T_UserSign()
        { }
        #region Model
        private int? _uid;
        private DateTime? _signdate;
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
        public DateTime? SignDate
        {
            set { _signdate = value; }
            get { return _signdate; }
        }
        #endregion Model

    }
}

