using System;
namespace WebApi_Model
{
    /// <summary>
    /// 首页背景图片
    /// </summary>
    [Serializable]
    public partial class T_IndexBackGround
    {
        public T_IndexBackGround()
        { }
        #region Model
        private int _id;
        private string _photourl;
        private string _descriptions;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string PhotoUrl
        {
            set { _photourl = value; }
            get { return _photourl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Descriptions
        {
            set { _descriptions = value; }
            get { return _descriptions; }
        }
        #endregion Model

    }
}

