using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExampleWebAPIone.Models;
using ExampleWebAPIone.Models.DataModels.DataAccess;
using ExampleWebAPIone.Models.DataModels.DataInput;
using ExampleWebAPIone.Scripts;

namespace ExampleWebAPIone.Controllers
{
	public class PeopleController : ApiController
	{
		private SQLFunctions sQL;
		public PeopleController()
		{
			sQL = new SQLFunctions();
		}
		// GET endpoint for the api to return only the 
		[Route("api/listAllPeople")]
		public List<CustomersDAO> GetAllPeople()
		{
			return sQL.GetAllPeople();
		}

		[Route("api/AddPerson")]
		public bool Post(CustomerDOO val)
		{
			return sQL.AddPersonToPeople(val);
		}
	}
}
