using System;
namespace WebApi_Model
{
    /// <summary>
    /// T_Forum_Likes:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Forum_Likes
    {
        public T_Forum_Likes()
        { }
        #region Model
        private int _id;
        private int? _uid;
        private int? _forumid;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        public int? ForumID
        {
            set { _forumid = value; }
            get { return _forumid; }
        }
        #endregion Model

    }
}

