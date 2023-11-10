namespace WindowsForms
{
	partial class Mouse_tracking
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
			this.label_clock = new System.Windows.Forms.Label();
			this.timer_mouse = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// label_clock
			// 
			this.label_clock.AutoSize = true;
			this.label_clock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.label_clock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label_clock.Location = new System.Drawing.Point(2, 9);
			this.label_clock.Name = "label_clock";
			this.label_clock.Size = new System.Drawing.Size(109, 25);
			this.label_clock.TabIndex = 0;
			this.label_clock.Text = "label_clock";
			// 
			// timer_mouse
			// 
			this.timer_mouse.Enabled = true;
			this.timer_mouse.Interval = 1000;
			this.timer_mouse.Tick += new System.EventHandler(this.timer_mouse_Tick);
			// 
			// Mouse_tracking
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(121, 40);
			this.Controls.Add(this.label_clock);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Mouse_tracking";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Mouse_tracking";
			this.TransparencyKey = System.Drawing.Color.White;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label_clock;
		private System.Windows.Forms.Timer timer_mouse;
	}
}