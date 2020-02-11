using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleWebAPIone.Models
{
	/// <summary>
	/// class for  a person
	/// </summary>
	public class Person
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = " ";
		public string SecondName { get; set; } = " ";
	}
}