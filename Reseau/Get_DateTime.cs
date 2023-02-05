using System;
using System.Globalization;
using System.Net;

public class Get_DateTime{
		
	public static DateTime GetNetTime()
	{
		var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
		WebResponse response=null;

		try
        {
			response = myHttpWebRequest.GetResponse();
		}
		catch (Exception)
        {
			return DateTime.MinValue;
        }

		string todaysDates = response.Headers["date"];
		return DateTime.ParseExact(todaysDates,
								   "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
								   CultureInfo.InvariantCulture.DateTimeFormat,
								   DateTimeStyles.AssumeUniversal);
	}

}