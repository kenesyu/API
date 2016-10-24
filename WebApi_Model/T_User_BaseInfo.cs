using System;
namespace WebApi_Model
{
    /// <summary>
    /// 用户表
    ///   
    /// </summary>
    [Serializable]
    public partial class T_User_BaseInfo
    {
        public T_User_BaseInfo()
        { }
        #region Model
        private int _uid;
        private string _tel;
        private string _nickname;
        private string _headimg;
        private int? _sex;
        private int? _age;
        /// <summary>
        /// 7位1000001起始
        /// </summary>
        public int UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 注册使用电话号码
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 昵称可改但必需唯一
        /// </summary>
        public string Nickname
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string HeadImg
        {
            set { _headimg = value; }
            get { return _headimg; }
        }
        /// <summary>
        /// 性别 0女 1男
        /// </summary>
        public int? Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age
        {
            set { _age = value; }
            get { return _age; }
        }
        #endregion Model

    }
}

