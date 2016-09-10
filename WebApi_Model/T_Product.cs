using System;
using System.Collections.Generic;
namespace WebApi_Model
{
    /// <summary>
    /// T_Product:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Product
    {
        public T_Product()
        { }

        #region Model
        private int _productid;
        private string _productname;
        private string _descriptions;
        private string _tagid;
        private string _refproductid;
        private int _category1;
        private int _category2;
        private string _categoryName1;
        private string _categoryName2;
        private List<T_Product_Tag> _product_tag;
        private List<T_Product_Ext> _product_ext;
        private List<T_Product_Photo> _product_photo;
        private List<T_Product_Photo> _product_photo_details;

        private decimal? _lowPrice;
        private int? _onSale;
        private int? _isHot;
        private int? _isNew;

        private string _coverPhoto;
        private DateTime _createDate;
        private int? _salesVolume;

        /// <summary>
        /// 
        /// </summary>
        public int ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 商品名
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string Descriptions
        {
            set { _descriptions = value; }
            get { return _descriptions; }
        }
        /// <summary>
        /// 标签List，号分割
        /// </summary>
        public string TagID
        {
            set { _tagid = value; }
            get { return _tagid; }
        }
        /// <summary>
        /// 相关商品IDList ，号分割
        /// </summary>
        public string RefProductID
        {
            set { _refproductid = value; }
            get { return _refproductid; }
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
        /// 标签
        /// </summary>
        public List<T_Product_Tag> Product_Tag
        {
            set { _product_tag = value; }
            get { return _product_tag; }
        }


        /// <summary>
        /// 扩展集
        /// </summary>
        public List<T_Product_Ext> Product_Ext
        {
            set { _product_ext = value; }
            get { return _product_ext; }
        }

        /// <summary>
        /// 图片
        /// </summary>
        public List<T_Product_Photo> Product_Photo
        {
            set { _product_photo = value; }
            get { return _product_photo; }
        }

        /// <summary>
        /// 图文详情
        /// </summary>
        public List<T_Product_Photo> Product_Photo_Details
        {
            set { _product_photo_details = value; }
            get { return _product_photo_details; }
        }
        


        /// <summary>
        /// 最底价格
        /// </summary>
        public Decimal? LowPrice
        {
            set { _lowPrice = value; }
            get { return _lowPrice; }
        }


        /// <summary>
        /// 是否在售
        /// </summary>
        public int? OnSale
        {
            set { _onSale = value; }
            get { return _onSale; }
        }

        /// <summary>
        /// 热销商品标识
        /// </summary>
        public int? IsHot
        {
            set { _isHot = value; }
            get { return _isHot; }
        }

        /// <summary>
        /// 新品
        /// </summary>
        public int? IsNew {
            set { _isNew = value; }
            get { return _isNew; }
        }

        /// <summary>
        /// 封面图
        /// </summary>
        public string CoverPhoto {
            set { _coverPhoto = value; }
            get { return _coverPhoto; }
        }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate
        {
            set { _createDate = value; }
            get { return _createDate; }
        }

        /// <summary>
        /// 产品销量
        /// </summary>
        public int? SalesVolume
        {
            set { _salesVolume = value; }
            get { return _salesVolume; }
        }


        #endregion Model

    }
}

