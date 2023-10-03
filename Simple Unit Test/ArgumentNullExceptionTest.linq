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
		//	passing a track ID larger than max TrackID
		ArgumentNullExceptionTest(10000);
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

public void ArgumentNullExceptionTest(int trackID)
{
	#region Buiness Logic and parameter exception
	//	create a List<Exception> to contain all discovered errors
	List<Exception> errorList = new List<Exception>();
	//	Business Rules
	//		rule:	Track must exist in the database

	//	parameter validation
	var track = Tracks
					.Where(x => x.TrackId == trackID)
					.Select(x => x).FirstOrDefault();

	if (track == null)
	{
		throw new ArgumentNullException($"No track was found Track ID: {trackID}");
	}
	#endregion

	/*
		actual code for method.
	*/

	if (errorList.Count() > 0)
	{
		//	throw the list of business processing error(s)
		throw new AggregateException("Unable to process! Check concerns", errorList);
	}
}


// You can define other methods, fields, classes and namespaces here