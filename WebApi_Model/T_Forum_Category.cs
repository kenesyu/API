using System;
namespace WebApi_Model
{
    /// <summary>
    /// 贴分类
    ///   
    /// </summary>
    [Serializable]
    public partial class T_Forum_Category
    {
        public T_Forum_Category()
        { }
        #region Model
        private int _forumcategoryid;
        private int? _level;
        private string _categoryname;
        private string _categoryico;
        private int? _parentid;
        /// <summary>
        /// 
        /// </summary>
        public int ForumCategoryID
        {
            set { _forumcategoryid = value; }
            get { return _forumcategoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Level
        {
            set { _level = value; }
            get { return _level; }
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
            set { _categoryico = value; }
            get { return _categoryico; }
        }
        /// <summary>
        /// 父ID
        /// </summary>
        public int? ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        #endregion Model

    }
}

