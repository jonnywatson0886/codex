using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExampleWebAPIone.Validation
{
	public class ModelValidator
	{
		//each data type has it own validation

		/// <summary>
		/// checks to see if end of string is inline with email and has @ simbol if not throw execption
		/// </summary>
		/// <param name="emailChecked"></param>
		/// <returns></returns>
		private bool ValidateEmailAddress(string emailChecked)
		{
			try
			{
				if ((emailChecked.EndsWith("interhigh.co.uk") || emailChecked.EndsWith("academy21.co.uk")) && (emailChecked.Contains("@")))
				{
					return true;
				}
				else
				{
					throw new Exception();
				}
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// vaildates a name by checking for numbers
		/// </summary>
		/// <param name="nameChecked"></param>
		/// <returns></returns>
		private bool ValidateName(string nameChecked)
		{
			try
			{
				//go though word
				foreach (char c in nameChecked)
				{
					//if char is number then cannot be name throw exception and return false
					if (char.IsDigit(c))
					{
						throw new Exception();
					}
				}
				//all is well
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// validates the length of the address string
		/// </summary>
		/// <returns></returns>
		private bool ValidateAddress(string addressChecked)
		{
			try
			{
				if (addressChecked.Length > 60)
					throw new Exception();
				else
					return true;
			}
			catch
			{
				return false;
			}
		}

		private bool ValidatePostcode(string postcodeChecked)
		{
			try
			{
				if ((postcodeChecked.Length > 8) || (postcodeChecked.Length < 6))
					throw new Exception();
				else
					return true;
			}
			catch 
			{
				return false;
			}
		}
	}

}
}