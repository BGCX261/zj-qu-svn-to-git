/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-24
 * Time: 21:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Net.Sockets;

namespace domain
{
	/// <summary>
	/// Description of MyUdpTool.
	/// </summary>
	public class MyUdpTool:IUdpTool
	{
		private static IUdpTool instance;
		private Socket client;
		private MyUdpTool()
		{
		}
		public static IUdpTool getInstance()
		{
			if(null == instance)
			{
				instance = new MyUdpTool();
			}
			return instance;
		}
		public void send(byte[] data,IPEndPoint remotePoint)
		{
			client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			client.SendTo(data, data.Length, SocketFlags.None, remotePoint);
			client.Close();
		}
		
	}
}
