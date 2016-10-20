using System;
namespace WebApi_Model
{
    /// <summary>
    /// 用户心愿计划
    /// </summary>
    [Serializable]
    public partial class T_Wish
    {
        public T_Wish()
        { }
        #region Model
        private int _wishid;
        private int? _uid;
        private string _title;
        private string _linkurl;
        private string _wishname;
        private DateTime? _postdate;
        private string _remark;
        private decimal? _price;
        private int? _status;
        private int? _tuimao;
        private DateTime? _completedate;
        private string _nickname;
        private string _headImg;


        public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }

        public string HeadImg {
            set { _headImg = value; }
            get { return _nickname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int WishID
        {
            set { _wishid = value; }
            get { return _wishid; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 物品连接
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// 物品名称
        /// </summary>
        public string WishName
        {
            set { _wishname = value; }
            get { return _wishname; }
        }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? PostDate
        {
            set { _postdate = value; }
            get { return _postdate; }
        }
        /// <summary>
        /// 备注颜色尺寸 属性
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal? Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 0 审核 1进行中 2 兑换完成 扣除相应腿毛
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
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
        /// 完成日期
        /// </summary>
        public DateTime? CompleteDate
        {
            set { _completedate = value; }
            get { return _completedate; }
        }
        #endregion Model

    }
}

