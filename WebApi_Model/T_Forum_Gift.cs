using System;
namespace WebApi_Model
{
    /// <summary>
    /// 贴子礼物
    /// </summary>
    [Serializable]
    public partial class T_Forum_Gift
    {
        public T_Forum_Gift()
        { }
        #region Model
        private int? _forumid;
        private int? _giftid;
        private int? _qty;
        private int? _postuid;
        private int? _receiptuid;
        private DateTime? _posttime;
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
        public int? GiftID
        {
            set { _giftid = value; }
            get { return _giftid; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int? Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 送礼
        /// </summary>
        public int? PostUID
        {
            set { _postuid = value; }
            get { return _postuid; }
        }
        /// <summary>
        /// 收礼
        /// </summary>
        public int? ReceiptUID
        {
            set { _receiptuid = value; }
            get { return _receiptuid; }
        }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime? PostTime
        {
            set { _posttime = value; }
            get { return _posttime; }
        }
        #endregion Model

    }
}

