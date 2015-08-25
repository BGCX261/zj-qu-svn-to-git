/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-25
 * Time: 7:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using domain;

namespace ClientUI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private LoginForm loginForm;
		private Thread listenThread;
		private ISerialize serializeTool = ToSerialize.getInstance();
		public MainForm()
		{
			InitializeComponent();
			myInit();
		}
		
		private void myInit()
		{
			hideWindow(true);
			showLoginForm();
			listenThread = new Thread(new ThreadStart(ref listen));
			listenThread.Start();
		}
		private void hideWindow(bool hide)
		{
			this.ShowInTaskbar = !hide;
			this.WindowState = hide ? FormWindowState.Minimized : FormWindowState.Normal;
		}
		
		private void showLoginForm()
		{
			loginForm = new LoginForm(this);
			loginForm.Visible = true;
		}
		void QuitToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
		
		private void listen()
		{
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			IPEndPoint sender = new IPEndPoint(IPAddress.Any, Grobal.CLIENT_PORT);
			EndPoint senderRemote = (EndPoint)sender;
			socket.Bind(senderRemote);
			byte[] msg = new Byte[8888];
			while(true)
			{
				socket.ReceiveFrom(msg, msg.Length, SocketFlags.None, ref senderRemote);
				pullMsgAndDoneIt(new domain.BaseMessage(msg));
			}
		}
		private void pullMsgAndDoneIt(domain.Message message)
		{
			Dictionary<string, object> map = new Dictionary<string, object>();
			map = serializeTool.Desrialize<Dictionary<string, object>>(map,message.getData());
			if(null == map || map.Count == 0){return ;}
			string operType = map[Grobal.USER_OPERATION].ToString();
			User user = (User)map[Grobal.USER];
			/*注册*/
			if(Grobal.REGIST.Equals(operType))
			{
				string result = map[Grobal.RESULT].ToString();
				if(Grobal.SUCCESS.Equals(result))
				{
					this.loginForm.txt_loginName.Text = user.LoginName;
				}
				else
				{
					MessageBox.Show("用户已存在");
				}
			}//登录
			else if(Grobal.LOGIN.Equals(operType))
			{
				string result = map[Grobal.RESULT].ToString();
				if(Grobal.SUCCESS.Equals(result))
				{
					
				}
				else
				{
					MessageBox.Show("登录名或者口令不正确!");
				}
			}
		}
		
		
	}
}
