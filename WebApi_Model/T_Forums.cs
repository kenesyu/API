using System;
using System.Collections.Generic;
namespace WebApi_Model
{
	/// <summary>
	/// 用户评贴
	/// </summary>
	[Serializable]
	public partial class T_Forums
	{
		public T_Forums()
		{}
		#region Model
		private int _forumid;
		private int? _uid;
		private string _title;
		private string _fromip;
		private string _fromdevice;
		private int? _categoryid;
		private string _content;
		private DateTime? _posttime;
		private int? _status;
		private string _coverphoto;
		private int? _tuimao;
		private int? _flag;
		private int? _productid;
		private int? _star;
		private int? _views;
		private int? _likes;
		private int? _commentcount;
        private List<T_Forum_Photo> _forum_Photo;
        private List<T_Forum_Comment> _forum_Comment;
        private T_User _user;
        private List<T_Forum_Buy> _forum_Buy;

        public T_User User {
            set { _user = value; }
            get { return _user; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int ForumID
		{
			set{ _forumid=value;}
			get{return _forumid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 发贴IP
		/// </summary>
		public string FromIP
		{
			set{ _fromip=value;}
			get{return _fromip;}
		}
		/// <summary>
		/// 来自设备
		/// </summary>
		public string FromDevice
		{
			set{ _fromdevice=value;}
			get{return _fromdevice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CategoryID
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 发表日期
		/// </summary>
		public DateTime? PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		/// <summary>
		/// 状态 0 待审核 1审核中 2 通过 3 删除
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 封面图片
		/// </summary>
		public string CoverPhoto
		{
			set{ _coverphoto=value;}
			get{return _coverphoto;}
		}
		/// <summary>
		/// 腿毛
		/// </summary>
		public int? TuiMao
		{
			set{ _tuimao=value;}
			get{return _tuimao;}
		}
		/// <summary>
		/// 0 正常 1置顶
		/// </summary>
		public int? Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// 此值不为空来源为商品评论
		/// </summary>
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 1-5评分
		/// </summary>
		public int? Star
		{
			set{ _star=value;}
			get{return _star;}
		}
		/// <summary>
		/// 查看数
		/// </summary>
		public int? Views
		{
			set{ _views=value;}
			get{return _views;}
		}
		/// <summary>
		/// 点赞数
		/// </summary>
		public int? Likes
		{
			set{ _likes=value;}
			get{return _likes;}
		}
		/// <summary>
		/// 评论数
		/// </summary>
		public int? CommentCount
		{
			set{ _commentcount=value;}
			get{return _commentcount;}
		}

        public List<T_Forum_Photo> Forum_Photo
        {
            set { _forum_Photo = value; }
            get { return _forum_Photo; }
        }

        public List<T_Forum_Comment> Forum_Comment {
            set { _forum_Comment = value; }
            get { return _forum_Comment; }
        }

        public List<T_Forum_Buy> Forum_Buy {
            set { _forum_Buy = value; }
            get { return _forum_Buy; }
        }
		#endregion Model

	}
}

