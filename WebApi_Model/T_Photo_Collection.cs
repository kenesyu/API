using System;
using System.Collections.Generic;
namespace WebApi_Model
{
    /// <summary>
    /// 图集相关
    /// </summary>
    [Serializable]
    public partial class T_Photo_Collection
    {
        public T_Photo_Collection()
        { }
        #region Model
        private int _photocollectionid;
        private string _coverphoto;
        private int? _likes;
        private int? _views;
        private DateTime? _createdate;
        private string _phototagid;
        private int? _totalimg;
        private int? _isactive;
        private string _refproductid;
        private int? _phototype;
        private int? _isfree;
        private int? _piaozi;
        private int? _tuimao;
        private string _description;
        private int _category1;
        private int _category2;
        private string _categoryName1;
        private string _categoryName2;

        private List<T_Photo_Details> _photoDetails;
        private List<T_Photo_Tag> _photoTag;
        /// <summary>
        /// 
        /// </summary>
        public int PhotoCollectionID
        {
            set { _photocollectionid = value; }
            get { return _photocollectionid; }
        }
        /// <summary>
        /// 封面图
        /// </summary>
        public string CoverPhoto
        {
            set { _coverphoto = value; }
            get { return _coverphoto; }
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
        /// 查看数
        /// </summary>
        public int? Views
        {
            set { _views = value; }
            get { return _views; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 标签ID
        /// </summary>
        public string PhotoTagID
        {
            set { _phototagid = value; }
            get { return _phototagid; }
        }
        /// <summary>
        /// 相片数
        /// </summary>
        public int? TotalImg
        {
            set { _totalimg = value; }
            get { return _totalimg; }
        }
        /// <summary>
        /// 是否显示 逻辑删除使用
        /// </summary>
        public int? IsActive
        {
            set { _isactive = value; }
            get { return _isactive; }
        }
        /// <summary>
        /// 关联商品ID，分割
        /// </summary>
        public string RefProductID
        {
            set { _refproductid = value; }
            get { return _refproductid; }
        }
        /// <summary>
        /// 图集类型 0 文瞟馆 1 试衣间 2 二次元
        /// </summary>
        public int? PhotoType
        {
            set { _phototype = value; }
            get { return _phototype; }
        }
        /// <summary>
        /// 图集类型 0 免费 1 收费
        /// </summary>
        public int? IsFree
        {
            set { _isfree = value; }
            get { return _isfree; }
        }
        /// <summary>
        /// 所需瞟资
        /// </summary>
        public int? PiaoZi
        {
            set { _piaozi = value; }
            get { return _piaozi; }
        }
        /// <summary>
        /// 所需腿毛
        /// </summary>
        public int? TuiMao
        {
            set { _tuimao = value; }
            get { return _tuimao; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }


        /// <summary>
        /// 一级分类
        /// </summary>
        public int Category1
        {
            set { _category1 = value; }
            get { return _category1; }
        }

        /// <summary>
        /// 二级分类
        /// </summary>
        public int Category2
        {
            set { _category2 = value; }
            get { return _category2; }
        }


        /// <summary>
        /// 一级分类名
        /// </summary>
        public string CategoryName1
        {
            set { _categoryName1 = value; }
            get { return _categoryName1; }
        }


        /// <summary>
        /// 二级分类名
        /// </summary>
        public string CategoryName2
        {
            set { _categoryName2 = value; }
            get { return _categoryName2; }
        }

        /// <summary>
        /// 图集列表
        /// </summary>
        public List<T_Photo_Details> PhotoDetails {
            set { _photoDetails = value; }
            get { return _photoDetails; }
        }

        /// <summary>
        /// 标签
        /// </summary>
        public List<T_Photo_Tag> PhotoTag {
            set { _photoTag = value; }
            get { return _photoTag; }
        }

        #endregion Model

    }
}

