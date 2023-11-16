using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
	public partial class FontSettings : Form
	{
		PrivateFontCollection PFC = new PrivateFontCollection();
		private Font set_font;
		private Font current_font;
		private Color set_fore_color;
		private Color current_fore_color;
		private string font_directory_path;
		private string[] fonts_list;
		public int CurrentFontSize { get; set; }
		public int SetFontSize { get; set; }
		public int Index { get; set; }
		public string[] FontsList
		{
			get { return fonts_list; }
			set { fonts_list = value; }
		}

		public string FontDirectory
		{
			get { return font_directory_path; }
			set { font_directory_path = value; }
		}
		public Font SetFont
		{
			get { return set_font; }
			set { set_font = value; }
		}
		public Font CurrentFont
		{
			get { return current_font; }
			set { current_font = value; }
		}
		public Color SetForeColor
		{
			get { return set_fore_color; }
			set { set_fore_color = value; }
		}
		public Color CurrentForeColor
		{
			get { return current_fore_color; }
			set { current_fore_color = value; }
		}
		public FontSettings(System.Windows.Forms.Label label, int index, string font_directory)
		{
			InitializeComponent();
			FontDirectory = font_directory;
			LoadCustomFonts();
			LFontExample.Font = label.Font;
			SetFont = CurrentFont = label.Font;
			SetForeColor = CurrentForeColor = label.ForeColor;
			SetFontSize = CurrentFontSize = (int)label.Font.Size;
			nudFontSize.Value = (decimal)label.Font.Size;
			cbFontList.SelectedIndex = index;
			btnFontColor.BackColor = label.ForeColor;
			LFontExample.ForeColor = label.ForeColor;
		}
		public void LoadCustomFonts()
		{
			Directory.SetCurrentDirectory(FontDirectory);
			string[] fonts = Directory.GetFiles(FontDirectory, "*.ttf");
			for (int i = 0; i < fonts.Length; i++)
			{
				string[] items = fonts[i].Split('\\');
				fonts[i] = items[items.Length - 1];
			}
			this.cbFontList.Items.AddRange(fonts);
			FontsList = Directory.GetFiles(FontDirectory);
			foreach (string i in FontsList)
				PFC.AddFontFile(i);
		}
		private void cbFont_SelectionChangeCommitted(object sender, EventArgs e)
		{
			PrivateFontCollection setPFC = new PrivateFontCollection();
			setPFC.AddFontFile(cbFontList.SelectedItem.ToString());
			CurrentFont = new Font(setPFC.Families[0], (int)nudFontSize.Value);
			LFontExample.Text = cbFontList.SelectedItem.ToString();
			LFontExample.Font = CurrentFont;
			Index = cbFontList.SelectedIndex;
		}
		private void btnOK_Click(object sender, EventArgs e)
		{
			SetFont = CurrentFont;
			SetForeColor = CurrentForeColor;
			SetFontSize = CurrentFontSize;
			this.Close();
		}
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void FontColor_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;
			CurrentForeColor = colorDialog1.Color;
			btnFontColor.BackColor = colorDialog1.Color;
			LFontExample.ForeColor = colorDialog1.Color;
		}
		private void nudFontSize_ValueChanged(object sender, EventArgs e)
		{
			CurrentFontSize = (int)nudFontSize.Value;
			LFontExample.Font = new Font(LFontExample.Font.FontFamily, (int)nudFontSize.Value);
		}
	}
}
