/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-24
 * Time: 21:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace domain
{
	/// <summary>
	/// Description of User.
	/// </summary>
	[Serializable]
	public class User
	{
		private int listenToPort = 10002;
		public User()
		{
			localPoint = new IPEndPoint(IPAddress.Parse(AddressFactory.getLocalIP()),listenToPort);
		}
		
		public User(string loginName, string password):this()
		{
			this.loginName = loginName;
			this.password = password;
		}
		
		public static void regist(User user)
		{
			operationTemple(user,Grobal.REGIST);
		}
		
		public static void login(string loginName,string password)
		{
			
			operationTemple(new User(loginName,password),Grobal.LOGIN);
		}
		
		public void sendMsg(string message_str ,User toSomebody)
		{
			Dictionary<string,object> map = new Dictionary<string,object>();
			map.Add(Grobal.USER_OPERATION,Grobal.SENDMSG);
			map.Add(Grobal.FROM_USER,this);
			map.Add(Grobal.TO_USER,toSomebody);
			map.Add(Grobal.MESSAGE,message_str);
			Message message = new BaseMessage(serializeTool.Serialize<Dictionary<string,object>>(map));
			udpTool.send(message.getData(),serverPotint);
		}
		
		public void logout()
		{
			operationTemple(this,Grobal.LOGOUT);
		}
		
		private static void operationTemple(User user,string oper)
		{
			Dictionary<string,object> map = new Dictionary<string,object>();
			map.Add(Grobal.USER_OPERATION,oper);
			map.Add(Grobal.USER,user);
			Message message = new BaseMessage(serializeTool.Serialize<Dictionary<string,object>>(map));
			udpTool.send(message.getData(),serverPotint);
		}
		
		private int id;
		private string loginName;
		private string password;
		
		private IPEndPoint localPoint = null;
		private static IPEndPoint serverPotint = AddressFactory.getServerPoint();
		private static ISerialize serializeTool = ToSerialize.getInstance();
		private static IUdpTool udpTool = MyUdpTool.getInstance();
		
		public int Id {
			get { return id; }
			set { id = value; }
		}
		
		public string LoginName {
			get { return loginName; }
			set { loginName = value; }
		}
		
		public string Password {
			get { return password; }
			set { password = value; }
		}
		
		public IPEndPoint LocalPoint {
			get { return localPoint; }
			set { localPoint = value; }
		}
		
		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				hashCode += 1000000007 * id.GetHashCode();
				if (loginName != null)
					hashCode += 1000000009 * loginName.GetHashCode();
				if (password != null)
					hashCode += 1000000021 * password.GetHashCode();
			}
			return hashCode;
		}
		
		public override bool Equals(object obj)
		{
			User other = obj as User;
			if (other == null)
				return false;
			return this.id == other.id && this.loginName == other.loginName && this.password == other.password;
		}
	}
}
