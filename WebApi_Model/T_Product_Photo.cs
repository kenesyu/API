using System;
using System.Collections.Generic;
namespace WebApi_Model
{
    /// <summary>
    /// T_ProductPhoto:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Product_Photo
    {
        public T_Product_Photo()
        { }
        #region Model
        private int _productphotoid;
        private int? _productid;
        private string _imgpath;
        private string _imgremark;
        private int? _imgtype;
        private int? _sorting;
            /// <summary>
        /// 自增ID
        /// </summary>
        public int ProductPhotoID
        {
            set { _productphotoid = value; }
            get { return _productphotoid; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int? ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgPath
        {
            set { _imgpath = value; }
            get { return _imgpath; }
        }
        /// <summary>
        /// 图片说明
        /// </summary>
        public string ImgRemark
        {
            set { _imgremark = value; }
            get { return _imgremark; }
        }
        /// <summary>
        /// 图片类型 0商品图片1 图文详情
        /// </summary>
        public int? ImgType
        {
            set { _imgtype = value; }
            get { return _imgtype; }
        }
        /// <summary>
        /// 图片排序
        /// </summary>
        public int? Sorting
        {
            set { _sorting = value; }
            get { return _sorting; }
        }

        #endregion Model



    }
}

