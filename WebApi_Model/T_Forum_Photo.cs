using System;
namespace WebApi_Model
{
    /// <summary>
    /// 收费图集
    /// </summary>
    [Serializable]
    public partial class T_Forum_Photo
    {
        public T_Forum_Photo()
        { }
        #region Model
        private int _forumphotoid;
        private int? _forumid;
        private string _photo;
        /// <summary>
        /// 
        /// </summary>
        public int ForumPhotoID
        {
            set { _forumphotoid = value; }
            get { return _forumphotoid; }
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
        /// 图片
        /// </summary>
        public string Photo
        {
            set { _photo = value; }
            get { return _photo; }
        }
        #endregion Model

    }
}

