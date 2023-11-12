namespace WindowsForms
{
	partial class FontSettings
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
			this.cbFontList = new System.Windows.Forms.ComboBox();
			this.LFontExample = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.btnFontColor = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbFontList
			// 
			this.cbFontList.FormattingEnabled = true;
			this.cbFontList.Location = new System.Drawing.Point(12, 12);
			this.cbFontList.Name = "cbFontList";
			this.cbFontList.Size = new System.Drawing.Size(385, 24);
			this.cbFontList.TabIndex = 0;
			this.cbFontList.SelectedIndexChanged += new System.EventHandler(this.cbFont_SelectionChangeCommitted);
			// 
			// LFontExample
			// 
			this.LFontExample.AutoSize = true;
			this.LFontExample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LFontExample.Location = new System.Drawing.Point(9, 96);
			this.LFontExample.Name = "LFontExample";
			this.LFontExample.Size = new System.Drawing.Size(105, 18);
			this.LFontExample.TabIndex = 1;
			this.LFontExample.Text = "                                ";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(353, 192);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(125, 45);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(12, 192);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(125, 45);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnFontColor
			// 
			this.btnFontColor.Location = new System.Drawing.Point(403, 12);
			this.btnFontColor.Name = "btnFontColor";
			this.btnFontColor.Size = new System.Drawing.Size(75, 23);
			this.btnFontColor.TabIndex = 5;
			this.btnFontColor.UseVisualStyleBackColor = true;
			this.btnFontColor.Click += new System.EventHandler(this.FontColor_Click);
			// 
			// FontSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(490, 249);
			this.Controls.Add(this.btnFontColor);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.LFontExample);
			this.Controls.Add(this.cbFontList);
			this.Name = "FontSettings";
			this.Text = "FontSettings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbFontList;
		private System.Windows.Forms.Label LFontExample;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button btnFontColor;
	}
}