namespace WindowsForms
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.cbShowDate = new System.Windows.Forms.CheckBox();
			this.bHideControl = new System.Windows.Forms.Button();
			this.bClose = new System.Windows.Forms.Button();
			this.NotifyIconClock = new System.Windows.Forms.NotifyIcon(this.components);
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.btnSystemFonts = new System.Windows.Forms.Button();
			this.btnCustomFonts = new System.Windows.Forms.Button();
			this.btnBackColor = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(24, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(238, 91);
			this.label1.TabIndex = 0;
			this.label1.Text = "Clock";
			this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// cbShowDate
			// 
			this.cbShowDate.AutoSize = true;
			this.cbShowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbShowDate.Location = new System.Drawing.Point(31, 228);
			this.cbShowDate.Name = "cbShowDate";
			this.cbShowDate.Size = new System.Drawing.Size(231, 50);
			this.cbShowDate.TabIndex = 1;
			this.cbShowDate.Text = "Show date";
			this.cbShowDate.UseVisualStyleBackColor = true;
			this.cbShowDate.Visible = false;
			this.cbShowDate.CheckedChanged += new System.EventHandler(this.cbShowDate_CheckedChanged);
			// 
			// bHideControl
			// 
			this.bHideControl.Location = new System.Drawing.Point(31, 316);
			this.bHideControl.Name = "bHideControl";
			this.bHideControl.Size = new System.Drawing.Size(215, 55);
			this.bHideControl.TabIndex = 2;
			this.bHideControl.Text = "Hide controls";
			this.bHideControl.UseVisualStyleBackColor = true;
			this.bHideControl.Visible = false;
			this.bHideControl.Click += new System.EventHandler(this.bHideControl_Click);
			// 
			// bClose
			// 
			this.bClose.Location = new System.Drawing.Point(31, 390);
			this.bClose.Name = "bClose";
			this.bClose.Size = new System.Drawing.Size(215, 55);
			this.bClose.TabIndex = 3;
			this.bClose.Text = "Close";
			this.bClose.UseVisualStyleBackColor = true;
			this.bClose.Visible = false;
			this.bClose.Click += new System.EventHandler(this.bClose_Click);
			// 
			// NotifyIconClock
			// 
			this.NotifyIconClock.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIconClock.Icon")));
			this.NotifyIconClock.Text = "Clock";
			this.NotifyIconClock.Visible = true;
			this.NotifyIconClock.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconClock_MouseClick);
			// 
			// fontDialog1
			// 
			this.fontDialog1.ShowColor = true;
			// 
			// btnSystemFonts
			// 
			this.btnSystemFonts.Location = new System.Drawing.Point(290, 316);
			this.btnSystemFonts.Name = "btnSystemFonts";
			this.btnSystemFonts.Size = new System.Drawing.Size(206, 38);
			this.btnSystemFonts.TabIndex = 4;
			this.btnSystemFonts.Text = "System Fonts Settings";
			this.btnSystemFonts.UseVisualStyleBackColor = true;
			this.btnSystemFonts.Visible = false;
			this.btnSystemFonts.Click += new System.EventHandler(this.btnSystemFonts_Click);
			// 
			// btnCustomFonts
			// 
			this.btnCustomFonts.Location = new System.Drawing.Point(290, 360);
			this.btnCustomFonts.Name = "btnCustomFonts";
			this.btnCustomFonts.Size = new System.Drawing.Size(206, 37);
			this.btnCustomFonts.TabIndex = 5;
			this.btnCustomFonts.Text = "Custom Fonts Settings";
			this.btnCustomFonts.UseVisualStyleBackColor = true;
			this.btnCustomFonts.Visible = false;
			this.btnCustomFonts.Click += new System.EventHandler(this.btnCustomFonts_Click);
			// 
			// btnBackColor
			// 
			this.btnBackColor.Location = new System.Drawing.Point(290, 403);
			this.btnBackColor.Name = "btnBackColor";
			this.btnBackColor.Size = new System.Drawing.Size(206, 42);
			this.btnBackColor.TabIndex = 6;
			this.btnBackColor.Text = "Back Color Settings";
			this.btnBackColor.UseVisualStyleBackColor = true;
			this.btnBackColor.Visible = false;
			this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(541, 473);
			this.Controls.Add(this.btnBackColor);
			this.Controls.Add(this.btnCustomFonts);
			this.Controls.Add(this.btnSystemFonts);
			this.Controls.Add(this.bClose);
			this.Controls.Add(this.bHideControl);
			this.Controls.Add(this.cbShowDate);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Clock";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.White;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.CheckBox cbShowDate;
		private System.Windows.Forms.Button bHideControl;
		private System.Windows.Forms.Button bClose;
		private System.Windows.Forms.NotifyIcon NotifyIconClock;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button btnSystemFonts;
		private System.Windows.Forms.Button btnCustomFonts;
		private System.Windows.Forms.Button btnBackColor;
	}
}

