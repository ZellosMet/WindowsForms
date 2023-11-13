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
		private Font set_font;
		private Font current_font;
		private Color set_fore_color;
		private Color current_fore_color;
		private string font_directory_path;

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
		public FontSettings(System.Windows.Forms.Label label, string font_directory)
		{
			InitializeComponent();
			FontDirectory = font_directory;
			SetFont = CurrentFont = label.Font;
			SetForeColor = CurrentForeColor = label.ForeColor;
			btnFontColor.BackColor = label.ForeColor;
			LoadCustomFonts();
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
		}

		private void cbFont_SelectionChangeCommitted(object sender, EventArgs e)
		{
			PrivateFontCollection PFC = new PrivateFontCollection();
			PFC.AddFontFile(cbFontList.SelectedItem.ToString());
			this.SetFont = new Font(PFC.Families[0], 18);
			LFontExample.Text = cbFontList.SelectedItem.ToString();
			LFontExample.Font = SetFont;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			CurrentFont = SetFont;
			CurrentForeColor = SetForeColor;
			this.Close();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FontColor_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;
			SetForeColor = colorDialog1.Color;
			btnFontColor.BackColor = colorDialog1.Color;
			LFontExample.ForeColor = colorDialog1.Color;
		}
	}
}
