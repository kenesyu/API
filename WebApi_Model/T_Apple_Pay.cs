using System;
namespace WebApi_Model
{
    /// <summary>
    /// 苹果内购支付
    /// </summary>
    [Serializable]
    public partial class T_Apple_Pay
    {
        public T_Apple_Pay()
        { }
        #region Model
        private int _id;
        private string _paykind;
        private int? _uid;
        private string _certificate;
        private string _certmd5;
        private DateTime? _createtime;
        private decimal? _amount;
        private int? _qty;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayKind
        {
            set { _paykind = value; }
            get { return _paykind; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 支付凭证
        /// </summary>
        public string Certificate
        {
            set { _certificate = value; }
            get { return _certificate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CertMD5
        {
            set { _certmd5 = value; }
            get { return _certmd5; }
        }
        /// <summary>
        /// 验证时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int? Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        #endregion Model

    }
}

