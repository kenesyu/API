using System;
namespace WebApi_Model
{
    /// <summary>
    /// 商品首页轮播
    /// </summary>
    [Serializable]
    public partial class T_Product_Activity
    {
        public T_Product_Activity()
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
        /// 类型    0 产品 1 图集 2 贴子
        /// </summary>
        public int? ActiveType
        {
            set { _activetype = value; }
            get { return _activetype; }
        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int? KeyID
        {
            set { _keyid = value; }
            get { return _keyid; }
        }
        /// <summary>
        /// 封面图
        /// </summary>
        public string CoverPhoto
        {
            set { _coverphoto = value; }
            get { return _coverphoto; }
        }
        #endregion Model

    }
}

