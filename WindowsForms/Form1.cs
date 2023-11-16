using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using System.Drawing.Text;
using System.Reflection;

namespace WindowsForms
{
	public partial class Form1 : Form
	{
		int CBIndex { get; set; }
		public string FontDirectoryPath { get; set; }
		public string[] FontsList { get; set; }
		public Font CurrentFont { get; set; }
		public Color BackColorLabel { get; set; }
		public Color CurrentForeColor { get; set; }

		FontSettings FS;
		PrivateFontCollection MainPFC = new PrivateFontCollection();
		static Mouse_tracking MT;
		static ContextMenuStrip ClockContextMenu = new ContextMenuStrip();
		static ToolStripMenuItem MenuDate = new ToolStripMenuItem("Show date");
		static ToolStripMenuItem MenuControls = new ToolStripMenuItem("Show controls");
		static ToolStripMenuItem MenuMouseTracking = new ToolStripMenuItem("Mouse tracking");
		static ToolStripMenuItem MenuSystemFontSettings = new ToolStripMenuItem("System font settings");
		static ToolStripMenuItem MenuCustomFontSettings = new ToolStripMenuItem("Custom font settings");
		static ToolStripMenuItem MenuBackColor = new ToolStripMenuItem("Back color settings");
		static ToolStripMenuItem MenuClose = new ToolStripMenuItem("Close");
		static bool control_visible = false;
		static bool data_visible = false;
		static bool click_datamenu = false;
		static bool open_mouse_tracing = false;

		public Form1()
		{
			InitializeComponent();
			CurrentFont = Properties.Settings.Default.CurrentFont;
			CurrentForeColor = Properties.Settings.Default.CurrentForeColor;
			BackColorLabel = Properties.Settings.Default.BackColorLabel;

			label1.Font = Properties.Settings.Default.CurrentFont;
			label1.BackColor = Properties.Settings.Default.BackColorLabel;
			label1.ForeColor = Properties.Settings.Default.CurrentForeColor;

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
						MenuSystemFontSettings,
						MenuCustomFontSettings,
						MenuBackColor,
						new ToolStripSeparator(),
						MenuClose
					}
				);

			NotifyIconClock.ContextMenuStrip = ClockContextMenu;
			this.ContextMenuStrip = ClockContextMenu;
			label1.ContextMenuStrip = ClockContextMenu;

			MenuDate.Click += MenuDate_Click;
			MenuControls.Click += MenuControls_Click;
			MenuMouseTracking.Click += MenuMouseTrackng_Click;
			MenuSystemFontSettings.Click += MenuSystemFontSettings_Click;
			MenuCustomFontSettings.Click += MenuCustomFontSettings_Click;
			MenuBackColor.Click += MenuBackColor_Click;
			MenuClose.Click += MenuClose_Click;

			CBIndex = 0;
			this.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width * 3 / 4 - 25, 0);
			label1.Text = DateTime.Now.ToString("HH:mm:ss");

			this.NotifyIconClock.Visible = true;

			CurrentFont = label1.Font;

			LoadFonts();
			FS = new FontSettings(label1, CBIndex, FontDirectoryPath);
			MT = new Mouse_tracking(label1);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Font = CurrentFont;
			label1.Text = DateTime.Now.ToString("HH:mm:ss");
			if (cbShowDate.Checked) label1.Text += $"\n{DateTime.Now.ToString("dd.MM.yyyy")}";
		}
		private void label1_DoubleClick(object sender, EventArgs e)
		{
			if (!control_visible)
			{
				control_visible = true;
				MenuControls.Text = "Hide controls";
			}
			else 
			{
				control_visible = false;
				MenuControls.Text = "Show controls";
			}
			MenuUpdate();
			if (!this.ShowInTaskbar)
			{
				this.FormBorderStyle = FormBorderStyle.Sizable;
				this.TransparencyKey = Color.AliceBlue;
				this.ShowInTaskbar = true;
				this.cbShowDate.Visible = true;
				this.bClose.Visible = true;
				this.bHideControl.Visible = true;
				this.btnSystemFonts.Visible = true;
				this.btnCustomFonts.Visible = true;
				this.btnBackColor.Visible = true;
			}
			else
			{
				this.bHideControl.Visible = false;
				this.FormBorderStyle = FormBorderStyle.None;
				this.TransparencyKey = Color.White;
				this.ShowInTaskbar = false;
				this.cbShowDate.Visible = false;
				this.bClose.Visible = false;
				this.btnSystemFonts.Visible = false;
				this.btnCustomFonts.Visible = false;
				this.btnBackColor.Visible = false;
			}
		}

		private void bClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void bHideControl_Click(object sender, EventArgs e)
		{
			label1_DoubleClick(sender, e);
		}

		private void MenuDate_Click(object sender, EventArgs e)
		{
			click_datamenu = true;
			if (!data_visible)
			{
				data_visible = true;
				MenuDate.Text = "Hide date";
			}
			else
			{
				data_visible = false;
				MenuDate.Text = "Show date";
			}
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
			label1_DoubleClick(sender, e);
		}
		private void MenuClose_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.BackColorLabel = BackColorLabel;
			Properties.Settings.Default.CurrentFont = CurrentFont;
			Properties.Settings.Default.CurrentForeColor = CurrentForeColor;
			Properties.Settings.Default.Save();
			this.Close();
		}
		private void NotifyIconClock_MouseClick(object sender, MouseEventArgs e)
		{
			ClockContextMenu.TopLevel = true;
			ClockContextMenu.Show(Cursor.Position);
		}

		private void cbShowDate_CheckedChanged(object sender, EventArgs e)
		{
			if (click_datamenu)	click_datamenu = false;
			else 
			{
				if (!data_visible)
				{
					data_visible = true;
					MenuDate.Text = "Hide date";
				}
				else
				{
					data_visible = false;
					MenuDate.Text = "Show date";
				}
				MenuUpdate();
			}
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
						MenuSystemFontSettings,
						MenuCustomFontSettings,
						MenuBackColor,
						new ToolStripSeparator(),
						MenuClose
					}
				);
		}
		private void MenuMouseTrackng_Click(object sender, EventArgs e)
		{
			if (!open_mouse_tracing)
			{
				open_mouse_tracing = true;
				label1.Visible = false;
				MT.Show();
				if (!control_visible) return;
				bHideControl_Click(sender, e);
			}
			else
			{
				open_mouse_tracing = false;
				label1.Visible = true;
				MT.Hide();
			}
		}
		private void MenuSystemFontSettings_Click(object sender, EventArgs e)
		{
			if (fontDialog1.ShowDialog() == DialogResult.Cancel)return;
			CurrentFont = fontDialog1.Font;
			CurrentForeColor = fontDialog1.Color;
			label1.Font = new Font(CurrentFont.FontFamily, CurrentFont.Size);
			label1.ForeColor = CurrentForeColor;
			label1.BackColor = BackColorLabel;
		}
		private void MenuCustomFontSettings_Click(object sender, EventArgs e)
		{
			FS.ShowDialog(this);
			CurrentFont = FS.SetFont;
			label1.Font = new Font(CurrentFont.FontFamily, CurrentFont.Size);
			label1.ForeColor = FS.SetForeColor;
			CBIndex = FS.Index;
		}
		private void MenuBackColor_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;
			BackColorLabel = colorDialog1.Color;
			label1.BackColor = colorDialog1.Color;

		}
		private void btnSystemFonts_Click(object sender, EventArgs e)
		{
			MenuSystemFontSettings_Click(sender, e);
		}
		private void btnCustomFonts_Click(object sender, EventArgs e)
		{
			MenuCustomFontSettings_Click(sender, e);
		}
		private void btnBackColor_Click(object sender, EventArgs e)
		{
			MenuBackColor_Click(sender, e);
		}
		private void LoadFonts()
		{
			string DirectoryFonts = System.IO.Directory.GetCurrentDirectory();
			string[] DirectoryItems = DirectoryFonts.Split('\\');
			Array.Resize(ref DirectoryItems, DirectoryItems.Length - 2);
			string newDirectory = "";
			foreach (string i in DirectoryItems)
			{
				newDirectory += i;
				newDirectory += "\\";
			}
			newDirectory += "CustomFonts";
			FontsList = Directory.GetFiles(newDirectory);
			FontDirectoryPath = newDirectory;
			foreach(string i in FontsList)
			MainPFC.AddFontFile(i);
		}
	}
}
