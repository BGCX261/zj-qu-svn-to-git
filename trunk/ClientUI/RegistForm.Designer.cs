/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-27
 * Time: 10:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ClientUI
{
	partial class RegistForm
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
			this.btn_regist = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "登录名";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "口令";
			// 
			// txt_loginName
			// 
			this.txt_loginName.Location = new System.Drawing.Point(60, 5);
			this.txt_loginName.Name = "txt_loginName";
			this.txt_loginName.Size = new System.Drawing.Size(125, 21);
			this.txt_loginName.TabIndex = 2;
			// 
			// txt_psw
			// 
			this.txt_psw.Location = new System.Drawing.Point(60, 37);
			this.txt_psw.Name = "txt_psw";
			this.txt_psw.Size = new System.Drawing.Size(125, 21);
			this.txt_psw.TabIndex = 3;
			// 
			// btn_regist
			// 
			this.btn_regist.Location = new System.Drawing.Point(110, 64);
			this.btn_regist.Name = "btn_regist";
			this.btn_regist.Size = new System.Drawing.Size(75, 23);
			this.btn_regist.TabIndex = 4;
			this.btn_regist.Text = "注册";
			this.btn_regist.UseVisualStyleBackColor = true;
			this.btn_regist.Click += new System.EventHandler(this.Btn_registClick);
			// 
			// RegistForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(190, 92);
			this.Controls.Add(this.btn_regist);
			this.Controls.Add(this.txt_psw);
			this.Controls.Add(this.txt_loginName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "RegistForm";
			this.Text = "RegistForm";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btn_regist;
		public System.Windows.Forms.TextBox txt_psw;
		public System.Windows.Forms.TextBox txt_loginName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
