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

namespace WindowsForms
{
	public partial class Form1 : Form
	{
		private string[] fonts_list;
		private string font_directory_path;

		public string FontDirectoryPath
		{
			get { return font_directory_path; }
			set { font_directory_path = value; }
		}
		public string[] FontsList
		{
			get { return fonts_list; }
			set { fonts_list = value; }
		}

		static Font current_font;
		static Mouse_tracking MT = new Mouse_tracking();
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

			this.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width * 3 / 4 - 25, 0);
			label1.Text = DateTime.Now.ToString("HH:mm:ss");

			this.NotifyIconClock.Visible = true;

			SetFontDirectory();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
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
				bHideControl_Click(sender, e);
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
		private void MenuSystemFontSettings_Click(object sender, EventArgs e)
		{
			if (fontDialog1.ShowDialog() == DialogResult.Cancel)return;
			current_font = new Font(fontDialog1.Font.FontFamily, 48);
			label1.Font = current_font;
			label1.ForeColor = fontDialog1.Color;
		}
		private void MenuCustomFontSettings_Click(object sender, EventArgs e)
		{
			FontSettings FS = new FontSettings(label1, FontDirectoryPath);
			FS.ShowDialog(this);
			current_font = new Font(FS.CurrentFont.FontFamily, 48);
			label1.Font = current_font;
			label1.ForeColor = FS.CurrentForeColor;
		}
		private void MenuBackColor_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;
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
		private void SetFontDirectory()
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
		}
	}
}
