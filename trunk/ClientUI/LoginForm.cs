/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-27
 * Time: 11:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using domain;
namespace ClientUI
{
	/// <summary>
	/// Description of LoginForm.
	/// </summary>
	public partial class LoginForm : Form
	{
		private MainForm mainForm;
		private RegistForm registForm;
		private LoginForm()
		{
			InitializeComponent();
		}
		public LoginForm(MainForm mainForm):this()
		{
			this.mainForm = mainForm;
		}
		
		void RegistToolStripMenuItemClick(object sender, EventArgs e)
		{
			registForm = new RegistForm(this);
			this.Visible = false;
			registForm.Visible = true;
		}
		
		void Btn_loginClick(object sender, EventArgs e)
		{
			string loginName = this.txt_loginName.Text;
			string psw = this.txt_psw.Text;
			if(validate(loginName,psw))
			{
				User.login(loginName,psw);
			}
		}
		
		private bool validate(string loginName,string psw)
		{
			bool flag = true;
			if(null == loginName || null == psw || "".Equals(loginName.Trim()) || "".Equals(psw.Trim()))
			{
				MessageBox.Show("口令或者登录名不正确");
				flag = false;
			}
			return flag;
		}
		protected override void OnClosed(EventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
