using System;
namespace WebApi_Model
{
    /// <summary>
    /// 商品分类
    /// </summary>
    [Serializable]
    public partial class T_Product_Category
    {
        public T_Product_Category()
        { }
        #region Model
        private int _categoryid;
        private int? _leave;
        private int? _parentid;
        private string _categoryname;
        private string _categoryICO;
        /// <summary>
        /// 
        /// </summary>
        public int CategoryID
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 分类级别
        /// </summary>
        public int? Leave
        {
            set { _leave = value; }
            get { return _leave; }
        }
        /// <summary>
        /// 父ID
        /// </summary>
        public int? ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string CategoryName
        {
            set { _categoryname = value; }
            get { return _categoryname; }
        }

        /// <summary>
        /// 图标
        /// </summary>
        public string CategoryICO
        {
            set { _categoryICO = value; }
            get { return _categoryICO; }
        }
        #endregion Model

    }
}

