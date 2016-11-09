using System;
namespace WebApi_Model
{
    /// <summary>
    /// 系统消息
    /// </summary>
    [Serializable]
    public partial class T_System_Messages
    {
        public T_System_Messages()
        { }
        #region Model
        private int _messageid;
        private string _messagetitle;
        private string _messagecontent;
        private int? _touid;
        private string _linkurl;
        private int? _isview;
        private DateTime? _postdate;
        private int? _isdelete;
        /// <summary>
        /// 
        /// </summary>
        public int MessageID
        {
            set { _messageid = value; }
            get { return _messageid; }
        }
        /// <summary>
        /// 消息标题
        /// </summary>
        public string MessageTitle
        {
            set { _messagetitle = value; }
            get { return _messagetitle; }
        }
        /// <summary>
        /// 消息正文
        /// </summary>
        public string MessageContent
        {
            set { _messagecontent = value; }
            get { return _messagecontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ToUID
        {
            set { _touid = value; }
            get { return _touid; }
        }
        /// <summary>
        /// URL链接
        /// </summary>
        public string LinkURL
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// 是否查看 0未查看 1已查看
        /// </summary>
        public int? IsView
        {
            set { _isview = value; }
            get { return _isview; }
        }
        /// <summary>
        /// 消息日期
        /// </summary>
        public DateTime? PostDate
        {
            set { _postdate = value; }
            get { return _postdate; }
        }
        /// <summary>
        /// 删除 0否 1是
        /// </summary>
        public int? IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        #endregion Model

    }
}

