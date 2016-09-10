using System;
namespace WebApi_Model
{
    /// <summary>
    /// 用户表
    ///   
    /// </summary>
    [Serializable]
    public partial class T_User
    {
        public T_User()
        { }
        #region Model
        private int _uid;
        private string _tel;
        private string _nickname;
        private string _password;
        private string _headimg;
        private int? _sex;
        private int? _age;
        private int? _piaozi;
        private int? _tuimao;
        private DateTime? _registerdate;
        private DateTime? _lastlogindate;
        private int? _viplevel;
        private DateTime? _vipoverduedate;
        private int? _isonline;
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
        /// 密码暂不加密
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
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
        /// <summary>
        /// 瞟资
        /// </summary>
        public int? PiaoZi
        {
            set { _piaozi = value; }
            get { return _piaozi; }
        }
        /// <summary>
        /// 腿毛
        /// </summary>
        public int? TuiMao
        {
            set { _tuimao = value; }
            get { return _tuimao; }
        }
        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime? RegisterDate
        {
            set { _registerdate = value; }
            get { return _registerdate; }
        }
        /// <summary>
        /// 最后活跃日期
        /// </summary>
        public DateTime? LastLoginDate
        {
            set { _lastlogindate = value; }
            get { return _lastlogindate; }
        }
        /// <summary>
        /// 会员等级 0：普通会员 1：VIP  2：SuperVIP
        /// </summary>
        public int? VipLevel
        {
            set { _viplevel = value; }
            get { return _viplevel; }
        }
        /// <summary>
        /// 会员过期日是
        /// </summary>
        public DateTime? VipOverDueDate
        {
            set { _vipoverduedate = value; }
            get { return _vipoverduedate; }
        }
        /// <summary>
        /// 是否在线
        /// </summary>
        public int? IsOnLine
        {
            set { _isonline = value; }
            get { return _isonline; }
        }
        #endregion Model

    }
}

