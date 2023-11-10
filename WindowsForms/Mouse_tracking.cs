using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
	public partial class Mouse_tracking : Form
	{
		public Mouse_tracking()
		{
			InitializeComponent();
			System.Timers.Timer tm = new System.Timers.Timer();
			tm.Interval = 2;
			tm.Elapsed += TmElapse;
			tm.Start();
			this.Left = Cursor.Position.X + 10;
			this.Top = Cursor.Position.Y - 30;
			label_clock.Text = DateTime.Now.ToString("HH:mm:ss");
		}

		void TmElapse(object sender, System.Timers.ElapsedEventArgs e)
		{
			Move();
		}

		private void timer_mouse_Tick(object sender, EventArgs e)
		{
			label_clock.Text = DateTime.Now.ToString("HH:mm:ss");
		}
		void Move()
		{
			this.Left = Cursor.Position.X + 10;
			this.Top = Cursor.Position.Y - 30;
		}
	}
}
