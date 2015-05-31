﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataSource
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ExtensionFramework")]
	public partial class GHYUsersDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertToken(Token instance);
    partial void UpdateToken(Token instance);
    partial void DeleteToken(Token instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    #endregion
		
		public GHYUsersDataContext() : 
				base(global::DataSource.Properties.Settings.Default.ExtensionFrameworkConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public GHYUsersDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GHYUsersDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GHYUsersDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GHYUsersDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Token> Token
		{
			get
			{
				return this.GetTable<Token>();
			}
		}
		
		public System.Data.Linq.Table<User> User
		{
			get
			{
				return this.GetTable<User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Token")]
	public partial class Token : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _TokenID;
		
		private System.Guid _UserID;
		
		private string _TokenCode;
		
		private string _CheckCode;
		
		private System.DateTime _Expire;
		
		private int _Status;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTokenIDChanging(System.Guid value);
    partial void OnTokenIDChanged();
    partial void OnUserIDChanging(System.Guid value);
    partial void OnUserIDChanged();
    partial void OnTokenCodeChanging(string value);
    partial void OnTokenCodeChanged();
    partial void OnCheckCodeChanging(string value);
    partial void OnCheckCodeChanged();
    partial void OnExpireChanging(System.DateTime value);
    partial void OnExpireChanged();
    partial void OnStatusChanging(int value);
    partial void OnStatusChanged();
    #endregion
		
		public Token()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TokenID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid TokenID
		{
			get
			{
				return this._TokenID;
			}
			set
			{
				if ((this._TokenID != value))
				{
					this.OnTokenIDChanging(value);
					this.SendPropertyChanging();
					this._TokenID = value;
					this.SendPropertyChanged("TokenID");
					this.OnTokenIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TokenCode", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string TokenCode
		{
			get
			{
				return this._TokenCode;
			}
			set
			{
				if ((this._TokenCode != value))
				{
					this.OnTokenCodeChanging(value);
					this.SendPropertyChanging();
					this._TokenCode = value;
					this.SendPropertyChanged("TokenCode");
					this.OnTokenCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CheckCode", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string CheckCode
		{
			get
			{
				return this._CheckCode;
			}
			set
			{
				if ((this._CheckCode != value))
				{
					this.OnCheckCodeChanging(value);
					this.SendPropertyChanging();
					this._CheckCode = value;
					this.SendPropertyChanged("CheckCode");
					this.OnCheckCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Expire", DbType="DateTime NOT NULL")]
		public System.DateTime Expire
		{
			get
			{
				return this._Expire;
			}
			set
			{
				if ((this._Expire != value))
				{
					this.OnExpireChanging(value);
					this.SendPropertyChanging();
					this._Expire = value;
					this.SendPropertyChanged("Expire");
					this.OnExpireChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _UserID;
		
		private string _Email;
		
		private string _Password;
		
		private string _ＮickName;
		
		private string _StuNumber;
		
		private string _Avatar;
		
		private System.Nullable<int> _Sex;
		
		private string _Tel;
		
		private string _TrueName;
		
		private System.DateTime _RegisterTime;
		
		private int _Status;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(System.Guid value);
    partial void OnUserIDChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnＮickNameChanging(string value);
    partial void OnＮickNameChanged();
    partial void OnStuNumberChanging(string value);
    partial void OnStuNumberChanged();
    partial void OnAvatarChanging(string value);
    partial void OnAvatarChanged();
    partial void OnSexChanging(System.Nullable<int> value);
    partial void OnSexChanged();
    partial void OnTelChanging(string value);
    partial void OnTelChanged();
    partial void OnTrueNameChanging(string value);
    partial void OnTrueNameChanged();
    partial void OnRegisterTimeChanging(System.DateTime value);
    partial void OnRegisterTimeChanged();
    partial void OnStatusChanging(int value);
    partial void OnStatusChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ＮickName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string ＮickName
		{
			get
			{
				return this._ＮickName;
			}
			set
			{
				if ((this._ＮickName != value))
				{
					this.OnＮickNameChanging(value);
					this.SendPropertyChanging();
					this._ＮickName = value;
					this.SendPropertyChanged("ＮickName");
					this.OnＮickNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StuNumber", DbType="NVarChar(50)")]
		public string StuNumber
		{
			get
			{
				return this._StuNumber;
			}
			set
			{
				if ((this._StuNumber != value))
				{
					this.OnStuNumberChanging(value);
					this.SendPropertyChanging();
					this._StuNumber = value;
					this.SendPropertyChanged("StuNumber");
					this.OnStuNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Avatar", DbType="NVarChar(255)")]
		public string Avatar
		{
			get
			{
				return this._Avatar;
			}
			set
			{
				if ((this._Avatar != value))
				{
					this.OnAvatarChanging(value);
					this.SendPropertyChanging();
					this._Avatar = value;
					this.SendPropertyChanged("Avatar");
					this.OnAvatarChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sex", DbType="Int")]
		public System.Nullable<int> Sex
		{
			get
			{
				return this._Sex;
			}
			set
			{
				if ((this._Sex != value))
				{
					this.OnSexChanging(value);
					this.SendPropertyChanging();
					this._Sex = value;
					this.SendPropertyChanged("Sex");
					this.OnSexChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tel", DbType="NVarChar(50)")]
		public string Tel
		{
			get
			{
				return this._Tel;
			}
			set
			{
				if ((this._Tel != value))
				{
					this.OnTelChanging(value);
					this.SendPropertyChanging();
					this._Tel = value;
					this.SendPropertyChanged("Tel");
					this.OnTelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrueName", DbType="NVarChar(50)")]
		public string TrueName
		{
			get
			{
				return this._TrueName;
			}
			set
			{
				if ((this._TrueName != value))
				{
					this.OnTrueNameChanging(value);
					this.SendPropertyChanging();
					this._TrueName = value;
					this.SendPropertyChanged("TrueName");
					this.OnTrueNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RegisterTime", DbType="DateTime NOT NULL")]
		public System.DateTime RegisterTime
		{
			get
			{
				return this._RegisterTime;
			}
			set
			{
				if ((this._RegisterTime != value))
				{
					this.OnRegisterTimeChanging(value);
					this.SendPropertyChanging();
					this._RegisterTime = value;
					this.SendPropertyChanged("RegisterTime");
					this.OnRegisterTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
