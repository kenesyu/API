using System;
namespace WebApi_Model
{
    /// <summary>
    /// 注册短信
    /// </summary>
    [Serializable]
    public partial class T_User_SMSCode
    {
        public T_User_SMSCode()
        { }
        #region Model
        private int _codeid;
        private string _tel;
        private DateTime? _sendtime;
        private DateTime? _overduetime;
        private string _code;
        private int? _type;
        private string _message;
        private int? _active;



        public int CodeID
        {
            set { _codeid = value; }
            get { return _codeid; }
        }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime? SendTime
        {
            set { _sendtime = value; }
            get { return _sendtime; }
        }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? OverDueTime
        {
            set { _overduetime = value; }
            get { return _overduetime; }
        }
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 类型 1 注册码 2 找回密码
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 短信正文
        /// </summary>
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
        /// <summary>
        /// 0 未使用 1已使用
        /// </summary>
        public int? Active
        {
            set { _active = value; }
            get { return _active; }
        }
        #endregion Model

    }
}

