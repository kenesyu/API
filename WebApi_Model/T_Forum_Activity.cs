using System;
namespace WebApi_Model
{
    /// <summary>
    /// 姿势首页轮播
    /// </summary>
    [Serializable]
    public partial class T_Forum_Activity
    {
        public T_Forum_Activity()
        { }
        #region Model
        private int _activityid;
        private int? _activetype;
        private int? _keyid;
        private string _coverphoto;
        /// <summary>
        /// 
        /// </summary>
        public int ActivityID
        {
            set { _activityid = value; }
            get { return _activityid; }
        }
        /// <summary>
        /// 暂不使用此值因为来源都是贴子
        /// </summary>
        public int? ActiveType
        {
            set { _activetype = value; }
            get { return _activetype; }
        }
        /// <summary>
        /// 贴子ID
        /// </summary>
        public int? KeyID
        {
            set { _keyid = value; }
            get { return _keyid; }
        }
        /// <summary>
        /// 封面
        /// </summary>
        public string CoverPhoto
        {
            set { _coverphoto = value; }
            get { return _coverphoto; }
        }
        #endregion Model

    }
}

