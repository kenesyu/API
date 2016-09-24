using System;
using System.Collections.Generic;
namespace WebApi_Model
{
    /// <summary>
    /// 用户连续签到
    ///   
    /// </summary>
    [Serializable]
    public partial class T_UserSign
    {
        public T_UserSign()
        { }
        #region Model
        private int _signid;
        private int? _uid;
        private DateTime? _signdate;
        private int? _type;
        private DateTime? _resigndate;
        /// <summary>
        /// 
        /// </summary>
        public int SignID
        {
            set { _signid = value; }
            get { return _signid; }
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
        public DateTime? SignDate
        {
            set { _signdate = value; }
            get { return _signdate; }
        }
        /// <summary>
        /// 0 正常签到 1补签
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 补签日期
        /// </summary>
        public DateTime? ReSignDate
        {
            set { _resigndate = value; }
            get { return _resigndate; }
        }
        #endregion Model
    }

    [Serializable]
    public partial class UserSignResult
    {
        private int? _days;
        private List<T_UserSign> _signList;
        private string _yYYYMM;
        private int? _uid;

        /// <summary>
        /// 连续签到日
        /// </summary>
        public int? Days
        {
            set { _days = value; }
            get { return _days; }
        }


        public List<T_UserSign> SignList {
            set { _signList = value; }
            get { return _signList; }
        }

        public string YYYYMM {
            set { _yYYYMM = value; }
            get { return _yYYYMM; }
        }

        public int? UID
        {
            set { _uid = value; }
            get { return _uid; }
        }


    }
}

