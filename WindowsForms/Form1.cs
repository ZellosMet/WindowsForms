using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace WindowsForms
{
	public partial class Form1 : Form
	{
		static Mouse_tracking MT = new Mouse_tracking();
		static ContextMenuStrip ClockContextMenu = new ContextMenuStrip();
		static ToolStripMenuItem MenuDate = new ToolStripMenuItem("Show date");
		static ToolStripMenuItem MenuControls = new ToolStripMenuItem("Show controls");
		static ToolStripMenuItem MenuMouseTracking = new ToolStripMenuItem("Mouse Tracking");
		static ToolStripMenuItem MenuClose = new ToolStripMenuItem("Close");
		static bool call_context_menu = false;
		static bool open_mouse_tracing = false;

		public Form1()
		{
			InitializeComponent();
			ClockContextMenu.Items.AddRange
				(
				new ToolStripItem[]
					{
						MenuDate,
						new ToolStripSeparator(),
						MenuControls,
						new ToolStripSeparator(),
						MenuMouseTracking,
						new ToolStripSeparator(),
						MenuClose
					}
				);
			NotifyIconClock.ContextMenuStrip = ClockContextMenu;
			MenuDate.Click += MenuDate_Click;
			MenuControls.Click += MenuControls_Click;
			MenuClose.Click += MenuClose_Click;
			MenuMouseTracking.Click += MenuMouseTrackng_Click;

			this.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width * 3 / 4 - 25, 0);
			label1.Text = DateTime.Now.ToString("HH:mm:ss");

			this.NotifyIconClock.Visible = true;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Text = DateTime.Now.ToString("HH:mm:ss");
			if (cbShowDate.Checked) label1.Text += $"\n{DateTime.Now.ToString("dd.MM.yyyy")}";
			call_context_menu = false;
		}
		private void label1_DoubleClick(object sender, EventArgs e)
		{
			if (MenuControls.Text == "Show controls") MenuControls.Text = "Hide controls";
			else MenuControls.Text = "Show controls";
			MenuUpdate();
			if (!this.ShowInTaskbar)
			{
				this.FormBorderStyle = FormBorderStyle.Sizable;
				this.TransparencyKey = Color.AliceBlue;
				this.ShowInTaskbar = true;
				this.cbShowDate.Visible = true;
				this.bClose.Visible = true;
				this.bHideControl.Visible = true;
			}
			else this.bHideControl_Click(sender, e);
		}

		private void bClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void bHideControl_Click(object sender, EventArgs e)
		{
			if (!call_context_menu)
			{
				if (MenuControls.Text == "Show controls") MenuControls.Text = "Hide controls";
				else MenuControls.Text = "Show controls";
				MenuUpdate();
			}
			else call_context_menu = false;
			this.bHideControl.Visible = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.TransparencyKey = Color.White;
			this.ShowInTaskbar = false;
			this.cbShowDate.Visible = false;
			this.bClose.Visible = false;
		}

		private void MenuDate_Click(object sender, EventArgs e)
		{
			call_context_menu = true;
			if (MenuDate.Text == "Show date") MenuDate.Text = "Hide date";
			else MenuDate.Text = "Show date";
			MenuUpdate();
			if (!cbShowDate.Checked)
			{
				cbShowDate.Checked = true;
				label1.Text += $"\n{DateTime.Now.ToString("dd.MM.yyyy")}";
			}
			else
			{
				cbShowDate.Checked = false;
				label1.Text = DateTime.Now.ToString("HH:mm:ss");
			}
		}
		private void MenuControls_Click(object sender, EventArgs e)
		{
			call_context_menu = true;
			label1_DoubleClick(sender, e);
		}
		private void MenuClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void NotifyIconClock_MouseClick(object sender, MouseEventArgs e)
		{
			ClockContextMenu.TopLevel = true;
			ClockContextMenu.Show(Cursor.Position);
		}

		private void cbShowDate_CheckedChanged(object sender, EventArgs e)
		{
			if (!call_context_menu)
			{
				if (MenuDate.Text == "Show date") MenuDate.Text = "Hide date";
				else MenuDate.Text = "Show date";
				MenuUpdate();
			}
			else call_context_menu = false;
		}
		private void MenuUpdate()
		{
			ClockContextMenu.Items.Clear();
			ClockContextMenu.Items.AddRange
				(
				new ToolStripItem[]
					{
						MenuDate,
						new ToolStripSeparator(),
						MenuControls,
						new ToolStripSeparator(),
						MenuMouseTracking,
						new ToolStripSeparator(),
						MenuClose
					}
				);
		}
		private void MenuMouseTrackng_Click(object sender, EventArgs e)
		{
			if (!open_mouse_tracing)
			{
				MenuControls_Click(sender, e);
				open_mouse_tracing = true;
				label1.Visible = false;
				MT.Show();
			}
			else
			{
				open_mouse_tracing = false;
				label1.Visible = true;
				MT.Hide();
			}
		}
	}
}
