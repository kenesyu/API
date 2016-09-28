using System;
using System.Collections.Generic;
namespace WebApi_Model
{
	/// <summary>
	/// 订单
	/// </summary>
	[Serializable]
	public partial class T_Product_Orders
	{
		public T_Product_Orders()
		{}
		#region Model
		private int _orderid;
		private string _ordernum;
		private DateTime? _orderdatetime;
		private int? _uid;
		private int? _status;
		private int? _addressid;
		private int? _productqty;
		private decimal? _totalamount;
		private DateTime? _paytime;
		private DateTime? _sendtime;
		private DateTime? _taketime;
		private DateTime? _aftersaletime;
		private string _trancode;
		private string _trantype;
        private List<T_Product_OrderDetails> _orderDetails;
		/// <summary>
		/// 
		/// </summary>
		public int OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 订单编号
		/// </summary>
		public string OrderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		/// <summary>
		/// 订单时间
		/// </summary>
		public DateTime? OrderDateTime
		{
			set{ _orderdatetime=value;}
			get{return _orderdatetime;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int? UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 0 待付款 1待发货 2待收货 3待评价 4已完成 5发起售后
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 收货地址
		/// </summary>
		public int? AddressID
		{
			set{ _addressid=value;}
			get{return _addressid;}
		}
		/// <summary>
		/// 商品数量
		/// </summary>
		public int? ProductQty
		{
			set{ _productqty=value;}
			get{return _productqty;}
		}
		/// <summary>
		/// 总价
		/// </summary>
		public decimal? TotalAmount
		{
			set{ _totalamount=value;}
			get{return _totalamount;}
		}
		/// <summary>
		/// 付款时间
		/// </summary>
		public DateTime? PayTime
		{
			set{ _paytime=value;}
			get{return _paytime;}
		}
		/// <summary>
		/// 发货时间
		/// </summary>
		public DateTime? SendTime
		{
			set{ _sendtime=value;}
			get{return _sendtime;}
		}
		/// <summary>
		/// 收货时间
		/// </summary>
		public DateTime? TakeTime
		{
			set{ _taketime=value;}
			get{return _taketime;}
		}
		/// <summary>
		/// 发起售后时间
		/// </summary>
		public DateTime? AfterSaleTime
		{
			set{ _aftersaletime=value;}
			get{return _aftersaletime;}
		}
		/// <summary>
		/// 运单号
		/// </summary>
		public string TranCode
		{
			set{ _trancode=value;}
			get{return _trancode;}
		}
		/// <summary>
		/// 物流公司
		/// </summary>
		public string TranType
		{
			set{ _trantype=value;}
			get{return _trantype;}
		}

        public List<T_Product_OrderDetails> OrderDetails
        {
            set { _orderDetails = value; }
            get { return _orderDetails; }
        }
		#endregion Model

	}
}

