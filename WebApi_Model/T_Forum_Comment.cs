using System;
namespace WebApi_Model
{
    /// <summary>
    /// T_Forum_Comment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Forum_Comment
    {
        public T_Forum_Comment()
        { }
        #region Model
        private int _commentid;
        private int? _uid;
        private DateTime? _commentdate;
        private string _comment;
        private int? _likes;
        private int? _giftcount;
        private int? _forumid;
        private int? _cid;
        private int? _status;
        /// <summary>
        /// 
        /// </summary>
        public int CommentID
        {
            set { _commentid = value; }
            get { return _commentid; }
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
        /// 回复日期
        /// </summary>
        public DateTime? CommentDate
        {
            set { _commentdate = value; }
            get { return _commentdate; }
        }
        /// <summary>
        /// 回复
        /// </summary>
        public string Comment
        {
            set { _comment = value; }
            get { return _comment; }
        }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int? Likes
        {
            set { _likes = value; }
            get { return _likes; }
        }
        /// <summary>
        /// 礼物数
        /// </summary>
        public int? GiftCount
        {
            set { _giftcount = value; }
            get { return _giftcount; }
        }
        /// <summary>
        /// 主题ID
        /// </summary>
        public int? ForumID
        {
            set { _forumid = value; }
            get { return _forumid; }
        }
        /// <summary>
        /// 评论的评论ID
        /// </summary>
        public int? CID
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 0 正常 1删除
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model

    }
}

