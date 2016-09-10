using System;
namespace WebApi_Model
{
    /// <summary>
    /// T_Product_Tag:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Product_Tag
    {
        public T_Product_Tag()
        { }
        #region Model
        private int _tagid;
        private string _tagname;
        /// <summary>
        /// 
        /// </summary>
        public int TagID
        {
            set { _tagid = value; }
            get { return _tagid; }
        }
        /// <summary>
        /// 标签名
        /// </summary>
        public string TagName
        {
            set { _tagname = value; }
            get { return _tagname; }
        }
        #endregion Model

    }
}

