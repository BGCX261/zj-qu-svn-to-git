/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-24
 * Time: 21:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Net.Sockets;
namespace domain
{
	/// <summary>
	/// Description of AddressFactory.
	/// </summary>
	public class AddressFactory
	{
		private static IPEndPoint serverPoint ;
		
		public AddressFactory()
		{
		}
		public static IPEndPoint getServerPoint()
		{
			serverPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),Grobal.SERVER_PORT);
			return serverPoint;
		}
		public static IPEndPoint getServerPoint(string ip,int port)
		{
			serverPoint = new IPEndPoint(IPAddress.Parse(ip),port);
			return serverPoint;
		}
		
		public static string getLocalIP()
		{
			IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
			return hostEntry.AddressList[0].ToString();
		}
		
	}
}
