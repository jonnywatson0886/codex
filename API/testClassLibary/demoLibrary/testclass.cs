using System.Collections.Generic;
using ExampleWebAPIone.Models.DataModels.DataAccess;
using ExampleWebAPIone.Scripts;
using Xunit;

namespace demoLibrary
{
	public class testClass
	{
		//test that is a yes or no
		[Fact]
		public void GetListAllPeople_NoValuesGiveListOfPeople()
		{
			//arrange
			int expectedCount = 1;
			SQLFunctions functions = new SQLFunctions();
			//act
			List <CustomersDAO> actualCount = functions.GetAllPeople();
			//result(Assert)
			Assert.True(expectedCount <= actualCount.Count);
		}

	}
}
