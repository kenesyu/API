using System;
namespace WebApi_Model
{
    /// <summary>
    /// 贴子购买
    /// </summary>
    [Serializable]
    public partial class T_Forum_Buy
    {
        public T_Forum_Buy()
        { }
        #region Model
        private int _buyid;
        private int? _forumid;
        private int? _uid;
        private DateTime? _buydate;
        /// <summary>
        /// 
        /// </summary>
        public int BuyID
        {
            set { _buyid = value; }
            get { return _buyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ForumID
        {
            set { _forumid = value; }
            get { return _forumid; }
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
        public DateTime? BuyDate
        {
            set { _buydate = value; }
            get { return _buydate; }
        }
        #endregion Model

    }
}

