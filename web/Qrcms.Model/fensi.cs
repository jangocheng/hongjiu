using System;
namespace Qrcms.Model
{
	/// <summary>
	/// fensi:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class fensi
	{
		public fensi()
		{}
		#region Model
		private string _openid;
		private string _headimg;
		private string _nickname;
		private string _parentid;
		/// <summary>
		/// 
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string headimg
		{
			set{ _headimg=value;}
			get{return _headimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nickname
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string parentid
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		#endregion Model

	}
}

