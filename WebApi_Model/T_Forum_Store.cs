using System;
namespace WebApi_Model
{
    /// <summary>
    /// 贴子收藏
    /// </summary>
    [Serializable]
    public partial class T_Forum_Store
    {
        public T_Forum_Store()
        { }
        #region Model
        private int _id;
        private int? _uid;
        private int? _forumid;
        private T_Forums _forum;


        public T_Forums Forum {
            set { _forum = value; }
            get { return _forum; }
        }

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

