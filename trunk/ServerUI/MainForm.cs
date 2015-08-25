/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-24
 * Time: 23:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;
using domain;
namespace ServerUI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private Thread listenToit ;
		private ISerialize serializeTool = ToSerialize.getInstance();
		private const int serverListen = 10003;
		private ServerApplication application ;
		public MainForm()
		{
			InitializeComponent();
			application = new ServerApplication();
		}
		
		void StartToolStripMenuItemClick(object sender, EventArgs e)
		{
			listenToit = new Thread(new ThreadStart(ref listen));
			listenToit.Start();
			this.startToolStripMenuItem.Enabled = false;
		}
		
		protected override void OnClosed(EventArgs e)
		{
			this.listenToit.Abort();
			Environment.Exit(0);
		}
		
		private void listen()
		{
			Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			IPEndPoint sender = new IPEndPoint(IPAddress.Any, serverListen);
			EndPoint senderRemote = (EndPoint)sender;
			server.Bind(senderRemote);
			byte[] msg = new Byte[8888];
			while(true)
			{
				server.ReceiveFrom(msg, msg.Length, SocketFlags.None, ref senderRemote);
				pullMsgAndDoneIt(new domain.BaseMessage(msg));
			}
		}
		
		private void pullMsgAndDoneIt(domain.Message message)
		{
			Dictionary<string, object> map = new Dictionary<string, object>();
			map = serializeTool.Desrialize<Dictionary<string, object>>(map,message.getData());
			if(null == map){return ;}
			string operType = map[Grobal.USER_OPERATION].ToString();
			User user = (User)map[Grobal.USER];
			if(Grobal.REGIST.Equals(operType))
			{
				application.regist(user);
			}
			else if(Grobal.LOGIN.Equals(operType))
			{
				application.login(user);
			}
			else if(Grobal.LOGOUT.Equals(operType))
			{
				application.logout(user);
			}
			else if(Grobal.SENDMSG.Equals(operType))
			{
				application.sendMsg(message,(User)map[Grobal.FROM_USER]);
			}
		}
		
		
		
	}
}
