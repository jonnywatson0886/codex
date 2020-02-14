using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Linq;
using ExampleWebAPIone.Models;
using System;
using System.Data.Linq.Mapping;
using ExampleWebAPIone.Models.DataModels.DataAccess;
using ExampleWebAPIone.Models.DataModels.DataInput;

namespace ExampleWebAPIone.Scripts
{

	public class SQLFunctions
	{
		private Table<CustomersDAO> incommingCustomers;
		private Table<CustomerDOO> outputCustomer;
		private DataContext db;
		private SqlConnectionStringBuilder sb;

		/// <summary>
		/// constructor
		/// </summary>
		public SQLFunctions()
		{
			setupSQL();
		}

		/// <summary>
		/// used to create linq bewteen this appliaction and the sql server
		/// </summary>
		private void setupSQL()
		{
			//setup data base connection
			sb = new SqlConnectionStringBuilder();

			//server location
			sb.DataSource = @"JONATHAN-WATSON\MSSQLSERVER01";
			//database on server
			sb.InitialCatalog = "DemoDatabase";
			//user id (wouldn't reguarly in plane text and inputted or via access token)
			sb.UserID = "test";
			//users password same as userID 
			sb.Password = "test";

			//create new local db link 
			db = new DataContext(sb.ConnectionString);
			//set the table model to link the sql
			incommingCustomers = db.GetTable<CustomersDAO>();
			outputCustomer = db.GetTable<CustomerDOO>();
		}

		/// <summary>
		/// makes an sql qeurey to get all people currently within the table customers on my sql server
		/// </summary>
		/// <returns></returns>
		public List<CustomersDAO> GetAllPeople()
		{
			IQueryable<CustomersDAO> custQuery = from cust in incommingCustomers select cust;
			return GetPeople(custQuery);
		}
		/// <summary>
		/// function made to get people from query into a list of person datamodel type
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		private List<CustomersDAO> GetPeople(IQueryable<CustomersDAO> query)
		{
			List<CustomersDAO> people = new List<CustomersDAO>();
			foreach (CustomersDAO cust in query)
			{
				people.Add(cust);
			}
			return people;
		}

		/// <summary>
		/// class that attempts to add a person object taken from a post request and add them in to the 
		/// uses standard c# commiaction setup with stored procedure to do this
		/// </summary>
		/// <param name="incommingPerson"></param>
		/// <returns>if successful or not </returns>
		public bool AddPersonToPeople(CustomerDOO incommingPerson)
		{
			//create connection object(to be setup in config file in future)
			SqlConnection connection = new SqlConnection(sb.ConnectionString);
			//create blank sql command
			SqlCommand cmd = new SqlCommand()
			{ 
			Connection = connection,
			CommandText = "SPaddNewCustomer"
			};
			connection.Open();		
			using (connection)
			{	
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("email", incommingPerson.Email)
				{
					Direction = System.Data.ParameterDirection.Input,
					DbType = System.Data.DbType.String
				});

				cmd.Parameters.Add(new SqlParameter("firstName", incommingPerson.FirstName)
				{
					Direction = System.Data.ParameterDirection.Input,
					DbType = System.Data.DbType.String
				});	
				
				cmd.Parameters.Add(new SqlParameter("lastName", incommingPerson.LastName)
				{
					Direction = System.Data.ParameterDirection.Input,
					DbType = System.Data.DbType.String
				});	
				
				cmd.Parameters.Add(new SqlParameter("address", incommingPerson.Address)
				{
					Direction = System.Data.ParameterDirection.Input,
					DbType = System.Data.DbType.String
				});		
				
				cmd.Parameters.Add(new SqlParameter("postcode", incommingPerson.Postcode)
				{
					Direction = System.Data.ParameterDirection.Input,
					DbType = System.Data.DbType.String
				});
				try
				{
					cmd.ExecuteNonQuery();
				}
				catch(Exception ex)
				{
					
					connection.Close();
					return false;
				}
			}
			connection.Close();
			return true;
		}
		//[Function(Name = "dbo.SPaddNewCustomer")]
		//public bool AddInPersonSP
		//	(
		//	[Parameter(Name = "email", DbType = "varChar(50)")] string email,
		//	[Parameter(Name = "firstName", DbType = "varChar(20)")] string firstName,
		//	[Parameter(Name = "lastName", DbType = "varChar(20)")] string lastName,
		//	[Parameter(Name = "address ", DbType = "varChar(60)")] string address,
		//	[Parameter(Name = "postcode", DbType = "varChar(8)")] string postcode
		//	)
		//{


		//}
	}
}