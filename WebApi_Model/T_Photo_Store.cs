using System;
namespace WebApi_Model
{
    /// <summary>
    /// 图集收藏
    /// </summary>
    [Serializable]
    public partial class T_Photo_Store
    {
        public T_Photo_Store()
        { }
        #region Model
        private int _storeid;
        private int? _uid;
        private int? _photocollectionid;
        private DateTime? _creatdate;
        /// <summary>
        /// 
        /// </summary>
        public int StoreID
        {
            set { _storeid = value; }
            get { return _storeid; }
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
        public int? PhotoCollectionID
        {
            set { _photocollectionid = value; }
            get { return _photocollectionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreatDate
        {
            set { _creatdate = value; }
            get { return _creatdate; }
        }
        #endregion Model

    }
}

