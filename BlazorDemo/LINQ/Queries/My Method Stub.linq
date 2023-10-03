<Query Kind="Program" />

void Main()
{
	
}

public void MyMethod
{
	#region Business Logic and Parameter Exception
	//	create a List<Exception> to conatin all discoverd errors
	List<Exception> errorList = new List<Exception>();
	//	Business Rules (all business rules are listed here)


	//	parameter validation

	#endregion

	/*
		actual code for method
	*/
	if (errorList.Count() > 0)
	{
		throw new AggregateException("Unable to proceed!  Check concerns", errorList);
	}

	//	NOTE: we return a "null" so that the application does not throw an exception
	//			"not al code paths return a value"
	return null;
}