/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-27
 * Time: 11:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ClientUI
{
	partial class LoginForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_loginName = new System.Windows.Forms.TextBox();
			this.txt_psw = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.registToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_login = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "登录名";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "口令";
			// 
			// txt_loginName
			// 
			this.txt_loginName.Location = new System.Drawing.Point(70, 32);
			this.txt_loginName.Name = "txt_loginName";
			this.txt_loginName.Size = new System.Drawing.Size(140, 21);
			this.txt_loginName.TabIndex = 2;
			// 
			// txt_psw
			// 
			this.txt_psw.Location = new System.Drawing.Point(70, 64);
			this.txt_psw.Name = "txt_psw";
			this.txt_psw.Size = new System.Drawing.Size(140, 21);
			this.txt_psw.TabIndex = 3;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.registToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(216, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// registToolStripMenuItem
			// 
			this.registToolStripMenuItem.Name = "registToolStripMenuItem";
			this.registToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.registToolStripMenuItem.Text = "Regist";
			this.registToolStripMenuItem.Click += new System.EventHandler(this.RegistToolStripMenuItemClick);
			// 
			// btn_login
			// 
			this.btn_login.Location = new System.Drawing.Point(135, 91);
			this.btn_login.Name = "btn_login";
			this.btn_login.Size = new System.Drawing.Size(75, 23);
			this.btn_login.TabIndex = 5;
			this.btn_login.Text = "登录";
			this.btn_login.UseVisualStyleBackColor = true;
			this.btn_login.Click += new System.EventHandler(this.Btn_loginClick);
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(216, 125);
			this.Controls.Add(this.btn_login);
			this.Controls.Add(this.txt_psw);
			this.Controls.Add(this.txt_loginName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "LoginForm";
			this.Text = "LoginForm";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox txt_loginName;
		public System.Windows.Forms.TextBox txt_psw;
		private System.Windows.Forms.Button btn_login;
		private System.Windows.Forms.ToolStripMenuItem registToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
