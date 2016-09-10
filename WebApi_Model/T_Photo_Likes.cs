using System;
namespace WebApi_Model
{
    /// <summary>
    /// 用户点赞表
    /// </summary>
    [Serializable]
    public partial class T_Photo_Likes
    {
        public T_Photo_Likes()
        { }
        #region Model
        private int? _uid;
        private int? _photocollectionid;
        private DateTime? _createtime;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 图集ID
        /// </summary>
        public int? PhotoCollectionID
        {
            set { _photocollectionid = value; }
            get { return _photocollectionid; }
        }
        /// <summary>
        /// 点赞时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

    }
}

