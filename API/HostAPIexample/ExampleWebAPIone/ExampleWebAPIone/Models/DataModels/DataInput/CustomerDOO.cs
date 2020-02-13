using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace ExampleWebAPIone.Models.DataModels.DataInput
{
	[Table(Name = "Customers")]
	public class CustomerDOO
	{
		private int _Id;
		[Column(Storage ="_Id", IsPrimaryKey = true, CanBeNull = true)]

		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}


		private string _Email;
		[Column(Storage = "_Email")]

		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}


		private string _FirstName;
		[Column(Storage = "_FirstName")]
		public string FirstName
		{
			get { return _FirstName; }
			set { _FirstName = value; }
		}

		private string _LastName;
		[Column(Storage = "_LastName")]
		public string LastName
		{
			get { return _LastName; }
			set { _LastName = value; }
		}

		private string _Address;
		[Column(Storage = "_Address")]
		public string Address
		{
			get { return _Address; }
			set { _Address = value; }
		}

		private string _Postcode;
		[Column(Storage = "_Postcode")]
		public string Postcode
		{
			get { return _Postcode; }
			set { _Postcode = value; }
		}
	}
}
