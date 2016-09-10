using System;
namespace WebApi_Model
{
    /// <summary>
    /// T_Photo_Details:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Photo_Details
    {
        public T_Photo_Details()
        { }
        #region Model
        private int _id;
        private int? _photocollectionid;
        private string _scalephoto;
        private string _originalphoto;
        private int? _isactive;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        /// 缩略图
        /// </summary>
        public string ScalePhoto
        {
            set { _scalephoto = value; }
            get { return _scalephoto; }
        }
        /// <summary>
        /// 原图
        /// </summary>
        public string OriginalPhoto
        {
            set { _originalphoto = value; }
            get { return _originalphoto; }
        }
        /// <summary>
        /// 逻辑删除值
        /// </summary>
        public int? IsActive
        {
            set { _isactive = value; }
            get { return _isactive; }
        }
        #endregion Model

    }
}

