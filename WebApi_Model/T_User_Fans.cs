using System;
namespace WebApi_Model
{
    /// <summary>
    /// 用户关注
    /// </summary>
    [Serializable]
    public partial class T_User_Fans
    {
        public T_User_Fans()
        { }
        #region Model
        private int _id;
        private int? _myuid;
        private int? _focusuid;
        private T_User_BaseInfo _user;

        public T_User_BaseInfo User {
            set { _user = value; }
            get { return _user; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 我的UID
        /// </summary>
        public int? MyUID
        {
            set { _myuid = value; }
            get { return _myuid; }
        }
        /// <summary>
        /// 关注的人
        /// </summary>
        public int? FocusUID
        {
            set { _focusuid = value; }
            get { return _focusuid; }
        }
        #endregion Model

    }
}

