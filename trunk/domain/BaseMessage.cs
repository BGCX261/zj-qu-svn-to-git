/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-24
 * Time: 21:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace domain
{
	/// <summary>
	/// Description of BaseMessage.
	/// </summary>
	public class BaseMessage:Message
	{
		byte[] data;
		public BaseMessage(byte[] data)
		{
			this.data = data;
		}
		public byte[] getData()
		{
			return this.data;
		}
		public void pushData(byte[] data)
		{
			this.data = data;
		}
		
	}
}
