using System;
namespace WebApi_Model
{
    /// <summary>
    /// T_PhotoTag:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Photo_Tag
    {
        public T_Photo_Tag()
        { }
        #region Model
        private int _phototagid;
        private string _tagname;
        /// <summary>
        /// 
        /// </summary>
        public int PhotoTagID
        {
            set { _phototagid = value; }
            get { return _phototagid; }
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

