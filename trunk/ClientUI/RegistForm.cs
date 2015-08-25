/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-27
 * Time: 10:53
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
	/// Description of RegistForm.
	/// </summary>
	public partial class RegistForm : Form
	{
		private LoginForm loginForm;
		private RegistForm()
		{
			InitializeComponent();
		}
		public RegistForm(LoginForm loginForm):this()
		{
			this.loginForm = loginForm;
		}
		
		void Btn_registClick(object sender, EventArgs e)
		{
			string loginName = this.txt_loginName.Text;
			string psw = this.txt_psw.Text;
			if(validate(loginName,psw))
			{
				User.regist(new User(loginName,psw));
				this.loginForm.txt_loginName.Text = loginName;
				this.loginForm.txt_psw.Text = psw;
				this.Close();
			}
		}
		private bool validate(string loginName,string psw)
		{
			bool flag = true;
			if(null == loginName || null == psw || "".Equals(loginName.Trim()) || "".Equals(psw.Trim()))
			{
				MessageBox.Show("口令或者登录名不正确");
				this.txt_loginName.Focus();
				flag = false;
			}
			return flag;
		}
		
		protected override void OnClosed(EventArgs e)
		{
			this.Visible = false;
			this.loginForm.Visible = true;
			this.Dispose();
		}
		
	}
}
