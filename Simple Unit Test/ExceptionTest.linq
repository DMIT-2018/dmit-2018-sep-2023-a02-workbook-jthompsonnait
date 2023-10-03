<Query Kind="Program">
  <Connection>
    <ID>544742c2-956f-4ff6-965a-61ab55d5434e</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>ChinookSept2018</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	try
	{
		//	passing an invalid track ID (less than 1)
		ExceptionTest(0);
	}
	#region catch all exceptions
	catch (AggregateException ex)
	{
		foreach (var error in ex.InnerExceptions)
		{
			error.Message.Dump();
		}
	}
	catch (ArgumentNullException ex)
	{
		GetInnerException(ex).Message.Dump();
	}
	catch (Exception ex)
	{
		GetInnerException(ex).Message.Dump();
	}
	#endregion
}

private Exception GetInnerException(Exception ex)
{
	while (ex.InnerException != null)
		ex = ex.InnerException;
	return ex;
}

public void ExceptionTest(int trackID)
{
	#region Business Logic and Parameter Exception
	//	create a List<Exception> to conatin all discoverd errors
	List<Exception> errorList = new List<Exception>();
	//	Business Rules
	//		rule:	Track ID must be valid

	//	parameter validation
	//	This is a show stopper and no reason to go beyond this
	//		point of code!!!
	if (trackID < 1)
	{
		throw new Exception("TrackID is invalid");
	}
	#endregion

	/*
		actual code for method
	*/
	if (errorList.Count() > 0)
	{
		throw new AggregateException("Unable to proceed!  Check concerns", errorList);
	}
}













