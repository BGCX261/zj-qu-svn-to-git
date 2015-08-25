/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-25
 * Time: 20:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using domain;

namespace ServerUI
{
	/// <summary>
	/// Description of ServerApplication.
	/// </summary>
	public class ServerApplication
	{
		private SqlTool sqlTool = SqlTool.getInstance();
		private IUdpTool udpTool = MyUdpTool.getInstance();
		private ISerialize serializeTool = ToSerialize.getInstance();
		public ServerApplication()
		{
		}
		
		public void sendMsg(domain.Message message,User whoRev)
		{
			udpTool.send(message.getData(),whoRev.LocalPoint);
		}
		
		public void regist(User user)
		{
			
			string sql = @"insert into users (loginname,psw,active) values('"+user.LoginName+"','"+user.Password+"',0);";
			User resultUser = findUser(user.LoginName);
			string result = resultUser!=null ? Grobal.FAILURE : Grobal.SUCCESS;
			if(Grobal.SUCCESS.Equals(result))
			{
				int count = sqlTool.update(sql);
				if(count <= 0) result = Grobal.FAILURE;
			}
			sendResultToclient(user,Grobal.REGIST,result);
		}
		
		public void login(User user)
		{
			string sql = @"update users set active=true where loginname='"+user.LoginName+"' and password='"+user.Password+"'";
			User resultUser = findUser(user.LoginName,user.Password);
			string result = resultUser!=null ? Grobal.SUCCESS : Grobal.FAILURE;
			if(Grobal.SUCCESS.Equals(result))
			{
				int count = sqlTool.update(sql);
				if(count <= 0) result = Grobal.FAILURE;
				
			}
			else
			{
				sendResultToclient(user,Grobal.LOGIN,false);
			}
			
		}
		
		public void logout(User user)
		{
			string sql = @"update users set active=false where id=" + user.Id;
			string result = sqlTool.update(sql) > 0 ? Grobal.SUCCESS:Grobal.FAILURE;
			sendResultToclient(user,Grobal.LOGOUT,result);
		}
		
		public User findUser(string loginName, string password)
		{
			string sql = @"select * from users where loginName ='" + loginName +"' and psw='"+ password +"'";
			DataTable table = sqlTool.query(sql);
			if(null == table || table.Rows.Count ==0) return null;
			User user = null; ;
			foreach(DataRow row in table.Rows)
			{
				user = new User();
				user.Id = (int)row["id"];
				user.LoginName = loginName;
				user.Password = password;
			}
			return user;
		}
		
		
		public User findUser(string loginName)
		{
			string sql = @"select * from users where loginName ='" + loginName +"'";
			DataTable table = sqlTool.query(sql);
			if(null == table || table.Rows.Count ==0) return null;
			User user = null; ;
			foreach(DataRow row in table.Rows)
			{
				user = new User();
				user.Id = (int)row["id"];
				user.LoginName = loginName;
			}
			return user;
		}
		
		
		public void sendResultToclient(User user,string userOperation, string result)
		{
			Dictionary<string, object> map = new Dictionary<string, object>();
			map.Add(Grobal.USER_OPERATION,userOperation);
			map.Add(Grobal.RESULT,result);
			map.Add(Grobal.USER,user);
			domain.Message msg = new BaseMessage(serializeTool.Serialize(map));
			udpTool.send(msg.getData(),user.LocalPoint);
		}
	}
}
