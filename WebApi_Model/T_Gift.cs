using System;
namespace WebApi_Model
{
    /// <summary>
    /// 礼物基础表
    /// </summary>
    [Serializable]
    public partial class T_Gift
    {
        public T_Gift()
        { }
        #region Model
        private int _giftid;
        private string _giftname;
        private string _giftico;
        private int? _tuimao;
        private int? _isactive;
        /// <summary>
        /// 
        /// </summary>
        public int GiftID
        {
            set { _giftid = value; }
            get { return _giftid; }
        }
        /// <summary>
        /// 礼物名称
        /// </summary>
        public string GiftName
        {
            set { _giftname = value; }
            get { return _giftname; }
        }
        /// <summary>
        /// 图标
        /// </summary>
        public string GiftICO
        {
            set { _giftico = value; }
            get { return _giftico; }
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
        /// 标识，如取消Active = 0
        /// </summary>
        public int? IsActive
        {
            set { _isactive = value; }
            get { return _isactive; }
        }
        #endregion Model

    }
}

