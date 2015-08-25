/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-24
 * Time: 21:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Net.Sockets;

namespace domain
{
	/// <summary>
	/// Description of IUdpTool.
	/// </summary>
	public interface IUdpTool
	{
		void send(byte[] data,IPEndPoint remotePoint);
	}
}
