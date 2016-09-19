using System;
using System.Collections.Generic;
namespace WebApi_Model
{
	/// <summary>
	/// 商品
	/// </summary>
	[Serializable]
	public partial class T_Product
	{
		public T_Product()
		{}
		#region Model
		private int _productid;
		private string _productname;
		private string _descriptions;
		private string _tagid;
		private string _refproductid;
		private string _refphotoid;
		private int? _category1;
		private int? _category2;
		private decimal? _lowprice;
		private int? _onsale;
		private int? _ishot;
		private int? _isnew;
		private string _coverphoto;
		private DateTime? _createdate;
		private int? _salesvolume;
        private string _categoryName1;
        private string _categoryName2;

        private List<T_Product_Tag> _product_tag;
        private List<T_Product_Ext> _product_ext;
        private List<T_Product_Photo> _product_photo;
        private List<T_Product_Photo> _product_photo_details;

		/// <summary>
		/// 
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 商品名
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 商品描述
		/// </summary>
		public string Descriptions
		{
			set{ _descriptions=value;}
			get{return _descriptions;}
		}
		/// <summary>
		/// 标签List，号分割
		/// </summary>
		public string TagID
		{
			set{ _tagid=value;}
			get{return _tagid;}
		}
		/// <summary>
		/// 相关商品IDList ，号分隔
		/// </summary>
		public string RefProductID
		{
			set{ _refproductid=value;}
			get{return _refproductid;}
		}
		/// <summary>
		/// 相关图集ID，号分隔
		/// </summary>
		public string RefPhotoID
		{
			set{ _refphotoid=value;}
			get{return _refphotoid;}
		}
		/// <summary>
		/// 一级分类
		/// </summary>
		public int? Category1
		{
			set{ _category1=value;}
			get{return _category1;}
		}
		/// <summary>
		/// 二级分类
		/// </summary>
		public int? Category2
		{
			set{ _category2=value;}
			get{return _category2;}
		}
		/// <summary>
		/// 最底价格
		/// </summary>
		public decimal? LowPrice
		{
			set{ _lowprice=value;}
			get{return _lowprice;}
		}
		/// <summary>
		/// 0 不售 1在售
		/// </summary>
		public int? OnSale
		{
			set{ _onsale=value;}
			get{return _onsale;}
		}
		/// <summary>
		/// 0 正常 1热销商品 
		/// </summary>
		public int? IsHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// 0 否 1新品
		/// </summary>
		public int? IsNew
		{
			set{ _isnew=value;}
			get{return _isnew;}
		}
		/// <summary>
		/// 封面照片
		/// </summary>
		public string CoverPhoto
		{
			set{ _coverphoto=value;}
			get{return _coverphoto;}
		}
		/// <summary>
		/// 发布日期
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 销量
		/// </summary>
		public int? SalesVolume
		{
			set{ _salesvolume=value;}
			get{return _salesvolume;}
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


		#endregion Model

	}
}



