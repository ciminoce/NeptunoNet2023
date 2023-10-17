using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeptunoNet2023.Windows
{
	public partial class frmPrincipal : Form
	{
		public frmPrincipal()
		{
			InitializeComponent();
		}

		private void btnPaises_Click(object sender, EventArgs e)
		{
			frmPaises frm = new frmPaises();
			frm.ShowDialog(this);
		}
	}
}
